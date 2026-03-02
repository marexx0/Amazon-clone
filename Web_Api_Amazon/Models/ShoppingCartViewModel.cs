using System.Linq;
using System.Collections.Generic;

namespace Web_Api_Amazon.Models;

public class ShoppingCartViewModel
{
    public List<CartProductViewModel> CartItems { get; set; } = new();
    public List<ProductCardViewModel> SavedForLater { get; set; } = new();
    public List<ProductCardViewModel> Favorites { get; set; } = new();
    public List<ProductCardViewModel> Recommendations { get; set; } = new();
    public bool IsSignedIn { get; set; }

    public decimal Subtotal => CartItems.Sum(item => item.TotalPrice);
    public decimal Shipping => 0m;
    public decimal Total => Subtotal + Shipping;
}

public class CartProductViewModel
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public string VariantKey { get; set; } = "Default";
    public List<CartAttributeViewModel> Attributes { get; set; } = new();
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public bool InStock { get; set; }
    public decimal TotalPrice => UnitPrice * Quantity;
}

public class ProductCardViewModel
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
public class CartAttributeViewModel
{
    public string Name { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}
