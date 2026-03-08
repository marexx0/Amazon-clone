using System.Security.Claims;
using System.Text.Json;
using Amazon_clone.DataAccess.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api_Amazon.Entities;
using Web_Api_Amazon.Models;

namespace Web_Api_Amazon.Controllers;

public class OrdersController : Controller
{
    private const string LocalCartSessionKey = "LocalCart";
    private const string CheckoutDataTempDataKey = "CheckoutData";
    private const string OrderCompleteContextTempDataKey = "OrderCompleteContext";

    private readonly ShopDbContext _context;
    private readonly UserManager<User> _userManager;

    public OrdersController(ShopDbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Checkout()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var isSignedIn = !string.IsNullOrWhiteSpace(userId);

        var model = isSignedIn
            ? await BuildCheckoutModelForUserAsync(userId!)
            : await BuildCheckoutModelForGuestAsync();

        model.IsSignedIn = isSignedIn;

        if (isSignedIn)
        {
            await PopulateSignedInUserAsync(model, userId!);
        }

        if (model.Items.Count == 0)
        {
            TempData["CheckoutError"] = "Your cart is empty.";
            return RedirectToAction("Index", "Cart");
        }

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Payment(CheckoutViewModel model)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var isSignedIn = !string.IsNullOrWhiteSpace(userId);

        var refreshedCartModel = isSignedIn
            ? await BuildCheckoutModelForUserAsync(userId!, model.ShippingMethod)
            : await BuildCheckoutModelForGuestAsync(model.ShippingMethod);

        model.Items = refreshedCartModel.Items;
        model.IsSignedIn = isSignedIn;

        if (model.Items.Count == 0)
        {
            TempData["CheckoutError"] = "Your cart is empty.";
            return RedirectToAction("Index", "Cart");
        }

        if (!ModelState.IsValid)
        {
            return View("Checkout", model);
        }

        TempData[CheckoutDataTempDataKey] = JsonSerializer.Serialize(model);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ProcessPayment(string paymentMethod, string? cardNumber, string? expiryDate, string? nameOnCard)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var isSignedIn = !string.IsNullOrWhiteSpace(userId);

        var checkoutData = ReadCheckoutData();
        if (checkoutData is null)
        {
            return RedirectToAction(nameof(Checkout));
        }

        var selectedPaymentMethod = NormalizePaymentMethod(paymentMethod);
        var cardLast4 = ExtractCardLast4(cardNumber);

        var cartModel = isSignedIn
            ? await BuildCheckoutModelForUserAsync(userId!, checkoutData.ShippingMethod)
            : await BuildCheckoutModelForGuestAsync(checkoutData.ShippingMethod);

        if (cartModel.Items.Count == 0)
        {
            TempData["CheckoutError"] = "Your cart is empty.";
            return RedirectToAction("Index", "Cart");
        }

        var requestedQuantities = cartModel.Items
            .GroupBy(item => item.ProductId)
            .Select(group => new ProductQuantityRequest
            {
                ProductId = group.Key,
                Quantity = group.Sum(item => item.Quantity)
            })
            .ToList();

        var requestedProductIds = requestedQuantities.Select(r => r.ProductId).ToList();

        var variantStockByProduct = await _context.ProductVariants
            .Where(variant => requestedProductIds.Contains(variant.ProductId))
            .GroupBy(variant => variant.ProductId)
            .Select(group => new ProductQuantityRequest
            {
                ProductId = group.Key,
                Quantity = group.Sum(variant => variant.Quantity)
            })
            .ToDictionaryAsync(item => item.ProductId, item => item.Quantity);

        foreach (var request in requestedQuantities)
        {
            if (!variantStockByProduct.TryGetValue(request.ProductId, out var availableStock))
            {
                continue;
            }

            if (request.Quantity > availableStock)
            {
                TempData["CheckoutError"] = "Some products are out of stock. Please update your cart.";
                return RedirectToAction("Index", "Cart");
            }
        }

        var order = new Order
        {
            UserId = userId,
            OrderDate = DateTime.UtcNow,
            Status = OrderStatus.New,
            ShippingMethod = checkoutData.ShippingMethod,
            ShippingAddressLine1 = checkoutData.AddressLine1,
            ShippingAddressLine2 = checkoutData.AddressLine2,
            ShippingCity = checkoutData.City,
            ShippingState = checkoutData.State,
            ShippingPostalCode = checkoutData.PostalCode,
            ShippingCountry = checkoutData.Country,
            PaymentMethod = selectedPaymentMethod,
            PaymentCardLast4 = cardLast4,
            PaymentCardExpiry = expiryDate,
            PaymentCardholderName = nameOnCard,
            OrderItems = cartModel.Items.Select(item => new OrderItem
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Price = (double)item.UnitPrice
            }).ToList()
        };

        // Payment is confirmed in this action, so advance from New to Processing.
        AdvanceOrderStatus(order, OrderStatus.Processing);

        _context.Orders.Add(order);

        await ReduceVariantInventoryAsync(requestedQuantities);

        if (isSignedIn)
        {
            var userCartItems = await _context.CartItems.Where(ci => ci.UserId == userId).ToListAsync();
            _context.CartItems.RemoveRange(userCartItems);
        }
        else
        {
            HttpContext.Session.Remove(LocalCartSessionKey);
        }

        await _context.SaveChangesAsync();

        var completionContext = new OrderCompletionContext
        {
            FirstName = checkoutData.FirstName,
            LastName = checkoutData.LastName,
            AddressLine1 = checkoutData.AddressLine1,
            AddressLine2 = checkoutData.AddressLine2,
            City = checkoutData.City,
            State = checkoutData.State,
            PostalCode = checkoutData.PostalCode,
            Country = checkoutData.Country,
            ShippingMethod = checkoutData.ShippingMethod,
            PaymentMethod = selectedPaymentMethod
        };

        TempData[OrderCompleteContextTempDataKey] = JsonSerializer.Serialize(completionContext);

        return RedirectToAction(nameof(Complete), new { id = order.Id });
    }

    [HttpGet]
    public async Task<IActionResult> Complete(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var order = await _context.Orders
            .Include(o => o.User)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (order is null)
        {
            return NotFound();
        }

        if (!string.IsNullOrWhiteSpace(order.UserId) && order.UserId != userId)
        {
            return Challenge();
        }

        // Completing checkout should mark the order as Completed unless it is already beyond that state.
        if (CanAdvanceTo(order.Status, OrderStatus.Completed))
        {
            order.Status = OrderStatus.Completed;
            await _context.SaveChangesAsync();
        }

        var completionContext = ReadOrderCompletionContext();

        var model = new OrderCompleteViewModel
        {
            OrderId = order.Id,
            OrderDate = order.OrderDate,
            CustomerName = BuildCustomerName(completionContext, order.User),
            ShippingAddress = BuildShippingAddress(order, completionContext),
            ShippingMethod = !string.IsNullOrWhiteSpace(order.ShippingMethod) ? order.ShippingMethod : completionContext?.ShippingMethod ?? "Standard",
            PaymentMethod = !string.IsNullOrWhiteSpace(order.PaymentMethod) ? order.PaymentMethod : completionContext?.PaymentMethod ?? "CreditCard",
            TransactionId = BuildTransactionId(order),
            Items = order.OrderItems
                .Where(item => item.Product is not null)
                .Select(item => new OrderCompleteItemViewModel
                {
                    ProductId = item.ProductId,
                    Name = item.Product.Name,
                    ImageUrl = item.Product.ImageUrl,
                    Quantity = item.Quantity,
                    UnitPrice = (decimal)item.Price
                })
                .ToList()
        };

        return View(model);
    }

    private async Task ReduceVariantInventoryAsync(List<ProductQuantityRequest> requests)
    {
        if (requests.Count == 0)
        {
            return;
        }

        var productIds = requests.Select(r => r.ProductId).ToList();

        var variants = await _context.ProductVariants
            .Where(variant => productIds.Contains(variant.ProductId))
            .OrderBy(variant => variant.Id)
            .ToListAsync();

        foreach (var request in requests)
        {
            var remaining = request.Quantity;
            var productVariants = variants.Where(variant => variant.ProductId == request.ProductId && variant.Quantity > 0);

            foreach (var variant in productVariants)
            {
                if (remaining <= 0)
                {
                    break;
                }

                var toReduce = Math.Min(variant.Quantity, remaining);
                variant.Quantity -= toReduce;
                remaining -= toReduce;
            }
        }
    }

    private async Task PopulateSignedInUserAsync(CheckoutViewModel model, string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user is null)
        {
            return;
        }

        model.FirstName = user.FirstName ?? string.Empty;
        model.LastName = user.LastName ?? string.Empty;
        model.Email = user.Email ?? string.Empty;
        model.PhoneNumber = user.PhoneNumber ?? string.Empty;
    }

    private CheckoutViewModel? ReadCheckoutData()
    {
        var rawCheckoutData = TempData[CheckoutDataTempDataKey]?.ToString();
        if (string.IsNullOrWhiteSpace(rawCheckoutData))
        {
            return null;
        }

        try
        {
            return JsonSerializer.Deserialize<CheckoutViewModel>(rawCheckoutData);
        }
        catch
        {
            return null;
        }
    }

    private OrderCompletionContext? ReadOrderCompletionContext()
    {
        var rawContext = TempData.Peek(OrderCompleteContextTempDataKey)?.ToString();
        if (string.IsNullOrWhiteSpace(rawContext))
        {
            return null;
        }

        try
        {
            return JsonSerializer.Deserialize<OrderCompletionContext>(rawContext);
        }
        catch
        {
            return null;
        }
    }

    private static string NormalizePaymentMethod(string? paymentMethod)
    {
        return paymentMethod switch
        {
            "PayPal" => "PayPal",
            "ApplePay" => "ApplePay",
            _ => "CreditCard"
        };
    }

    private static void AdvanceOrderStatus(Order order, OrderStatus targetStatus)
    {
        if (CanAdvanceTo(order.Status, targetStatus))
        {
            order.Status = targetStatus;
        }
    }

    private static bool CanAdvanceTo(OrderStatus currentStatus, OrderStatus targetStatus)
    {
        // Keep Pending as a legacy/pre-payment fallback and allow normal forward transitions.
        if (currentStatus == OrderStatus.Pending)
        {
            return targetStatus is OrderStatus.Processing or OrderStatus.Shipped or OrderStatus.Completed;
        }

        return currentStatus <= targetStatus;
    }

    private static string BuildCustomerName(OrderCompletionContext? context, User? orderUser)
    {
        var contextName = $"{context?.FirstName} {context?.LastName}".Trim();
        if (!string.IsNullOrWhiteSpace(contextName))
        {
            return contextName;
        }

        var userName = $"{orderUser?.FirstName} {orderUser?.LastName}".Trim();
        if (!string.IsNullOrWhiteSpace(userName))
        {
            return userName;
        }

        return orderUser?.Email ?? string.Empty;
    }

    private static string BuildShippingAddress(Order order, OrderCompletionContext? context)
    {
        var orderSegments = new[]
        {
            order.ShippingAddressLine1,
            order.ShippingAddressLine2,
            order.ShippingCity,
            $"{order.ShippingState} {order.ShippingPostalCode}".Trim(),
            order.ShippingCountry
        };

        var orderAddress = string.Join(", ", orderSegments.Where(segment => !string.IsNullOrWhiteSpace(segment)));
        if (!string.IsNullOrWhiteSpace(orderAddress))
        {
            return orderAddress;
        }

        if (context is null)
        {
            return string.Empty;
        }

        var segments = new[]
        {
            context.AddressLine1,
            context.AddressLine2,
            context.City,
            $"{context.State} {context.PostalCode}".Trim(),
            context.Country
        };

        return string.Join(", ", segments.Where(segment => !string.IsNullOrWhiteSpace(segment)));
    }

    private static string BuildTransactionId(Order order)
        => $"ORD-{order.Id}-{order.OrderDate:yyyyMMddHHmmss}";

    private static string? ExtractCardLast4(string? cardNumber)
    {
        if (string.IsNullOrWhiteSpace(cardNumber))
        {
            return null;
        }

        var digits = new string(cardNumber.Where(char.IsDigit).ToArray());
        if (digits.Length < 4)
        {
            return null;
        }

        return digits[^4..];
    }


    private async Task<CheckoutViewModel> BuildCheckoutModelForUserAsync(string userId, string shippingMethod = "Standard")
    {
        var cartItems = await _context.CartItems
            .Where(ci => ci.UserId == userId)
            .Include(ci => ci.Product)
            .AsNoTracking()
            .ToListAsync();

        return new CheckoutViewModel
        {
            ShippingMethod = shippingMethod,
            Items = cartItems
                .Where(ci => ci.Product is not null)
                .Select(ci => new CheckoutSummaryItemViewModel
                {
                    ProductId = ci.ProductId,
                    Name = ci.Product.Name,
                    Quantity = ci.Quantity,
                    UnitPrice = (decimal)ci.Product.Price
                })
                .ToList()
        };
    }

    private async Task<CheckoutViewModel> BuildCheckoutModelForGuestAsync(string shippingMethod = "Standard")
    {
        var localCart = GetLocalCart();
        if (localCart.Count == 0)
        {
            return new CheckoutViewModel { ShippingMethod = shippingMethod };
        }

        var productIds = localCart.Select(item => item.ProductId).Distinct().ToList();
        var products = await _context.Products
            .Where(product => productIds.Contains(product.Id))
            .AsNoTracking()
            .ToDictionaryAsync(product => product.Id);

        return new CheckoutViewModel
        {
            ShippingMethod = shippingMethod,
            Items = localCart
                .Where(item => products.ContainsKey(item.ProductId))
                .Select(item => new CheckoutSummaryItemViewModel
                {
                    ProductId = item.ProductId,
                    Name = products[item.ProductId].Name,
                    Quantity = item.Quantity,
                    UnitPrice = (decimal)products[item.ProductId].Price
                })
                .ToList()
        };
    }

    private List<LocalCartLine> GetLocalCart()
    {
        var raw = HttpContext.Session.GetString(LocalCartSessionKey);
        if (string.IsNullOrWhiteSpace(raw))
        {
            return new List<LocalCartLine>();
        }

        try
        {
            using var json = JsonDocument.Parse(raw);

            if (json.RootElement.ValueKind == JsonValueKind.Array)
            {
                return JsonSerializer.Deserialize<List<LocalCartLine>>(raw) ?? new List<LocalCartLine>();
            }

            var oldFormat = JsonSerializer.Deserialize<Dictionary<int, int>>(raw) ?? new Dictionary<int, int>();
            return oldFormat.Select(kv => new LocalCartLine
            {
                ProductId = kv.Key,
                Quantity = kv.Value
            }).ToList();
        }
        catch
        {
            return new List<LocalCartLine>();
        }
    }

    private sealed class LocalCartLine
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    private sealed class ProductQuantityRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}