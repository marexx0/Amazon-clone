using System.Collections.Generic;
using Web_Api_Amazon.Entities;

namespace Web_Api_Amazon.Models
{
    public class ProductDetailsViewModel
    {
        public Product Product { get; set; }
        public IReadOnlyList<ProductImage> Images { get; set; } = new List<ProductImage>();
        public IReadOnlyList<Product> RelatedProducts { get; set; } = new List<Product>();
        public IReadOnlyList<Product> TopPicks { get; set; } = new List<Product>();
        public IReadOnlyList<string> AvailableColors { get; set; } = new List<string>();
        public IReadOnlyList<string> AvailableSizes { get; set; } = new List<string>();
        public IReadOnlyList<ProductVariantSummaryViewModel> VariantSummaries { get; set; } = new List<ProductVariantSummaryViewModel>();
        public bool IsFavorite { get; set; }
    }

    public class ProductVariantSummaryViewModel
    {
        public string Size { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}