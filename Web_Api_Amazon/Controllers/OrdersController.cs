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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Checkout(CheckoutViewModel model)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userId))
        {
            return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Checkout", "Orders") });
        }

        var cartModel = await BuildCheckoutModelForUserAsync(userId, model.ShippingMethod);
        model.Items = cartModel.Items;
        model.IsSignedIn = true;

        if (model.Items.Count == 0)
        {
            TempData["CheckoutError"] = "Your cart is empty.";
            return RedirectToAction("Index", "Cart");
        }

        if (!ModelState.IsValid) return View(model);

        var order = new Order
        {
            UserId = userId,
            OrderDate = DateTime.UtcNow,
            Status = OrderStatus.Pending,
            OrderItems = model.Items.Select(item => new OrderItem
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Price = (double)item.UnitPrice
            }).ToList()
        };

        _context.Orders.Add(order);

        var userCartItems = await _context.CartItems.Where(ci => ci.UserId == userId).ToListAsync();
        _context.CartItems.RemoveRange(userCartItems);

        await _context.SaveChangesAsync();

        TempData["CheckoutName"] = $"{model.FirstName} {model.LastName}";
        TempData["CheckoutAddress"] = $"{model.AddressLine1}, {model.City}, {model.State} {model.PostalCode}, {model.Country}";
        TempData["CheckoutShipping"] = model.ShippingMethod;
        TempData["CheckoutGift"] = model.IncludeGift;

        return RedirectToAction(nameof(Complete), new { id = order.Id });
    }

    [HttpGet]
    public async Task<IActionResult> Complete(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userId)) return Challenge();

        var order = await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == id && o.UserId == userId);

        if (order is null) return NotFound();

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