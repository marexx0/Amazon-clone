public interface ISavedForLaterItem
{
    int Id { get; set; }
    string UserId { get; set; }
    int ProductId { get; set; }
    int Quantity { get; set; }
    string VariantKey { get; set; }
    string SelectedOptionsJson { get; set; }
    DateTime CreatedAtUtc { get; set; }
}