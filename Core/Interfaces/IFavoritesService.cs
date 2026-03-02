using Core.Dtos;

namespace Core.Interfaces;

public interface IFavoritesService
{
    Task<IReadOnlyList<ProductCardDto>> GetFavoritesAsync(string userId);
    Task<bool> AddAsync(string userId, int productId);
    Task<bool> RemoveAsync(string userId, int productId);
}