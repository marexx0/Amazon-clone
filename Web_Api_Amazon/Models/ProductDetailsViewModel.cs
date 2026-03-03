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
        public IReadOnlyList<ProductVariantOptionGroupViewModel> VariantOptionGroups { get; set; } = new List<ProductVariantOptionGroupViewModel>();
        public IReadOnlyList<ProductVariantSummaryViewModel> VariantSummaries { get; set; } = new List<ProductVariantSummaryViewModel>();
        public bool IsFavorite { get; set; }
    }

    public class ProductVariantOptionGroupViewModel
    {
        public string Name { get; set; } = string.Empty;
        public IReadOnlyList<string> Values { get; set; } = new List<string>();
        public bool IsColor { get; set; }
    }

    public class ProductVariantSummaryViewModel
    {
        public IReadOnlyDictionary<string, string> Options { get; set; } = new Dictionary<string, string>();
        public int Quantity { get; set; }
    }
}