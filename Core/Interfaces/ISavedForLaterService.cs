using Core.Dtos;

namespace Core.Interfaces;

public interface ISavedForLaterService
{
    Task<IReadOnlyList<ProductCardDto>> GetSavedItemsAsync(string userId);
    Task SaveAsync(string userId, int productId, int quantity, string? variantKey, string? selectedOptionsJson);
    Task<bool> RemoveAsync(string userId, int productId, string? variantKey);
    Task<bool> MoveToCartAsync(string userId, int productId, string? variantKey);
}