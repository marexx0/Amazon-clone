using Core.Dtos;
using Core.Interfaces;
using Amazon_clone.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

public class SavedForLaterService : ISavedForLaterService
{
    private readonly ShopDbContext _context;

    public SavedForLaterService(ShopDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<ProductCardDto>> GetSavedItemsAsync(string userId)
    {
        return await _context.SavedForLaterItems
            .Where(item => item.UserId == userId)
            .OrderByDescending(item => item.CreatedAtUtc)
            .Select(item => new ProductCardDto
            {
                ProductId = item.Product.Id,
                Name = item.Product.Name,
                Description = item.Product.Description,
                ImageUrl = item.Product.Images.OrderBy(i => i.SortOrder).Select(i => i.ImageUrl).FirstOrDefault() ?? item.Product.ImageUrl,
                Price = (decimal)item.Product.Price,
                InStock = item.Product.Variants.Sum(v => v.Quantity) > 0 || !item.Product.Variants.Any(),
                Rating = 4.2 + ((item.Product.Id % 7) * 0.1),
                VariantKey = item.VariantKey
            })
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task SaveAsync(string userId, int productId, int quantity, string? variantKey, string? selectedOptionsJson)
    {
        var normalizedVariantKey = string.IsNullOrWhiteSpace(variantKey) ? "Default" : variantKey.Trim();
        var normalizedOptions = string.IsNullOrWhiteSpace(selectedOptionsJson) ? "{}" : selectedOptionsJson;
        var normalizedQuantity = quantity < 1 ? 1 : quantity;

        var existing = await _context.SavedForLaterItems.FirstOrDefaultAsync(item =>
            item.UserId == userId &&
            item.ProductId == productId &&
            item.VariantKey == normalizedVariantKey);

        if (existing is null)
        {
            _context.SavedForLaterItems.Add(new SavedForLaterItem
            {
                UserId = userId,
                ProductId = productId,
                Quantity = normalizedQuantity,
                VariantKey = normalizedVariantKey,
                SelectedOptionsJson = normalizedOptions,
                CreatedAtUtc = DateTime.UtcNow
            });
        }
        else
        {
            existing.Quantity = normalizedQuantity;
            existing.SelectedOptionsJson = normalizedOptions;
            existing.CreatedAtUtc = DateTime.UtcNow;
        }

        await _context.SaveChangesAsync();
    }

    public async Task<bool> RemoveAsync(string userId, int productId, string? variantKey)
    {
        var normalizedVariantKey = string.IsNullOrWhiteSpace(variantKey) ? "Default" : variantKey.Trim();

        var existing = await _context.SavedForLaterItems.FirstOrDefaultAsync(item =>
            item.UserId == userId &&
            item.ProductId == productId &&
            item.VariantKey == normalizedVariantKey);

        if (existing is null)
        {
            return false;
        }

        _context.SavedForLaterItems.Remove(existing);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> MoveToCartAsync(string userId, int productId, string? variantKey)
    {
        var normalizedVariantKey = string.IsNullOrWhiteSpace(variantKey) ? "Default" : variantKey.Trim();

        var savedItem = await _context.SavedForLaterItems.FirstOrDefaultAsync(item =>
            item.UserId == userId &&
            item.ProductId == productId &&
            item.VariantKey == normalizedVariantKey);

        if (savedItem is null)
        {
            return false;
        }

        var cartItem = await _context.CartItems.FirstOrDefaultAsync(ci =>
            ci.UserId == userId &&
            ci.ProductId == productId &&
            (ci.VariantKey ?? "Default") == normalizedVariantKey);

        if (cartItem is null)
        {
            _context.CartItems.Add(new CartItem
            {
                UserId = userId,
                ProductId = productId,
                Quantity = savedItem.Quantity,
                VariantKey = savedItem.VariantKey,
                SelectedOptionsJson = savedItem.SelectedOptionsJson
            });
        }
        else
        {
            cartItem.Quantity += savedItem.Quantity;
            cartItem.SelectedOptionsJson = savedItem.SelectedOptionsJson;
        }

        _context.SavedForLaterItems.Remove(savedItem);
        await _context.SaveChangesAsync();

        return true;
    }
}