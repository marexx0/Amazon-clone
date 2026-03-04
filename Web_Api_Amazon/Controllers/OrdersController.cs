using System.Security.Claims;
using System.Text.Json;
using Amazon_clone.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Web_Api_Amazon.Entities;
using Web_Api_Amazon.Models;

namespace Web_Api_Amazon.Controllers;

public class OrdersController : Controller
{
    private const string LocalCartSessionKey = "LocalCart";
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
            var user = await _userManager.FindByIdAsync(userId!);
            if (user is not null)
            {
                model.FirstName = user.FirstName ?? string.Empty;
                model.LastName = user.LastName ?? string.Empty;
                model.Email = user.Email ?? string.Empty;
                model.PhoneNumber = user.PhoneNumber ?? string.Empty;
            }
        }

        if (model.Items.Count == 0)
        {
            TempData["CheckoutError"] = "Your cart is empty.";
            return RedirectToAction("Index", "Cart");
        }

        return View(model);
    }

    // This handles the submission of the Shipping details from Checkout.cshtml
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Payment(CheckoutViewModel model)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var isSignedIn = !string.IsNullOrWhiteSpace(userId);

        // Rebuild the cart items for the summary
        var cartModel = isSignedIn
            ? await BuildCheckoutModelForUserAsync(userId!, model.ShippingMethod)
            : await BuildCheckoutModelForGuestAsync(model.ShippingMethod);

        model.Items = cartModel.Items;
        model.IsSignedIn = isSignedIn;

        if (model.Items.Count == 0)
        {
            TempData["CheckoutError"] = "Your cart is empty.";
            return RedirectToAction("Index", "Cart");
        }

        // If the shipping details are invalid, send them back to the Checkout page
        if (!ModelState.IsValid)
        {
            return View("Checkout", model);
        }

        // Serialize and save the validated shipping details for the final step
        TempData["CheckoutData"] = JsonSerializer.Serialize(model);

        // Render the Payment.cshtml page
        return View(model);
    }

    // This handles the submission from the Payment.cshtml page
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ProcessPayment(string PaymentMethod)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var isSignedIn = !string.IsNullOrWhiteSpace(userId);

        // Retrieve the saved shipping data
        var rawCheckoutData = TempData["CheckoutData"]?.ToString();
        if (string.IsNullOrWhiteSpace(rawCheckoutData))
        {
            return RedirectToAction("Checkout"); // Session expired or missing data
        }

        var checkoutData = JsonSerializer.Deserialize<CheckoutViewModel>(rawCheckoutData);

        var cartModel = isSignedIn
            ? await BuildCheckoutModelForUserAsync(userId!, checkoutData!.ShippingMethod)
            : await BuildCheckoutModelForGuestAsync(checkoutData!.ShippingMethod);

        if (cartModel.Items.Count == 0) return RedirectToAction("Index", "Cart");

        // Create the final order
        var order = new Order
        {
            UserId = userId, // Will be null for guests
            OrderDate = DateTime.UtcNow,
            Status = OrderStatus.Pending,
            OrderItems = cartModel.Items.Select(item => new OrderItem
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Price = (double)item.UnitPrice
            }).ToList()
        };

        _context.Orders.Add(order);

        // Clear the user's cart
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

        // Pass success details to Complete view
        TempData["CheckoutName"] = $"{checkoutData.FirstName} {checkoutData.LastName}";
        TempData["CheckoutAddress"] = $"{checkoutData.AddressLine1}, {checkoutData.City}, {checkoutData.State} {checkoutData.PostalCode}, {checkoutData.Country}";
        TempData["CheckoutShipping"] = checkoutData.ShippingMethod;
        TempData["CheckoutGift"] = checkoutData.IncludeGift;
        TempData["PaymentMethod"] = PaymentMethod;

        return RedirectToAction(nameof(Complete), new { id = order.Id });
    }

    [HttpGet]
    public async Task<IActionResult> Complete(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var order = await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == id);

        if (order is null) return NotFound();

        // Ensure users can't view someone else's order (Allow if guest order OR if it belongs to current user)
        if (order.UserId != null && order.UserId != userId)
        {
            return Challenge();
        }

        return View(order);
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
                .Where(ci => ci.Product != null)
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
            .Where(p => productIds.Contains(p.Id))
            .AsNoTracking()
            .ToDictionaryAsync(p => p.Id);

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
}