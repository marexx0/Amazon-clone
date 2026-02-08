using System.Collections.Generic;

namespace DataAccess.Persistance
{
    public static class PropertySeeder
    {
        public static List<PropertyDefinition> GetPropertyDefinitions()
        {
            return new List<PropertyDefinition>
            {
                new PropertyDefinition { Id = 1, Name = "Brand", DataType = PropertyDataType.Text, GroupName = "General" },
                new PropertyDefinition { Id = 2, Name = "Color", DataType = PropertyDataType.Text, GroupName = "Variant" },
                new PropertyDefinition { Id = 3, Name = "Size", DataType = PropertyDataType.Text, GroupName = "Variant" }
            };
        }

        public static List<CategoryProperty> GetCategoryProperties()
        {
            return new List<CategoryProperty>
            {
                // Clothing
                new CategoryProperty { CategoryId = 6, PropertyDefinitionId = 1, IsRequired = true, IsVariantOption = false }, // Brand
                new CategoryProperty { CategoryId = 6, PropertyDefinitionId = 2, IsRequired = false, IsVariantOption = true }, // Color
                new CategoryProperty { CategoryId = 6, PropertyDefinitionId = 3, IsRequired = false, IsVariantOption = true }, // Size

                // Shoes
                new CategoryProperty { CategoryId = 7, PropertyDefinitionId = 1, IsRequired = true, IsVariantOption = false }, // Brand
                new CategoryProperty { CategoryId = 7, PropertyDefinitionId = 2, IsRequired = false, IsVariantOption = true }, // Color
                new CategoryProperty { CategoryId = 7, PropertyDefinitionId = 3, IsRequired = false, IsVariantOption = true }, // Size

                // Other categories – just Brand for now
                new CategoryProperty { CategoryId = 8, PropertyDefinitionId = 1, IsRequired = true, IsVariantOption = false },
                new CategoryProperty { CategoryId = 9, PropertyDefinitionId = 1, IsRequired = true, IsVariantOption = false },
                new CategoryProperty { CategoryId = 10, PropertyDefinitionId = 1, IsRequired = true, IsVariantOption = false },
                new CategoryProperty { CategoryId = 11, PropertyDefinitionId = 1, IsRequired = true, IsVariantOption = false },
                new CategoryProperty { CategoryId = 12, PropertyDefinitionId = 1, IsRequired = true, IsVariantOption = false },
                new CategoryProperty { CategoryId = 13, PropertyDefinitionId = 1, IsRequired = true, IsVariantOption = false },
                new CategoryProperty { CategoryId = 14, PropertyDefinitionId = 1, IsRequired = true, IsVariantOption = false },
                new CategoryProperty { CategoryId = 15, PropertyDefinitionId = 1, IsRequired = true, IsVariantOption = false },
                new CategoryProperty { CategoryId = 16, PropertyDefinitionId = 1, IsRequired = true, IsVariantOption = false },
                new CategoryProperty { CategoryId = 17, PropertyDefinitionId = 1, IsRequired = true, IsVariantOption = false },
                new CategoryProperty { CategoryId = 18, PropertyDefinitionId = 1, IsRequired = true, IsVariantOption = false },
                new CategoryProperty { CategoryId = 19, PropertyDefinitionId = 1, IsRequired = true, IsVariantOption = false },
                new CategoryProperty { CategoryId = 20, PropertyDefinitionId = 1, IsRequired = true, IsVariantOption = false },
                new CategoryProperty { CategoryId = 21, PropertyDefinitionId = 1, IsRequired = true, IsVariantOption = false },
                new CategoryProperty { CategoryId = 22, PropertyDefinitionId = 1, IsRequired = true, IsVariantOption = false },
                new CategoryProperty { CategoryId = 23, PropertyDefinitionId = 1, IsRequired = true, IsVariantOption = false }
            };
        }

        public static List<Product> GetProducts()
        {
            return new List<Product>
            {
                // Lifestyle Products
                new Product
                {
                    Id = 1,
                    Name = "Men's Casual T-Shirt",
                    Description = "Comfortable cotton t-shirt for everyday wear.",
                    Price = 19.99,
                    ImageUrl = "/images/products/tshirt.png",
                    CategoryId = 6
                },
                new Product
                {
                    Id = 2,
                    Name = "Running Sneakers",
                    Description = "Lightweight running shoes with breathable material.",
                    Price = 89.99,
                    ImageUrl = "/images/products/sneakers.png",
                    CategoryId = 7
                },

                // Technology Products
                new Product
                {
                    Id = 3,
                    Name = "Apple MacBook Air M2",
                    Description = "13-inch laptop with Apple M2 chip and 16GB RAM.",
                    Price = 1499.99,
                    ImageUrl = "/images/products/macbook_air_m2.png",
                    CategoryId = 8
                },
                new Product
                {
                    Id = 4,
                    Name = "Samsung Galaxy S24",
                    Description = "Flagship smartphone with advanced camera system.",
                    Price = 999.99,
                    ImageUrl = "/images/products/galaxy_s24.png",
                    CategoryId = 9
                },
                new Product
                {
                    Id = 5,
                    Name = "Sony WH-1000XM5",
                    Description = "Noise-cancelling wireless headphones.",
                    Price = 399.99,
                    ImageUrl = "/images/products/sony_xm5.png",
                    CategoryId = 10
                },
                new Product
                {
                    Id = 6,
                    Name = "Canon EOS R10",
                    Description = "Mirrorless camera for photography enthusiasts.",
                    Price = 979.99,
                    ImageUrl = "/images/products/canon_r10.png",
                    CategoryId = 11
                },
                new Product
                {
                    Id = 7,
                    Name = "PlayStation 5",
                    Description = "Next-gen gaming console from Sony.",
                    Price = 549.99,
                    ImageUrl = "/images/products/ps5.png",
                    CategoryId = 12
                },

                // Home Products
                new Product
                {
                    Id = 8,
                    Name = "Modern Wall Clock",
                    Description = "Minimalist wall clock for home decor.",
                    Price = 39.99,
                    ImageUrl = "/images/products/wall_clock.png",
                    CategoryId = 13
                },
                new Product
                {
                    Id = 9,
                    Name = "Wooden Dining Table",
                    Description = "Solid wood dining table for family meals.",
                    Price = 799.99,
                    ImageUrl = "/images/products/dining_table.png",
                    CategoryId = 14
                },
                new Product
                {
                    Id = 10,
                    Name = "LED Desk Lamp",
                    Description = "Energy-efficient LED lamp with adjustable brightness.",
                    Price = 49.99,
                    ImageUrl = "/images/products/desk_lamp.png",
                    CategoryId = 15
                },
                new Product
                {
                    Id = 11,
                    Name = "Garden Tool Set",
                    Description = "Complete set of tools for gardening tasks.",
                    Price = 59.99,
                    ImageUrl = "/images/products/garden_tools.png",
                    CategoryId = 16
                },
                new Product
                {
                    Id = 12,
                    Name = "Electric Drill",
                    Description = "Powerful electric drill for home improvement.",
                    Price = 129.99,
                    ImageUrl = "/images/products/drill.png",
                    CategoryId = 17
                },
                new Product
                {
                    Id = 13,
                    Name = "Concrete Mix",
                    Description = "High-quality concrete mix for construction.",
                    Price = 14.99,
                    ImageUrl = "/images/products/concrete.png",
                    CategoryId = 18
                },

                // Auto Products
                new Product
                {
                    Id = 14,
                    Name = "Fitness Dumbbells Set",
                    Description = "Adjustable dumbbell set for home workouts.",
                    Price = 119.99,
                    ImageUrl = "/images/products/dumbbells.png",
                    CategoryId = 19
                },
                new Product
                {
                    Id = 15,
                    Name = "Car Phone Holder",
                    Description = "Universal phone holder for car dashboards.",
                    Price = 24.99,
                    ImageUrl = "/images/products/car_holder.png",
                    CategoryId = 20
                },

                // Health Products
                new Product
                {
                    Id = 16,
                    Name = "Kids Building Blocks",
                    Description = "Educational toy set for kids.",
                    Price = 34.99,
                    ImageUrl = "/images/products/blocks.png",
                    CategoryId = 21
                },
                new Product
                {
                    Id = 17,
                    Name = "C# Programming Book",
                    Description = "Comprehensive guide to C# and .NET development.",
                    Price = 44.99,
                    ImageUrl = "/images/products/csharp_book.png",
                    CategoryId = 22
                },
                new Product
                {
                    Id = 18,
                    Name = "Vitamin C Tablets",
                    Description = "Dietary supplement to support immunity.",
                    Price = 14.99,
                    ImageUrl = "/images/products/vitamin_c.png",
                    CategoryId = 23
                },

                // Additional Products
                new Product
                {
                    Id = 19,
                    Name = "Wireless Mouse",
                    Description = "Ergonomic wireless mouse with long battery life.",
                    Price = 29.99,
                    ImageUrl = "/images/products/wireless_mouse.png",
                    CategoryId = 8
                },
                new Product
                {
                    Id = 20,
                    Name = "Smart Fitness Watch",
                    Description = "Track workouts, heart rate, and sleep with ease.",
                    Price = 199.99,
                    ImageUrl = "/images/products/smart_watch.png",
                    CategoryId = 10
                },
                new Product
                {
                    Id = 21,
                    Name = "Premium Yoga Mat",
                    Description = "Non-slip yoga mat with extra cushioning.",
                    Price = 39.99,
                    ImageUrl = "/images/products/yoga_mat.png",
                    CategoryId = 19
                }
            };
        }

        public static List<ProductProperty> GetProductProperties()
        {
            return new List<ProductProperty>
            {
                // Basic brands for seeded products
                new ProductProperty { Id = 1, ProductId = 1, PropertyDefinitionId = 1, Value = "Generic Brand" },
                new ProductProperty { Id = 2, ProductId = 2, PropertyDefinitionId = 1, Value = "RunFast" },
                new ProductProperty { Id = 3, ProductId = 3, PropertyDefinitionId = 1, Value = "Apple" },
                new ProductProperty { Id = 4, ProductId = 4, PropertyDefinitionId = 1, Value = "Samsung" },
                new ProductProperty { Id = 5, ProductId = 5, PropertyDefinitionId = 1, Value = "Sony" },
                new ProductProperty { Id = 6, ProductId = 6, PropertyDefinitionId = 1, Value = "Canon" },
                new ProductProperty { Id = 7, ProductId = 7, PropertyDefinitionId = 1, Value = "Sony" },
                new ProductProperty { Id = 8, ProductId = 8, PropertyDefinitionId = 1, Value = "Nordic" },
                new ProductProperty { Id = 9, ProductId = 9, PropertyDefinitionId = 1, Value = "OakWorks" },
                new ProductProperty { Id = 10, ProductId = 10, PropertyDefinitionId = 1, Value = "BrightLite" },
                new ProductProperty { Id = 11, ProductId = 11, PropertyDefinitionId = 1, Value = "GardenPro" },
                new ProductProperty { Id = 12, ProductId = 12, PropertyDefinitionId = 1, Value = "ToolMaster" },
                new ProductProperty { Id = 13, ProductId = 13, PropertyDefinitionId = 1, Value = "BuildRight" },
                new ProductProperty { Id = 14, ProductId = 14, PropertyDefinitionId = 1, Value = "FitZone" },
                new ProductProperty { Id = 15, ProductId = 15, PropertyDefinitionId = 1, Value = "AutoGrip" },
                new ProductProperty { Id = 16, ProductId = 16, PropertyDefinitionId = 1, Value = "PlayKids" },
                new ProductProperty { Id = 17, ProductId = 17, PropertyDefinitionId = 1, Value = "TechPress" },
                new ProductProperty { Id = 18, ProductId = 18, PropertyDefinitionId = 1, Value = "HealthPlus" },
                new ProductProperty { Id = 19, ProductId = 19, PropertyDefinitionId = 1, Value = "LogiTech" },
                new ProductProperty { Id = 20, ProductId = 20, PropertyDefinitionId = 1, Value = "Pulse" },
                new ProductProperty { Id = 21, ProductId = 21, PropertyDefinitionId = 1, Value = "ZenFlex" }
            };
        }

        public static List<ProductVariant> GetProductVariants()
        {
            return new List<ProductVariant>
            {
                // T-Shirt (product 1) variants
                new ProductVariant { Id = 1, ProductId = 1, Quantity = 20 },
                new ProductVariant { Id = 2, ProductId = 1, Quantity = 15 },

                // Sneakers (product 2) variants
                new ProductVariant { Id = 3, ProductId = 2, Quantity = 10 },
                new ProductVariant { Id = 4, ProductId = 2, Quantity = 5 },
                new ProductVariant { Id = 5, ProductId = 2, Quantity = 8 },

                new ProductVariant { Id = 6, ProductId = 3, Quantity = 6 },
                new ProductVariant { Id = 7, ProductId = 3, Quantity = 4 }
            };
        }

        public static List<ProductVariantValue> GetProductVariantValues()
        {
            return new List<ProductVariantValue>
            {
                // Product 1 variants: Size+Color
                new ProductVariantValue { Id = 1, ProductVariantId = 1, PropertyDefinitionId = 3, Value = "M" },
                new ProductVariantValue { Id = 2, ProductVariantId = 1, PropertyDefinitionId = 2, Value = "White" },
                new ProductVariantValue { Id = 3, ProductVariantId = 2, PropertyDefinitionId = 3, Value = "L" },
                new ProductVariantValue { Id = 4, ProductVariantId = 2, PropertyDefinitionId = 2, Value = "Black" },

                // Product 2 variants: Size+Color
                new ProductVariantValue { Id = 5, ProductVariantId = 3, PropertyDefinitionId = 3, Value = "41" },
                new ProductVariantValue { Id = 6, ProductVariantId = 3, PropertyDefinitionId = 2, Value = "White" },
                new ProductVariantValue { Id = 7, ProductVariantId = 4, PropertyDefinitionId = 3, Value = "42" },
                new ProductVariantValue { Id = 8, ProductVariantId = 4, PropertyDefinitionId = 2, Value = "Black" },
                new ProductVariantValue { Id = 9, ProductVariantId = 5, PropertyDefinitionId = 3, Value = "43" },
                new ProductVariantValue { Id = 10, ProductVariantId = 5, PropertyDefinitionId = 2, Value = "Gray" },

                new ProductVariantValue { Id = 11, ProductVariantId = 6, PropertyDefinitionId = 2, Value = "Space Gray" },
                new ProductVariantValue { Id = 12, ProductVariantId = 7, PropertyDefinitionId = 2, Value = "Silver" }
            };
        }
    }
}

