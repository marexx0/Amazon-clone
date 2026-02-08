public class CategoryProperty
{
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public int PropertyDefinitionId { get; set; }
    public PropertyDefinition PropertyDefinition { get; set; }

    // True if every product in this category should have this property
    public bool IsRequired { get; set; }

    // True if this property is used as a selectable variant (e.g. Size, Color)
    public bool IsVariantOption { get; set; }
}

