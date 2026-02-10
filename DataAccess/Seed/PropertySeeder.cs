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
                new PropertyDefinition { Id = 3, Name = "Size", DataType = PropertyDataType.Text, GroupName = "Variant" },
                new PropertyDefinition { Id = 4, Name = "Model Name", DataType = PropertyDataType.Text, GroupName = "General" },
                new PropertyDefinition { Id = 5, Name = "Model Number", DataType = PropertyDataType.Text, GroupName = "General" },
                new PropertyDefinition { Id = 6, Name = "Collection", DataType = PropertyDataType.Text, GroupName = "General" },
                new PropertyDefinition { Id = 7, Name = "Upper Material", DataType = PropertyDataType.Text, GroupName = "Material" },
                new PropertyDefinition { Id = 8, Name = "Lining", DataType = PropertyDataType.Text, GroupName = "Material" },
                new PropertyDefinition { Id = 9, Name = "Insole", DataType = PropertyDataType.Text, GroupName = "Comfort" },
                new PropertyDefinition { Id = 10, Name = "Midsole", DataType = PropertyDataType.Text, GroupName = "Comfort" },
                new PropertyDefinition { Id = 11, Name = "Outsole", DataType = PropertyDataType.Text, GroupName = "Material" },
                new PropertyDefinition { Id = 12, Name = "Toe Shape", DataType = PropertyDataType.Text, GroupName = "Fit" },
                new PropertyDefinition { Id = 13, Name = "Country of Origin", DataType = PropertyDataType.Text, GroupName = "General" },
                new PropertyDefinition { Id = 14, Name = "Style", DataType = PropertyDataType.Text, GroupName = "General" },
                new PropertyDefinition { Id = 15, Name = "Season", DataType = PropertyDataType.Text, GroupName = "General" },
                new PropertyDefinition { Id = 16, Name = "Weight", DataType = PropertyDataType.Text, GroupName = "General" },
                new PropertyDefinition { Id = 17, Name = "Sole Height", DataType = PropertyDataType.Text, GroupName = "Fit" }
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
                new CategoryProperty { CategoryId = 7, PropertyDefinitionId = 4, IsRequired = false, IsVariantOption = false },
                new CategoryProperty { CategoryId = 7, PropertyDefinitionId = 5, IsRequired = false, IsVariantOption = false },
                new CategoryProperty { CategoryId = 7, PropertyDefinitionId = 6, IsRequired = false, IsVariantOption = false },
                new CategoryProperty { CategoryId = 7, PropertyDefinitionId = 7, IsRequired = false, IsVariantOption = false },
                new CategoryProperty { CategoryId = 7, PropertyDefinitionId = 8, IsRequired = false, IsVariantOption = false },
                new CategoryProperty { CategoryId = 7, PropertyDefinitionId = 9, IsRequired = false, IsVariantOption = false },
                new CategoryProperty { CategoryId = 7, PropertyDefinitionId = 10, IsRequired = false, IsVariantOption = false },
                new CategoryProperty { CategoryId = 7, PropertyDefinitionId = 11, IsRequired = false, IsVariantOption = false },
                new CategoryProperty { CategoryId = 7, PropertyDefinitionId = 12, IsRequired = false, IsVariantOption = false },
                new CategoryProperty { CategoryId = 7, PropertyDefinitionId = 13, IsRequired = false, IsVariantOption = false },
                new CategoryProperty { CategoryId = 7, PropertyDefinitionId = 14, IsRequired = false, IsVariantOption = false },
                new CategoryProperty { CategoryId = 7, PropertyDefinitionId = 15, IsRequired = false, IsVariantOption = false },
                new CategoryProperty { CategoryId = 7, PropertyDefinitionId = 16, IsRequired = false, IsVariantOption = false },
                new CategoryProperty { CategoryId = 7, PropertyDefinitionId = 17, IsRequired = false, IsVariantOption = false },

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
                new ProductProperty { Id = 6, ProductId = 7, PropertyDefinitionId = 1, Value = "Sony" },

                // Nike Dunk Low Retro - Cacao Wow (product 22)
                new ProductProperty { Id = 7, ProductId = 22, PropertyDefinitionId = 1, Value = "Nike" },
                new ProductProperty { Id = 8, ProductId = 22, PropertyDefinitionId = 4, Value = "Dunk Low Retro" },
                new ProductProperty { Id = 9, ProductId = 22, PropertyDefinitionId = 5, Value = "DD1503-124" },
                new ProductProperty { Id = 10, ProductId = 22, PropertyDefinitionId = 6, Value = "Nike Sportswear" },
                new ProductProperty { Id = 11, ProductId = 22, PropertyDefinitionId = 7, Value = "Leather upper with synthetic overlays" },
                new ProductProperty { Id = 12, ProductId = 22, PropertyDefinitionId = 8, Value = "Soft textile lining" },
                new ProductProperty { Id = 13, ProductId = 22, PropertyDefinitionId = 9, Value = "Cushioned foam insole" },
                new ProductProperty { Id = 14, ProductId = 22, PropertyDefinitionId = 10, Value = "Lightweight EVA midsole" },
                new ProductProperty { Id = 15, ProductId = 22, PropertyDefinitionId = 11, Value = "Durable rubber outsole with circular traction" },
                new ProductProperty { Id = 16, ProductId = 22, PropertyDefinitionId = 12, Value = "Round" },
                new ProductProperty { Id = 17, ProductId = 22, PropertyDefinitionId = 13, Value = "Vietnam" },
                new ProductProperty { Id = 18, ProductId = 22, PropertyDefinitionId = 14, Value = "Lifestyle / Casual" },
                new ProductProperty { Id = 19, ProductId = 22, PropertyDefinitionId = 15, Value = "All-season" },
                new ProductProperty { Id = 20, ProductId = 22, PropertyDefinitionId = 16, Value = "Approx. 820 g per pair (EU 42)" },
                new ProductProperty { Id = 21, ProductId = 22, PropertyDefinitionId = 17, Value = "3 cm" }
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

                // Nike Dunk Low Retro - Cacao Wow (product 22) variants
                new ProductVariant { Id = 5, ProductId = 22, Quantity = 12 },
                new ProductVariant { Id = 6, ProductId = 22, Quantity = 14 },
                new ProductVariant { Id = 7, ProductId = 22, Quantity = 11 },
                new ProductVariant { Id = 8, ProductId = 22, Quantity = 9 },
                new ProductVariant { Id = 9, ProductId = 22, Quantity = 8 },
                new ProductVariant { Id = 10, ProductId = 22, Quantity = 7 }
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

                // Product 22 variants: Size + Color
                new ProductVariantValue { Id = 9, ProductVariantId = 5, PropertyDefinitionId = 3, Value = "41" },
                new ProductVariantValue { Id = 10, ProductVariantId = 5, PropertyDefinitionId = 2, Value = "White" },
                new ProductVariantValue { Id = 11, ProductVariantId = 6, PropertyDefinitionId = 3, Value = "42" },
                new ProductVariantValue { Id = 12, ProductVariantId = 6, PropertyDefinitionId = 2, Value = "White" },
                new ProductVariantValue { Id = 13, ProductVariantId = 7, PropertyDefinitionId = 3, Value = "43" },
                new ProductVariantValue { Id = 14, ProductVariantId = 7, PropertyDefinitionId = 2, Value = "White" },
                new ProductVariantValue { Id = 15, ProductVariantId = 8, PropertyDefinitionId = 3, Value = "41" },
                new ProductVariantValue { Id = 16, ProductVariantId = 8, PropertyDefinitionId = 2, Value = "Brown" },
                new ProductVariantValue { Id = 17, ProductVariantId = 9, PropertyDefinitionId = 3, Value = "42" },
                new ProductVariantValue { Id = 18, ProductVariantId = 9, PropertyDefinitionId = 2, Value = "Brown" },
                new ProductVariantValue { Id = 19, ProductVariantId = 10, PropertyDefinitionId = 3, Value = "43" },
                new ProductVariantValue { Id = 20, ProductVariantId = 10, PropertyDefinitionId = 2, Value = "Brown" }
            };
        }
    }
}