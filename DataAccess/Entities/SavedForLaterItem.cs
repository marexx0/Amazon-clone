public class SavedForLaterItem : ISavedForLaterItem
{
    public int Id { get; set; }

    public string UserId { get; set; }
    public User User { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int Quantity { get; set; } = 1;
    public string VariantKey { get; set; } = "Default";
    public string SelectedOptionsJson { get; set; } = "{}";

    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
}