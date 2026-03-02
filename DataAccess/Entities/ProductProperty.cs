using Web_Api_Amazon.Entities;
public class ProductProperty
{
    public int Id { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }

    public int? PropertyDefinitionId { get; set; }
    public PropertyDefinition? PropertyDefinition { get; set; }

    public string? Name { get; set; }
    public string? Value { get; set; }
}

