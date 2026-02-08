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
                new ProductProperty { Id = 6, ProductId = 7, PropertyDefinitionId = 1, Value = "Sony" }
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
                new ProductVariant { Id = 4, ProductId = 2, Quantity = 5 }
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
                new ProductVariantValue { Id = 8, ProductVariantId = 4, PropertyDefinitionId = 2, Value = "Black" }
            };
        }
    }
}

