using System.Collections.Generic;
using Web_Api_Amazon.Entities;
using System.Collections.Generic;

namespace DataAccess.Persistance
{
    public static class ProductSeeder
    {
        public static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Amazon Essentials Men's Short-Sleeve Crewneck T-Shirt",
                    Description = "Amazon Essentials men's short-sleeve crewneck t-shirt in soft jersey knit.",
                    Price = 18.99,
                    ImageUrl = "/images/products/tshirt.png",
                    CategoryId = 6
                },
                new Product
                {
                    Id = 2,
                    Name = "adidas Men's Grand Court 2.0 Sneakers",
                    Description = "adidas Grand Court 2.0 sneakers with a synthetic leather upper and rubber outsole.",
                    Price = 69.99,
                    ImageUrl = "/images/products/5_600.png",
                    CategoryId = 7
                },
                new Product
                {
                    Id = 3,
                    Name = "Apple MacBook Air 13-inch Laptop (M2, 8GB, 256GB)",
                    Description = "Apple MacBook Air 13-inch laptop with M2 chip, 8GB RAM, and 256GB SSD storage.",
                    Price = 1099.00,
                    ImageUrl = "/images/products/macbook.jfif",
                    CategoryId = 8
                },
                new Product
                {
                    Id = 4,
                    Name = "Samsung Galaxy S24 Unlocked Smartphone",
                    Description = "Samsung Galaxy S24 unlocked smartphone with advanced camera system.",
                    Price = 799.99,
                    ImageUrl = "/images/productsphone1.jfif",
                    CategoryId = 9
                },
                new Product
                {
                    Id = 5,
                    Name = "Sony WH-1000XM5 Wireless Noise Canceling Headphones",
                    Description = "Sony WH-1000XM5 wireless noise canceling headphones with premium sound.",
                    Price = 398.00,
                    ImageUrl = "/images/products/headphones.jfif",
                    CategoryId = 10
                },
                new Product
                {
                    Id = 6,
                    Name = "Canon EOS R10 Mirrorless Camera with RF-S 18-45mm Lens",
                    Description = "Canon EOS R10 mirrorless camera kit with RF-S 18-45mm lens for versatile shooting.",
                    Price = 999.00,
                    ImageUrl = "/images/products/canon_.jpg",
                    CategoryId = 11
                },
                new Product
                {
                    Id = 7,
                    Name = "PlayStation 5 Console",
                    Description = "PlayStation 5 console for next-gen gaming with ultra-high-speed SSD.",
                    Price = 499.99,
                    ImageUrl = "/images/products/play.jfif",
                    CategoryId = 12
                },
                new Product
                {
                    Id = 22,
                    Name = "Nike Dunk Low Retro - Cacao Wow",
                    Description = "Classic low-top silhouette with leather overlays, padded collar comfort, and durable rubber traction for daily wear.",
                    Price = 129.99,
                    ImageUrl = "/images/products/nike_dunk_cacao_pair.jpg",
                    CategoryId = 7
                }
                
            };
        }
    }
}