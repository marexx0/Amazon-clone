using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web_Api_Amazon.Entities;

public class ProfileController : Controller
{
    private readonly UserManager<User> _userManager;  

    public ProfileController(UserManager<User> userManager) 
    {
        _userManager = userManager;
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
        return View();
    }
}