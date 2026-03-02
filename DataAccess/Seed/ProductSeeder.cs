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
                                },
                new Product
                {
                    Id = 23,
                    Name = "Levi's 501 Original Fit Jeans",
                    Description = "Iconic straight-leg men's jeans made with non-stretch denim and button fly construction for a timeless everyday fit.",
                    Price = 59.50,
                    ImageUrl = "/images/products/levis_501.png",
                    CategoryId = 6
                },
                new Product
                {
                    Id = 24,
                    Name = "ASICS Gel-Kayano 30 Running Shoes",
                    Description = "Premium stability running shoe with FF BLAST PLUS ECO cushioning and 4D GUIDANCE SYSTEM support for long-distance comfort.",
                    Price = 159.95,
                    ImageUrl = "/images/products/asics_kayano_30.jpg",
                    CategoryId = 7
                },
                new Product
                {
                    Id = 25,
                    Name = "Dell XPS 13 Plus Laptop (13th Gen Intel, 16GB, 512GB)",
                    Description = "Compact aluminum ultrabook featuring a 13.4-inch InfinityEdge display, 13th Gen Intel Core processor, 16GB RAM and fast 512GB SSD.",
                    Price = 1399.99,
                    ImageUrl = "/images/products/dell_xps_13_plus.png",
                    CategoryId = 8
                },
                new Product
                {
                    Id = 26,
                    Name = "Google Pixel 8 Pro Unlocked Smartphone",
                    Description = "Google flagship phone with advanced AI camera tools, 6.7-inch Super Actua display and all-day battery life.",
                    Price = 999.00,
                    ImageUrl = "/images/products/pixel_8_pro.png",
                    CategoryId = 9
                },
                new Product
                {
                    Id = 27,
                    Name = "Apple Watch Series 9 GPS 45mm",
                    Description = "Advanced smartwatch with bright Always-On Retina display, health sensors, workout tracking, and seamless iPhone integration.",
                    Price = 429.00,
                    ImageUrl = "/images/products/apple_watch_series_9.jpg",
                    CategoryId = 10
                },
                new Product
                {
                    Id = 28,
                    Name = "Nikon Z6 II Mirrorless Camera Body",
                    Description = "Full-frame mirrorless camera with dual EXPEED 6 processors, robust autofocus, and strong low-light image quality.",
                    Price = 1996.95,
                    ImageUrl = "/images/products/nikon_z6_ii.png",
                    CategoryId = 11
                },
                new Product
                {
                    Id = 29,
                    Name = "Xbox Series X Console",
                    Description = "Microsoft's most powerful Xbox with 1TB SSD, 4K gaming support, and quick resume across multiple games.",
                    Price = 499.99,
                    ImageUrl = "/images/products/xbox_series_x.png",
                    CategoryId = 12
                },
                new Product
                {
                    Id = 30,
                    Name = "IKEA MALM 6-Drawer Dresser",
                    Description = "Minimalist bedroom dresser with six smooth-glide drawers and a clean Scandinavian profile suitable for modern spaces.",
                    Price = 279.00,
                    ImageUrl = "/images/products/malm_dresser.png",
                    CategoryId = 14
                },
                new Product
                {
                    Id = 31,
                    Name = "Bosch 12V Max Cordless Drill Driver Kit",
                    Description = "Compact cordless drill/driver kit with two-speed transmission, 12V lithium-ion batteries, and durable carrying case.",
                    Price = 129.00,
                    ImageUrl = "/images/products/bosch_12v_drill.png",
                    CategoryId = 17
                },
                new Product
                {
                    Id = 32,
                    Name = "LEGO Classic Medium Creative Brick Box 10696",
                    Description = "Creative building set with mixed LEGO bricks, wheels, and windows designed to inspire open-ended play for kids.",
                    Price = 29.99,
                    ImageUrl = "/images/products/lego_10696.png",
                    CategoryId = 21
                }
            };
        }
    }
}
