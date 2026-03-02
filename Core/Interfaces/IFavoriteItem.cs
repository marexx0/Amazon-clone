
public interface IFavoriteItem
{
    int Id { get; set; }
    string UserId { get; set; }
    int ProductId { get; set; }
    DateTime CreatedAtUtc { get; set; }
}