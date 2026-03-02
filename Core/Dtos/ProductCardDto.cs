namespace Core.Dtos;

public class ProductCardDto
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public decimal Price { get; set; }
    public bool InStock { get; set; }
    public double Rating { get; set; }
    public string VariantKey { get; set; } = "Default";
}