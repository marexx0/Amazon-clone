using Web_Api_Amazon.Entities;
public class ProductVariant
{
    public int Id { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }

    // How many items you have for this specific combination
    public int Quantity { get; set; }

    // Which property values define this variant
    public ICollection<ProductVariantValue>? VariantValues { get; set; }
    public string? Name { get; set; }
    public string? Value { get; set; }

}

