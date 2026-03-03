using Core.Dtos;
using Core.Interfaces;
using Amazon_clone.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

public class FavoritesService : IFavoritesService
{
    private readonly ShopDbContext _context;
    private readonly IMemoryCache _cache;

    public FavoritesService(ShopDbContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }

    private static string BuildFavoritesCacheKey(string userId) => $"favorites:list:{userId}";

    public async Task<IReadOnlyList<ProductCardDto>> GetFavoritesAsync(string userId)
    {
        var cacheKey = BuildFavoritesCacheKey(userId);
        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(45);

            return await _context.FavoriteItems
                .Where(fi => fi.UserId == userId)
                .OrderByDescending(fi => fi.CreatedAtUtc)
                .Select(fi => new ProductCardDto
                {
                    ProductId = fi.Product.Id,
                    Name = fi.Product.Name,
                    Description = fi.Product.Description,
                    ImageUrl = fi.Product.Images.OrderBy(i => i.SortOrder).Select(i => i.ImageUrl).FirstOrDefault() ?? fi.Product.ImageUrl,
                    Price = (decimal)fi.Product.Price,
                    InStock = fi.Product.Variants.Sum(v => v.Quantity) > 0 || !fi.Product.Variants.Any(),
                    Rating = 4.2 + ((fi.Product.Id % 7) * 0.1)
                })
                .AsNoTracking()
                .ToListAsync();
        }) ?? new List<ProductCardDto>();
    }

    public Task<bool> IsFavoriteAsync(string userId, int productId)
    {
        return _context.FavoriteItems
            .AsNoTracking()
            .AnyAsync(fi => fi.UserId == userId && fi.ProductId == productId);
    }

    public async Task<bool> AddAsync(string userId, int productId)
    {
        var exists = await _context.FavoriteItems
            .AnyAsync(fi => fi.UserId == userId && fi.ProductId == productId);

        if (exists)
        {
            return false;
        }

        _context.FavoriteItems.Add(new FavoriteItem
        {
            UserId = userId,
            ProductId = productId,
            CreatedAtUtc = DateTime.UtcNow
        });

        await _context.SaveChangesAsync();
        _cache.Remove(BuildFavoritesCacheKey(userId));
        return true;
    }

    public async Task<bool> RemoveAsync(string userId, int productId)
    {
        var existing = await _context.FavoriteItems
            .FirstOrDefaultAsync(fi => fi.UserId == userId && fi.ProductId == productId);

        if (existing is null)
        {
            return false;
        }

        _context.FavoriteItems.Remove(existing);
        await _context.SaveChangesAsync();
        _cache.Remove(BuildFavoritesCacheKey(userId));
        return true;
    }
}