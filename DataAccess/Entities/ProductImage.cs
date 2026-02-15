public class ProductImage
{
    public int Id { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }

    public string FileName { get; set; }
    public string ContentType { get; set; }
    public string ImageUrl { get; set; }
    public byte[] ImageData { get; set; }

    public bool IsPrimary { get; set; }
    public int SortOrder { get; set; }
}