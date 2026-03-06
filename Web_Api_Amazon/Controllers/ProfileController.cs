using Azure.Core;
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
            Orders = orders.Select(order => new ProfileOrderCardViewModel
            {
                OrderId = order.Id,
                OrderDate = order.OrderDate,
                EstimatedDeliveryDate = order.OrderDate.AddDays(order.Status == OrderStatus.Shipped ? 7 : 7),
                Total = order.OrderItems.Sum(item => (decimal)item.Price * item.Quantity),
                Status = order.Status,
                PreviewImageUrl= order.OrderItems
                    .Select(item => item.Product?.ImageUrl)
                    .FirstOrDefault(url => !string.IsNullOrWhiteSpace(url))
            }).ToList()
        };

        ViewData["ActivePage"] = "Orders";
        return View(model);
    }
}