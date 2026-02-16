using System.Security.Claims;
using Amazon_clone.DataAccess.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api_Amazon.Models;

namespace Web_Api_Amazon.Controllers;

public class CartController : Controller
{
    private readonly ShopDbContext _context;

    public CartController(ShopDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var cartItems = new List<CartProductViewModel>();
        if (!string.IsNullOrWhiteSpace(userId))
        {
            var cartRows = await _context.CartItems
                .Where(ci => ci.UserId == userId)
                .Include(ci => ci.Product)
                .ThenInclude(p => p.Images)
                .Include(ci => ci.Product)
                .ThenInclude(p => p.Variants)
                .ThenInclude(v => v.VariantValues)
                .ThenInclude(vv => vv.PropertyDefinition)
                .AsNoTracking()
                .ToListAsync();

            cartItems = cartRows.Select(row => BuildCartItem(row.Product, row.Quantity)).ToList();
        }

        var usedIds = cartItems.Select(item => item.ProductId).ToHashSet();

        var products = await _context.Products
            .Include(p => p.Images)
            .Include(p => p.Variants)
            .AsNoTracking()
            .ToListAsync();

        var savedForLater = products
            .Where(product => !usedIds.Contains(product.Id))
            .OrderBy(product => product.Name)
            .Take(3)
            .Select(BuildProductCard)
            .ToList();

        var recommendations = products
            .Where(product => !usedIds.Contains(product.Id))
            .OrderByDescending(product => product.Id)
            .Take(6)
            .Select(BuildProductCard)
            .ToList();

        var viewModel = new ShoppingCartViewModel
        {
            CartItems = cartItems,
            SavedForLater = savedForLater,
            Recommendations = recommendations,
            IsSignedIn = User.Identity?.IsAuthenticated == true
        };

        return View(viewModel);
    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(int productId, int quantity = 1, string? returnUrl = null)
    {
        if (quantity < 1)
        {
            quantity = 1;
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userId))
        {
            return Challenge();
        }

        var productExists = await _context.Products.AnyAsync(p => p.Id == productId);
        if (!productExists)
        {
            return NotFound();
        }

        var existing = await _context.CartItems
            .FirstOrDefaultAsync(ci => ci.UserId == userId && ci.ProductId == productId);

        if (existing is null)
        {
            _context.CartItems.Add(new CartItem
            {
                UserId = userId,
                ProductId = productId,
                Quantity = quantity
            });
        }
        else
        {
            existing.Quantity += quantity;
        }

        await _context.SaveChangesAsync();

        if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
        {
            return LocalRedirect(returnUrl);
        }

        return RedirectToAction(nameof(Index));
    }

    private static CartProductViewModel BuildCartItem(Product product, int quantity)
    {
        var firstVariant = product.Variants.FirstOrDefault();
        var size = firstVariant?.VariantValues.FirstOrDefault(v => v.PropertyDefinition?.Name == "Size")?.Value ?? "Default";
        var color = firstVariant?.VariantValues.FirstOrDefault(v => v.PropertyDefinition?.Name == "Color")?.Value ?? "Default";
        var imageUrl = product.Images.OrderBy(i => i.SortOrder).FirstOrDefault()?.ImageUrl ?? product.ImageUrl;

        return new CartProductViewModel
        {
            ProductId = product.Id,
            Name = product.Name,
            Quantity = quantity,
            UnitPrice = (decimal)product.Price,
            Size = size,
            Color = color,
            InStock = product.Variants.Sum(v => v.Quantity) > 0 || !product.Variants.Any(),
            ImageUrl = imageUrl
        };
    }

    private static ProductCardViewModel BuildProductCard(Product product)
    {
        var imageUrl = product.Images.OrderBy(i => i.SortOrder).FirstOrDefault()?.ImageUrl ?? product.ImageUrl;

        return new ProductCardViewModel
        {
            ProductId = product.Id,
            Name = product.Name,
            Description = product.Description,
            ImageUrl = imageUrl,
            Price = (decimal)product.Price,
            InStock = product.Variants.Sum(v => v.Quantity) > 0 || !product.Variants.Any(),
            Rating = 4.2 + ((product.Id % 7) * 0.1)
        };
    }
}