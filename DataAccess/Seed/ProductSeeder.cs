using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistance
{
    public static class ProductSeeder
    {
        public static List<Product> GetProducts()
        {
            return new List<Product>
            {
                //Lifestyle Products
                new Product
                {
                    Id = 1,
                    Name = "Men's Casual T-Shirt",
                    Description = "Comfortable cotton t-shirt for everyday wear.",
                    Price = 19.99,
                    ImageUrl = "/images/products/tshirt.jpg",
                    CategoryId = 6 // Clothing
                },
                new Product
                {
                    Id = 2,
                    Name = "Running Sneakers",
                    Description = "Lightweight running shoes with breathable material.",
                    Price = 89.99,
                    ImageUrl = "/images/products/sneakers.jpg",
                    CategoryId = 7 // Shoes
                },

                //Technology Products
                new Product
                {
                    Id = 3,
                    Name = "Apple MacBook Air M2",
                    Description = "13-inch laptop with Apple M2 chip and 16GB RAM.",
                    Price = 1499.99,
                    ImageUrl = "/images/products/macbook_air_m2.jpg",
                    CategoryId = 8 // Computers / Laptops / Tablets
                },
                new Product
                {
                    Id = 4,
                    Name = "Samsung Galaxy S24",
                    Description = "Flagship smartphone with advanced camera system.",
                    Price = 999.99,
                    ImageUrl = "/images/products/galaxy_s24.jpg",
                    CategoryId = 9 // Mobile Phones
                },
                new Product
                {
                    Id = 5,
                    Name = "Sony WH-1000XM5",
                    Description = "Noise-cancelling wireless headphones.",
                    Price = 399.99,
                    ImageUrl = "/images/products/sony_xm5.jpg",
                    CategoryId = 10 // Audio and Wearables
                },
                new Product
                {
                    Id = 6,
                    Name = "Canon EOS R10",
                    Description = "Mirrorless camera for photography enthusiasts.",
                    Price = 979.99,
                    ImageUrl = "/images/products/canon_r10.jpg",
                    CategoryId = 11 // Cameras / Photo Equipment
                },
                new Product
                {
                    Id = 7,
                    Name = "PlayStation 5",
                    Description = "Next-gen gaming console from Sony.",
                    Price = 549.99,
                    ImageUrl = "/images/products/ps5.jpg",
                    CategoryId = 12 // Gaming
                },

                //Home Products
                new Product
                {
                    Id = 8,
                    Name = "Modern Wall Clock",
                    Description = "Minimalist wall clock for home decor.",
                    Price = 39.99,
                    ImageUrl = "/images/products/wall_clock.jpg",
                    CategoryId = 13 // Home Decor
                },
                new Product
                {
                    Id = 9,
                    Name = "Wooden Dining Table",
                    Description = "Solid wood dining table for family meals.",
                    Price = 799.99,
                    ImageUrl = "/images/products/dining_table.jpg",
                    CategoryId = 14 // Furniture
                },
                new Product
                {
                    Id = 10,
                    Name = "LED Desk Lamp",
                    Description = "Energy-efficient LED lamp with adjustable brightness.",
                    Price = 49.99,
                    ImageUrl = "/images/products/desk_lamp.jpg",
                    CategoryId = 15 // Lighting
                },
                new Product
                {
                    Id = 11,
                    Name = "Garden Tool Set",
                    Description = "Complete set of tools for gardening tasks.",
                    Price = 59.99,
                    ImageUrl = "/images/products/garden_tools.jpg",
                    CategoryId = 16 // Yard and Garden
                },
                new Product
                {
                    Id = 12,
                    Name = "Electric Drill",
                    Description = "Powerful electric drill for home improvement.",
                    Price = 129.99,
                    ImageUrl = "/images/products/drill.jpg",
                    CategoryId = 17 // Tools / Hardware / Plumbing
                },
                new Product
                {
                    Id = 13,
                    Name = "Concrete Mix",
                    Description = "High-quality concrete mix for construction.",
                    Price = 14.99,
                    ImageUrl = "/images/products/concrete.jpg",
                    CategoryId = 18 // Building Materials
                },

                //Auto Products
                new Product
                {
                    Id = 14,
                    Name = "Fitness Dumbbells Set",
                    Description = "Adjustable dumbbell set for home workouts.",
                    Price = 119.99,
                    ImageUrl = "/images/products/dumbbells.jpg",
                    CategoryId = 19 // Sports / Outdoor / Fitness
                },
                new Product
                {
                    Id = 15,
                    Name = "Car Phone Holder",
                    Description = "Universal phone holder for car dashboards.",
                    Price = 24.99,
                    ImageUrl = "/images/products/car_holder.jpg",
                    CategoryId = 20 // Auto Parts / Accessories
                },

                //Health Products
                new Product
                {
                    Id = 16,
                    Name = "Kids Building Blocks",
                    Description = "Educational toy set for kids.",
                    Price = 34.99,
                    ImageUrl = "/images/products/blocks.jpg",
                    CategoryId = 21 // Toys Kids
                },
                new Product
                {
                    Id = 17,
                    Name = "C# Programming Book",
                    Description = "Comprehensive guide to C# and .NET development.",
                    Price = 44.99,
                    ImageUrl = "/images/products/csharp_book.jpg",
                    CategoryId = 22 // Books / Media
                },
                new Product
                {
                    Id = 18,
                    Name = "Vitamin C Tablets",
                    Description = "Dietary supplement to support immunity.",
                    Price = 14.99,
                    ImageUrl = "/images/products/vitamin_c.jpg",
                    CategoryId = 23 // Health
                }
            };
        }
    }
}
