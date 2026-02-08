public class PropertyDefinition
{
    public int Id { get; set; }

    // e.g. "Size", "Color", "Brand"
    public string Name { get; set; }

    public PropertyDataType DataType { get; set; }

    // Optional: helps UI group / display (e.g. "General", "Technical")
    public string? GroupName { get; set; }

    // Many categories can use same property
    public ICollection<CategoryProperty> CategoryProperties { get; set; }

    // Many products can have a value for this property
    public ICollection<ProductProperty> ProductProperties { get; set; }
}

