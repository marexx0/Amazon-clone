using System.Collections.Generic;

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
        public string Brand { get; set; }
    }
}