using System.Security.Claims;
using System.Text.Json;
using Amazon_clone.DataAccess.Data;
using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Web_Api_Amazon.Models;

namespace Web_Api_Amazon.Controllers;

public class FavoritesController : Controller
{
    private const string LocalFavoritesSessionKey = "LocalFavorites";
    private readonly IFavoritesService _favoritesService;
    private readonly ShopDbContext _context;

    public FavoritesController(IFavoritesService favoritesService, ShopDbContext context)
    {
        _favoritesService = favoritesService;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        ViewData["ActivePage"] = "Favorites";

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        List<int> productIds;

        if (!string.IsNullOrWhiteSpace(userId))
        {
            await MergeLocalFavoritesIntoUserAsync(userId);

            productIds = (await _favoritesService.GetFavoritesAsync(userId))
                .Select(x => x.ProductId)
                .ToList();
        }
        else
        {
            productIds = GetLocalFavorites();
        }

        if (!productIds.Any())
        {
            return View("~/Views/Profile/Favourites.cshtml",
                new List<Web_Api_Amazon.Entities.Product>());
        }

        var products = await _context.Products
            .Where(p => productIds.Contains(p.Id))
            .Include(p => p.Category)
            .Include(p => p.Images)
            .Include(p => p.Variants)
            .AsNoTracking()
            .ToListAsync();

        return View("~/Views/Profile/Favourites.cshtml", products);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(int productId, string? returnUrl = null)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrWhiteSpace(userId))
        {
            return BuildAuthRequiredResult(returnUrl);
        }

        await _favoritesService.AddAsync(userId, productId);

        if (IsAjaxRequest())
        {
            return Json(new
            {
                success = true,
                isFavorite = true,
                message = "Added to favorites."
            });
        }

        if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
        {
            return LocalRedirect(returnUrl);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Remove(int productId, string? returnUrl = null)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrWhiteSpace(userId))
        {
            return BuildAuthRequiredResult(returnUrl);
        }

        await _favoritesService.RemoveAsync(userId, productId);

        if (IsAjaxRequest())
        {
            return Json(new
            {
                success = true,
                isFavorite = false,
                message = "Removed from favorites."
            });
        }

        if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
        {
            return LocalRedirect(returnUrl);
        }

        return RedirectToAction(nameof(Index));
    }

    private List<int> GetLocalFavorites()
    {
        var raw = HttpContext.Session.GetString(LocalFavoritesSessionKey);
        if (string.IsNullOrWhiteSpace(raw))
        {
            return new List<int>();
        }

        try
        {
            return JsonSerializer.Deserialize<List<int>>(raw) ?? new List<int>();
        }
        catch
        {
            return new List<int>();
        }
    }

    private void SaveLocalFavorites(List<int> productIds)
    {
        if (productIds.Count == 0)
        {
            HttpContext.Session.Remove(LocalFavoritesSessionKey);
            return;
        }

        HttpContext.Session.SetString(LocalFavoritesSessionKey, JsonSerializer.Serialize(productIds.Distinct().ToList()));
    }

    private async Task MergeLocalFavoritesIntoUserAsync(string userId)
    {
        var localFavorites = GetLocalFavorites();
        if (localFavorites.Count == 0)
        {
            return;
        }

        foreach (var productId in localFavorites.Distinct())
        {
            await _favoritesService.AddAsync(userId, productId);
        }

        HttpContext.Session.Remove(LocalFavoritesSessionKey);
    }

    private IActionResult BuildAuthRequiredResult(string? returnUrl)
    {
        var loginUrl = Url.Action("Entry", "Account", new
        {
            returnUrl = string.IsNullOrWhiteSpace(returnUrl) ? $"{Request.Path}{Request.QueryString}" : returnUrl
        }) ?? "/Account/Entry";

        if (IsAjaxRequest())
        {
            Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Json(new
            {
                success = false,
                requiresLogin = true,
                message = "Please sign in to manage favorites.",
                redirectUrl = loginUrl
            });
        }

        return Redirect(loginUrl);
    }

    private static ProductCardViewModel MapToViewModel(ProductCardDto dto)
    {
        return new ProductCardViewModel
        {
            ProductId = dto.ProductId,
            Name = dto.Name,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl,
            Price = dto.Price,
            InStock = dto.InStock,
            Rating = dto.Rating,
            VariantKey = dto.VariantKey
        };
    }

    private bool IsAjaxRequest()
    {
        return string.Equals(Request.Headers["X-Requested-With"], "XMLHttpRequest", StringComparison.OrdinalIgnoreCase);
    }
}
