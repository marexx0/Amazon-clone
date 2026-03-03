using System.Security.Claims;
using System.Text.Json;
using Amazon_clone.DataAccess.Data;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api_Amazon.Entities;
using Web_Api_Amazon.Models;

namespace Web_Api_Amazon.Controllers;

public class CartController : Controller
{
    private const string LocalCartSessionKey = "LocalCart";
    private const string LocalSavedForLaterSessionKey = "LocalSavedForLater";
    private const string LocalFavoritesSessionKey = "LocalFavorites";
    private readonly ShopDbContext _context;
    private readonly ISavedForLaterService _savedForLaterService;
    private readonly IFavoritesService _favoritesService;

    public CartController(ShopDbContext context, ISavedForLaterService savedForLaterService, IFavoritesService favoritesService)
    {
        _context = context;
        _savedForLaterService = savedForLaterService;
        _favoritesService = favoritesService;
    }

    public async Task<IActionResult> Index()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!string.IsNullOrWhiteSpace(userId))
        {
            await MergeLocalCartIntoUserCartAsync(userId);
            await MergeLocalSavedIntoUserSavedAsync(userId);
            await MergeLocalFavoritesIntoUserAsync(userId);
        }

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

            cartItems = cartRows
               .Select(row => BuildCartItem(row.Product, row.Quantity, row.VariantKey, row.SelectedOptionsJson))
               .ToList();
        }
        else
        {
            var localCart = GetLocalCart();
            if (localCart.Count > 0)
            {
                var productIds = localCart.Select(item => item.ProductId).Distinct().ToList();
                var localProducts = await _context.Products
                    .Where(p => productIds.Contains(p.Id))
                    .Include(p => p.Images)
                    .Include(p => p.Variants)
                    .ThenInclude(v => v.VariantValues)
                    .ThenInclude(vv => vv.PropertyDefinition)
                    .AsNoTracking()
                    .ToListAsync();

                var productMap = localProducts.ToDictionary(p => p.Id);
                cartItems = localCart
                    .Where(item => productMap.ContainsKey(item.ProductId))
                    .Select(item => BuildCartItem(productMap[item.ProductId], item.Quantity, item.VariantKey, item.SelectedOptionsJson))
                    .ToList();
            }
        }

        var usedIds = cartItems.Select(item => item.ProductId).ToHashSet();

        List<ProductCardViewModel> savedForLater;
        List<ProductCardViewModel> favorites;

        if (!string.IsNullOrWhiteSpace(userId))
        {
            var savedDtos = await _savedForLaterService.GetSavedItemsAsync(userId);
            savedForLater = savedDtos.Select(dto => new ProductCardViewModel
            {
                ProductId = dto.ProductId,
                Name = dto.Name,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                Price = dto.Price,
                InStock = dto.InStock,
                Rating = dto.Rating,
                VariantKey = dto.VariantKey
            }).ToList();

            var favoriteDtos = await _favoritesService.GetFavoritesAsync(userId);
            favorites = favoriteDtos.Select(dto => new ProductCardViewModel
            {
                ProductId = dto.ProductId,
                Name = dto.Name,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                Price = dto.Price,
                InStock = dto.InStock,
                Rating = dto.Rating,
                VariantKey = dto.VariantKey
            }).ToList();
        }
        else
        {
            var localSaved = GetLocalSavedForLater();
            var localFavoriteIds = GetLocalFavorites();
            var lookupIds = localSaved.Select(x => x.ProductId)
                .Concat(localFavoriteIds)
                .Distinct()
                .ToList();

            var lookupProducts = lookupIds.Count == 0
                ? new Dictionary<int, Product>()
                : await _context.Products
                    .Where(p => lookupIds.Contains(p.Id))
                    .Include(p => p.Images)
                    .AsNoTracking()
                    .ToDictionaryAsync(p => p.Id);

            savedForLater = localSaved
                .Where(item => lookupProducts.ContainsKey(item.ProductId))
                .Select(item =>
                {
                    var card = BuildProductCard(lookupProducts[item.ProductId]);
                    card.VariantKey = item.VariantKey;
                    return card;
                })
                .ToList();

            favorites = localFavoriteIds
                .Where(id => lookupProducts.ContainsKey(id))
                .Select(id => BuildProductCard(lookupProducts[id]))
                .OrderBy(product => product.Name)
                .ToList();
        }

        usedIds.UnionWith(savedForLater.Select(item => item.ProductId));
        usedIds.UnionWith(favorites.Select(item => item.ProductId));

        var recommendations = await _context.Products
            .Where(product => !usedIds.Contains(product.Id))
            .OrderByDescending(product => product.Id)
            .Take(6)
            .Include(p => p.Images)
            .AsNoTracking()
            .Select(product => new ProductCardViewModel
            {
                ProductId = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.Images.OrderBy(i => i.SortOrder).Select(i => i.ImageUrl).FirstOrDefault() ?? product.ImageUrl,
                Price = (decimal)product.Price,
                InStock = product.Variants.Sum(v => v.Quantity) > 0 || !product.Variants.Any(),
                Rating = 4.2 + ((product.Id % 7) * 0.1)
            })
            .ToListAsync();

        var viewModel = new ShoppingCartViewModel
        {
            CartItems = cartItems,
            SavedForLater = savedForLater,
            Favorites = favorites,
            Recommendations = recommendations,
            IsSignedIn = User.Identity?.IsAuthenticated == true
        };

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Add(string? returnUrl = null)
    {
        if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
        {
            return LocalRedirect(returnUrl);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(int productId, int quantity = 1, string? selectedOptionsJson = null, string? returnUrl = null)
    {
        if (quantity < 1)
        {
            quantity = 1;
        }

        var product = await _context.Products
            .Include(p => p.Variants)
            .ThenInclude(v => v.VariantValues)
            .ThenInclude(vv => vv.PropertyDefinition)
            .FirstOrDefaultAsync(p => p.Id == productId);

        if (product is null)
        {
            return NotFound();
        }

        var selectedOptions = ParseOptions(selectedOptionsJson);
        var resolvedOptions = ResolveVariantOptions(product, selectedOptions);
        var variantKey = BuildVariantKey(resolvedOptions);
        var optionsJson = JsonSerializer.Serialize(resolvedOptions);

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userId))
        {
            AddToLocalCart(productId, quantity, variantKey, optionsJson);
        }
        else
        {
            var existing = await _context.CartItems
                .FirstOrDefaultAsync(ci =>
                    ci.UserId == userId &&
                    ci.ProductId == productId &&
                    (ci.VariantKey ?? "Default") == variantKey);

            if (existing is null)
            {
                _context.CartItems.Add(new CartItem
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = quantity,
                    VariantKey = variantKey,
                    SelectedOptionsJson = optionsJson
                });
            }
            else
            {
                existing.Quantity += quantity;
                existing.VariantKey = variantKey;
                existing.SelectedOptionsJson = optionsJson;
            }

            await _context.SaveChangesAsync();
        }

        if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
        {
            return LocalRedirect(returnUrl);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int productId, string? variantKey = null)
    {
        var normalizedVariantKey = string.IsNullOrWhiteSpace(variantKey) ? "Default" : variantKey.Trim();
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrWhiteSpace(userId))
        {
            var localCart = GetLocalCart();
            var line = localCart.FirstOrDefault(item =>
                item.ProductId == productId &&
                item.VariantKey == normalizedVariantKey);

            if (line is not null)
            {
                localCart.Remove(line);
                SaveLocalCart(localCart);
            }
        }
        else
        {
            var existing = await _context.CartItems.FirstOrDefaultAsync(ci =>
                ci.UserId == userId &&
                ci.ProductId == productId &&
                (ci.VariantKey ?? "Default") == normalizedVariantKey);

            if (existing is not null)
            {
                _context.CartItems.Remove(existing);
                await _context.SaveChangesAsync();
            }
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SaveForLater(int productId, string? variantKey = null)
    {
        var normalizedVariantKey = string.IsNullOrWhiteSpace(variantKey) ? "Default" : variantKey.Trim();
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrWhiteSpace(userId))
        {
            var localCart = GetLocalCart();
            var localItem = localCart.FirstOrDefault(item =>
                item.ProductId == productId &&
                item.VariantKey == normalizedVariantKey);

            if (localItem is null)
            {
                return RedirectToAction(nameof(Index));
            }

            localCart.Remove(localItem);
            SaveLocalCart(localCart);

            var localSaved = GetLocalSavedForLater();
            var existing = localSaved.FirstOrDefault(item =>
                item.ProductId == localItem.ProductId &&
                item.VariantKey == localItem.VariantKey);

            if (existing is null)
            {
                localSaved.Add(localItem);
            }
            else
            {
                existing.Quantity += localItem.Quantity;
                existing.SelectedOptionsJson = localItem.SelectedOptionsJson;
            }

            SaveLocalSavedForLater(localSaved);
            return RedirectToAction(nameof(Index));
        }

        var cartItem = await _context.CartItems.FirstOrDefaultAsync(ci =>
            ci.UserId == userId &&
            ci.ProductId == productId &&
            (ci.VariantKey ?? "Default") == normalizedVariantKey);

        if (cartItem is null)
        {
            return RedirectToAction(nameof(Index));
        }

        await _savedForLaterService.SaveAsync(userId, cartItem.ProductId, cartItem.Quantity, cartItem.VariantKey, cartItem.SelectedOptionsJson);

        _context.CartItems.Remove(cartItem);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> MoveSavedToCart(int productId, string? variantKey = null)
    {
        var normalizedVariantKey = string.IsNullOrWhiteSpace(variantKey) ? "Default" : variantKey.Trim();
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userId))
        {
            var localSaved = GetLocalSavedForLater();
            var savedItem = localSaved.FirstOrDefault(item =>
                item.ProductId == productId &&
                item.VariantKey == normalizedVariantKey);

            if (savedItem is not null)
            {
                localSaved.Remove(savedItem);
                SaveLocalSavedForLater(localSaved);
                AddToLocalCart(savedItem.ProductId, savedItem.Quantity, savedItem.VariantKey, savedItem.SelectedOptionsJson);
            }

            return RedirectToAction(nameof(Index));
        }

        await _savedForLaterService.MoveToCartAsync(userId, productId, variantKey);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteSaved(int productId, string? variantKey = null)
    {
        var normalizedVariantKey = string.IsNullOrWhiteSpace(variantKey) ? "Default" : variantKey.Trim();
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userId))
        {
            var localSaved = GetLocalSavedForLater();
            var removed = localSaved.RemoveAll(item =>
                item.ProductId == productId &&
                item.VariantKey == normalizedVariantKey);

            if (removed > 0)
            {
                SaveLocalSavedForLater(localSaved);
            }

            return RedirectToAction(nameof(Index));
        }

        await _savedForLaterService.RemoveAsync(userId, productId, variantKey);
        return RedirectToAction(nameof(Index));
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
                var lines = JsonSerializer.Deserialize<List<LocalCartLine>>(raw) ?? new List<LocalCartLine>();
                return lines.Select(NormalizeLocalLine).ToList();
            }

            var oldFormat = JsonSerializer.Deserialize<Dictionary<int, int>>(raw) ?? new Dictionary<int, int>();
            return oldFormat.Select(kv => new LocalCartLine
            {
                ProductId = kv.Key,
                Quantity = kv.Value,
                VariantKey = "Default",
                SelectedOptionsJson = JsonSerializer.Serialize(new Dictionary<string, string>())
            }).ToList();
        }
        catch
        {
            return new List<LocalCartLine>();
        }
    }

    private static LocalCartLine NormalizeLocalLine(LocalCartLine line)
    {
        if (!string.IsNullOrWhiteSpace(line.VariantKey) && !string.IsNullOrWhiteSpace(line.SelectedOptionsJson))
        {
            line.VariantKey = line.VariantKey.Trim();
            return line;
        }

        var options = ParseOptions(line.SelectedOptionsJson);

        line.VariantKey = BuildVariantKey(options);
        line.SelectedOptionsJson = JsonSerializer.Serialize(options);
        return line;
    }


    private List<LocalCartLine> GetLocalSavedForLater()
    {
        var raw = HttpContext.Session.GetString(LocalSavedForLaterSessionKey);

        if (string.IsNullOrWhiteSpace(raw))
        {
            return new List<LocalCartLine>();
        }

        try
        {
            var lines = JsonSerializer.Deserialize<List<LocalCartLine>>(raw) ?? new List<LocalCartLine>();
            return lines.Select(NormalizeLocalLine).ToList();
        }
        catch
        {
            return new List<LocalCartLine>();
        }
    }

    private void SaveLocalSavedForLater(List<LocalCartLine> localSaved)
    {
        if (localSaved.Count == 0)
        {
            HttpContext.Session.Remove(LocalSavedForLaterSessionKey);
            return;
        }

        HttpContext.Session.SetString(LocalSavedForLaterSessionKey, JsonSerializer.Serialize(localSaved));
    }

    private void SaveLocalCart(List<LocalCartLine> localCart)
    {
        if (localCart.Count == 0)
        {
            HttpContext.Session.Remove(LocalCartSessionKey);
            return;
        }

        HttpContext.Session.SetString(LocalCartSessionKey, JsonSerializer.Serialize(localCart));
    }

    private void AddToLocalCart(int productId, int quantity, string variantKey, string selectedOptionsJson)
    {
        var localCart = GetLocalCart();

        var line = localCart.FirstOrDefault(item =>
            item.ProductId == productId &&
            item.VariantKey == variantKey);

        if (line is null)
        {
            localCart.Add(new LocalCartLine
            {
                ProductId = productId,
                Quantity = quantity,
                VariantKey = variantKey,
                SelectedOptionsJson = selectedOptionsJson
            });
        }
        else
        {
            line.Quantity += quantity;
            line.SelectedOptionsJson = selectedOptionsJson;
        }

        SaveLocalCart(localCart);
    }

    private async Task MergeLocalCartIntoUserCartAsync(string userId)
    {
        var localCart = GetLocalCart();
        if (localCart.Count == 0)
        {
            return;
        }

        var productIds = localCart.Select(item => item.ProductId).Distinct().ToList();
        var existingRows = await _context.CartItems
            .Where(ci => ci.UserId == userId && productIds.Contains(ci.ProductId))
            .ToListAsync();

        foreach (var item in localCart)
        {
            var row = existingRows.FirstOrDefault(ci =>
                ci.ProductId == item.ProductId &&
                (ci.VariantKey ?? "Default") == item.VariantKey);

            if (row is null)
            {
                _context.CartItems.Add(new CartItem
                {
                    UserId = userId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    VariantKey = item.VariantKey,
                    SelectedOptionsJson = item.SelectedOptionsJson
                });
            }
            else
            {
                row.Quantity += item.Quantity;
                row.VariantKey = item.VariantKey;
                row.SelectedOptionsJson = item.SelectedOptionsJson;
            }
        }

        await _context.SaveChangesAsync();
        HttpContext.Session.Remove(LocalCartSessionKey);
    }

    private List<int> GetLocalFavorites()
    {
        var raw = HttpContext.Session.GetString(LocalFavoritesSessionKey);

        if (string.IsNullOrWhiteSpace(raw))
        {
            raw = HttpContext.Session.GetString("FavoriteProductIds");
        }
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
        HttpContext.Session.Remove("FavoriteProductIds");
    }
    private async Task MergeLocalSavedIntoUserSavedAsync(string userId)
    {
        var localSaved = GetLocalSavedForLater();
        if (localSaved.Count == 0)
        {
            return;
        }

        foreach (var item in localSaved)
        {
            await _savedForLaterService.SaveAsync(userId, item.ProductId, item.Quantity, item.VariantKey, item.SelectedOptionsJson);
        }

        HttpContext.Session.Remove(LocalSavedForLaterSessionKey);
    }

    private static Dictionary<string, string> ParseOptions(string? selectedOptionsJson)
    {
        if (string.IsNullOrWhiteSpace(selectedOptionsJson))
        {
            return new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }

        try
        {
            var parsed = JsonSerializer.Deserialize<Dictionary<string, string>>(selectedOptionsJson)
                         ?? new Dictionary<string, string>();

            return parsed
                .Where(kv => !string.IsNullOrWhiteSpace(kv.Key) && !string.IsNullOrWhiteSpace(kv.Value))
                .ToDictionary(kv => kv.Key.Trim(), kv => kv.Value.Trim(), StringComparer.OrdinalIgnoreCase);
        }
        catch
        {
            return new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }
    }

    private static Dictionary<string, string> ResolveVariantOptions(Product product, Dictionary<string, string> selectedOptions)
    {
        if (!product.Variants.Any())
        {
            return selectedOptions;
        }

        ProductVariant? matchedVariant = product.Variants.FirstOrDefault(variant =>
        {
            var values = GetVariantOptions(variant);
            if (selectedOptions.Count == 0)
            {
                return true;
            }

            return selectedOptions.All(sel =>
                values.TryGetValue(sel.Key, out var variantValue) &&
                string.Equals(variantValue, sel.Value, StringComparison.OrdinalIgnoreCase));
        });

        matchedVariant ??= product.Variants.FirstOrDefault();
        return matchedVariant is null ? selectedOptions : GetVariantOptions(matchedVariant);
    }

    private static Dictionary<string, string> GetVariantOptions(ProductVariant variant)
    {
        return variant.VariantValues
            .Where(v => !string.IsNullOrWhiteSpace(v.PropertyDefinition?.Name) && !string.IsNullOrWhiteSpace(v.Value))
            .ToDictionary(v => v.PropertyDefinition!.Name, v => v.Value, StringComparer.OrdinalIgnoreCase);
    }

    private static string BuildVariantKey(Dictionary<string, string> options)
    {
        if (options.Count == 0)
        {
            return "Default";
        }

        return string.Join("|", options
            .OrderBy(kv => kv.Key, StringComparer.OrdinalIgnoreCase)
            .Select(kv => $"{kv.Key}:{kv.Value}"));
    }

    private static CartProductViewModel BuildCartItem(Product product, int quantity, string? variantKey, string? selectedOptionsJson)
    {
        var options = ParseOptions(selectedOptionsJson);

        if (options.Count == 0)
        {
            var fallbackVariant = product.Variants.FirstOrDefault();
            if (fallbackVariant is not null)
            {
                options = GetVariantOptions(fallbackVariant);
            }
        }

        var imageUrl = product.Images.OrderBy(i => i.SortOrder).FirstOrDefault()?.ImageUrl ?? product.ImageUrl;

        return new CartProductViewModel
        {
            ProductId = product.Id,
            Name = product.Name,
            Quantity = quantity,
            UnitPrice = (decimal)product.Price,
            VariantKey = string.IsNullOrWhiteSpace(variantKey) ? BuildVariantKey(options) : variantKey,
            Attributes = options
                .OrderBy(kv => kv.Key, StringComparer.OrdinalIgnoreCase)
                .Select(kv => new CartAttributeViewModel
                {
                    Name = kv.Key,
                    Value = kv.Value
                })
                .ToList(),
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

    private sealed class LocalCartLine
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string VariantKey { get; set; } = "Default";
        public string SelectedOptionsJson { get; set; } = "{}";

    }
}
