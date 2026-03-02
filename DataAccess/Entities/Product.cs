public class Product
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }

    public double Price { get; set; }

    public string ImageUrl { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public ICollection<CartItem> CartItems { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
    public ICollection<FavoriteItem> FavoriteItems { get; set; }
    public ICollection<SavedForLaterItem> SavedForLaterItems { get; set; }

    public ICollection<ProductProperty> Properties { get; set; }

    public ICollection<ProductVariant> Variants { get; set; }

    public ICollection<ProductImage> Images { get; set; }
}
