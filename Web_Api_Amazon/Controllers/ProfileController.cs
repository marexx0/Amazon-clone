using Amazon_clone.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web_Api_Amazon.Models;
using Web_Api_Amazon.Entities;

public class ProfileController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly ShopDbContext _context;

    public ProfileController(UserManager<User> userManager, ShopDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Security()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return RedirectToAction("Entry");

        var session = new
        {
            DeviceName = "This device",
            BrowserName = Request.Headers["User-Agent"].ToString(),
            IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString(),
            IsCurrent = true
        };

        ViewBag.Sessions = new[] { session };
        ViewBag.CurrentToken = "current";
        return View();
    }

    public IActionResult Index()
    {
        ViewData["ActivePage"] = "Profile";
        return View();
    }
    public IActionResult Privacy()
    {
        ViewData["ActivePage"] = "Privacy";
        return View();
    }
    public IActionResult Accessibility()
    {
        ViewData["ActivePage"] = "Accessibility";
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Orders()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToAction("Entry", "Account");
        }

        var orders = await _context.Orders
            .Where(order => order.UserId == user.Id)
            .Include(order => order.OrderItems)
                .ThenInclude(item => item.Product)
            .OrderByDescending(order => order.OrderDate)
            .AsNoTracking()
            .ToListAsync();

        var model = new ProfileOrdersViewModel
        {
            Orders = orders.Select(order =>
            {
                var items = order.OrderItems
                    .Where(item => item.Product is not null)
                    .Select(item => new ProfileOrderItemViewModel
                    {
                        Name = item.Product!.Name,
                        Description = string.IsNullOrWhiteSpace(item.Product.Description)
                            ? "Product details"
                            : item.Product.Description,
                        ImageUrl = item.Product.ImageUrl,
                        Quantity = item.Quantity,
                        UnitPrice = (decimal)item.Price
                    })
                    .ToList();

                var subtotal = order.OrderItems.Sum(item => (decimal)item.Price * item.Quantity);

                return new ProfileOrderCardViewModel
                {
                    OrderId = order.Id,
                    OrderDate = order.OrderDate,
                    EstimatedDeliveryDate = order.OrderDate.AddDays(7),
                    Subtotal = subtotal,
                    Shipping = string.Equals(order.ShippingMethod, "Express", StringComparison.OrdinalIgnoreCase) ? 9.99m : 0m,
                    Tax = 0m,
                    Status = order.Status,
                    Items = items,
                    DeliveryTitle = BuildDeliveryTitle(order),
                    DeliveryAddress = BuildDeliveryAddress(order),
                    PaymentMethodTitle = BuildPaymentTitle(order),
                    PaymentMethodSubtitle = BuildPaymentSubtitle(order),
                    PreviewImageUrls = order.OrderItems
                        .Select(item => item.Product?.ImageUrl)
                        .Where(url => !string.IsNullOrWhiteSpace(url))
                        .Cast<string>()
                        .Take(3)
                        .ToList()
                };
            }).ToList()
        };

        ViewData["ActivePage"] = "Orders";
        return View(model);
    }

    private static string BuildPaymentTitle(Order order)
    {
        return order.PaymentMethod switch
        {
            "PayPal" => "PayPal",
            "ApplePay" => "Apple Pay",
            _ => "Line card"
        };
    }

    private static string BuildPaymentSubtitle(Order order)
    {
        return order.PaymentMethod switch
        {
            "PayPal" => "Paid with PayPal",
            "ApplePay" => "Paid with Apple Pay",
            _ => !string.IsNullOrWhiteSpace(order.PaymentCardLast4)
                ? $"Visa ending in {order.PaymentCardLast4}, expires {order.PaymentCardExpiry ?? "--/--"}"
                : "Visa ending in ----, expires --/--"
        };
    }

    private static string BuildDeliveryTitle(Order order)
    {
        return string.Equals(order.ShippingMethod, "Express", StringComparison.OrdinalIgnoreCase)
            ? "Express delivery"
            : "Standard delivery";
    }

    private static string BuildDeliveryAddress(Order order)
    {
        var segments = new[]
        {
            order.ShippingCountry,
            order.ShippingCity,
            order.ShippingState,
            order.ShippingPostalCode,
            order.ShippingAddressLine1,
            order.ShippingAddressLine2
        };

        var address = string.Join(", ", segments.Where(segment => !string.IsNullOrWhiteSpace(segment)));
        return string.IsNullOrWhiteSpace(address) ? "Address not provided" : address;
    }
}