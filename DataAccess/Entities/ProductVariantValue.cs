public class ProductVariantValue
{
    public int Id { get; set; }

    public int ProductVariantId { get; set; }
    public ProductVariant ProductVariant { get; set; }

    public int? PropertyDefinitionId { get; set; }
    public PropertyDefinition? PropertyDefinition { get; set; }

    // The value for this variant along this dimension (e.g. "44", "White")
    public string? Value { get; set; }
}

