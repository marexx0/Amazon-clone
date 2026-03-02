using System.Collections.Generic;
using System.Linq;

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
                new PropertyDefinition { Id = 17, Name = "Sole Height", DataType = PropertyDataType.Text, GroupName = "Fit" },
                new PropertyDefinition { Id = 18, Name = "Material", DataType = PropertyDataType.Text, GroupName = "Material" },
                new PropertyDefinition { Id = 19, Name = "Features", DataType = PropertyDataType.Text, GroupName = "General" },
                new PropertyDefinition { Id = 20, Name = "Capacity", DataType = PropertyDataType.Text, GroupName = "Specification" },
                new PropertyDefinition { Id = 21, Name = "Dimensions", DataType = PropertyDataType.Text, GroupName = "Specification" },
                new PropertyDefinition { Id = 22, Name = "Warranty", DataType = PropertyDataType.Text, GroupName = "General" },
                new PropertyDefinition { Id = 23, Name = "Connectivity", DataType = PropertyDataType.Text, GroupName = "Technology" },
                new PropertyDefinition { Id = 24, Name = "Battery Life", DataType = PropertyDataType.Text, GroupName = "Technology" },
                new PropertyDefinition { Id = 25, Name = "Storage Capacity", DataType = PropertyDataType.Text, GroupName = "Technology" },
                new PropertyDefinition { Id = 26, Name = "RAM", DataType = PropertyDataType.Text, GroupName = "Technology" },
                new PropertyDefinition { Id = 27, Name = "Processor", DataType = PropertyDataType.Text, GroupName = "Technology" },
                new PropertyDefinition { Id = 28, Name = "Display Size", DataType = PropertyDataType.Text, GroupName = "Technology" },
                new PropertyDefinition { Id = 29, Name = "Resolution", DataType = PropertyDataType.Text, GroupName = "Technology" },
                new PropertyDefinition { Id = 30, Name = "Operating System", DataType = PropertyDataType.Text, GroupName = "Technology" },
                new PropertyDefinition { Id = 31, Name = "Compatibility", DataType = PropertyDataType.Text, GroupName = "Technology" },
                new PropertyDefinition { Id = 32, Name = "Power Source", DataType = PropertyDataType.Text, GroupName = "Specification" },
                new PropertyDefinition { Id = 33, Name = "Installation Type", DataType = PropertyDataType.Text, GroupName = "Specification" },
                new PropertyDefinition { Id = 34, Name = "Assembly Required", DataType = PropertyDataType.Boolean, GroupName = "Specification" },
                new PropertyDefinition { Id = 35, Name = "Room Type", DataType = PropertyDataType.Text, GroupName = "Home" },
                new PropertyDefinition { Id = 36, Name = "Finish Type", DataType = PropertyDataType.Text, GroupName = "Home" },
                new PropertyDefinition { Id = 37, Name = "Light Type", DataType = PropertyDataType.Text, GroupName = "Home" },
                new PropertyDefinition { Id = 38, Name = "Vehicle Service Type", DataType = PropertyDataType.Text, GroupName = "Auto" },
                new PropertyDefinition { Id = 39, Name = "Part Number", DataType = PropertyDataType.Text, GroupName = "Auto" },
                new PropertyDefinition { Id = 40, Name = "Age Range", DataType = PropertyDataType.Text, GroupName = "Kids" },
                new PropertyDefinition { Id = 41, Name = "Language", DataType = PropertyDataType.Text, GroupName = "Media" },
                new PropertyDefinition { Id = 42, Name = "Author", DataType = PropertyDataType.Text, GroupName = "Media" },
                new PropertyDefinition { Id = 43, Name = "Publisher", DataType = PropertyDataType.Text, GroupName = "Media" },
                new PropertyDefinition { Id = 44, Name = "ISBN", DataType = PropertyDataType.Text, GroupName = "Media" },
                new PropertyDefinition { Id = 45, Name = "Usage", DataType = PropertyDataType.Text, GroupName = "Health" }
            };
        }

        public static List<CategoryProperty> GetCategoryProperties()
        {
            var allCategories = Enumerable.Range(6, 18);
            var all = new List<CategoryProperty>();

            foreach (var categoryId in allCategories)
            {
                all.AddRange(CreateCategoryProperties(categoryId, new[] { 1, 13, 14, 15, 16, 19, 21, 22 }));
            }

            all.AddRange(CreateCategoryProperties(6, new[] { 2, 3, 18 }, variantPropertyIds: new[] { 2, 3 }));
            all.AddRange(CreateCategoryProperties(7, new[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 17 }, variantPropertyIds: new[] { 2, 3 }));

            all.AddRange(CreateCategoryProperties(8, new[] { 4, 5, 20, 23, 25, 26, 27, 28, 29, 30, 31, 32 }, variantPropertyIds: new[] { 2 }));
            all.AddRange(CreateCategoryProperties(9, new[] { 4, 5, 20, 23, 24, 25, 26, 28, 29, 30, 31 }, variantPropertyIds: new[] { 2 }));
            all.AddRange(CreateCategoryProperties(10, new[] { 4, 5, 20, 23, 24, 29, 31 }, variantPropertyIds: new[] { 2 }));
            all.AddRange(CreateCategoryProperties(11, new[] { 4, 5, 20, 23, 24, 29, 31, 32 }, variantPropertyIds: new[] { 2 }));
            all.AddRange(CreateCategoryProperties(12, new[] { 4, 5, 20, 23, 24, 25, 31 }, variantPropertyIds: new[] { 2, 3 }));

            all.AddRange(CreateCategoryProperties(13, new[] { 18, 34, 35, 36 }, variantPropertyIds: new[] { 2, 3 }));
            all.AddRange(CreateCategoryProperties(14, new[] { 18, 20, 33, 34, 35, 36 }, variantPropertyIds: new[] { 2, 3 }));
            all.AddRange(CreateCategoryProperties(15, new[] { 32, 33, 34, 35, 37 }, variantPropertyIds: new[] { 2 }));
            all.AddRange(CreateCategoryProperties(16, new[] { 18, 20, 33, 34 }, variantPropertyIds: new[] { 2, 3 }));
            all.AddRange(CreateCategoryProperties(17, new[] { 18, 20, 32, 33, 39 }, variantPropertyIds: new[] { 2, 3 }));
            all.AddRange(CreateCategoryProperties(18, new[] { 18, 20, 21, 33, 34, 39 }, variantPropertyIds: new[] { 2 }));

            all.AddRange(CreateCategoryProperties(19, new[] { 18, 20, 24, 32, 38 }, variantPropertyIds: new[] { 2, 3 }));
            all.AddRange(CreateCategoryProperties(20, new[] { 18, 31, 38, 39 }, variantPropertyIds: new[] { 2, 3 }));

            all.AddRange(CreateCategoryProperties(21, new[] { 18, 20, 40 }, variantPropertyIds: new[] { 2, 3 }));
            all.AddRange(CreateCategoryProperties(22, new[] { 41, 42, 43, 44 }, variantPropertyIds: new[] { 2 }));
            all.AddRange(CreateCategoryProperties(23, new[] { 18, 20, 40, 45 }, variantPropertyIds: new[] { 2, 3 }));

            return all
                .GroupBy(cp => new { cp.CategoryId, cp.PropertyDefinitionId })
                .Select(g => g.First())
                .ToList();
        }

        private static IEnumerable<CategoryProperty> CreateCategoryProperties(int categoryId, IEnumerable<int> propertyIds, IEnumerable<int>? variantPropertyIds = null)
        {
            var variantSet = variantPropertyIds?.ToHashSet() ?? new HashSet<int>();
            foreach (var propertyId in propertyIds)
            {
                yield return new CategoryProperty
                {
                    CategoryId = categoryId,
                    PropertyDefinitionId = propertyId,
                    IsRequired = propertyId is 1 or 13,
                    IsVariantOption = variantSet.Contains(propertyId)
                };
            }
        }

        public static List<ProductProperty> GetProductProperties()
        {
            var properties = new List<ProductProperty>
            {
                new ProductProperty { Id = 1, ProductId = 1, PropertyDefinitionId = 1, Value = "Amazon Essentials" },
                new ProductProperty { Id = 2, ProductId = 2, PropertyDefinitionId = 1, Value = "adidas" },
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

            var fullySpecifiedProducts = new Dictionary<int, Dictionary<int, string>>
            {
                [23] = new()
                {
                    [1] = "Levi's",
                    [2] = "Dark Stonewash",
                    [3] = "32W x 32L",
                    [13] = "Mexico",
                    [14] = "Straight Leg",
                    [15] = "All-season",
                    [16] = "590 g",
                    [18] = "100% Cotton Denim",
                    [19] = "Button fly; five-pocket styling",
                    [21] = "Regular fit",
                    [22] = "Limited lifetime"
                },
                [24] = new()
                {
                    [1] = "ASICS",
                    [2] = "Black/Glow Yellow",
                    [3] = "US 10",
                    [4] = "Gel-Kayano 30",
                    [5] = "1011B548",
                    [6] = "Running",
                    [7] = "Engineered stretch knit upper",
                    [8] = "Textile",
                    [9] = "OrthoLite X-55 sockliner",
                    [10] = "FF BLAST PLUS ECO",
                    [11] = "AHARPLUS rubber",
                    [12] = "Round",
                    [13] = "Vietnam",
                    [14] = "Road Running",
                    [15] = "All-season",
                    [16] = "303 g per shoe",
                    [17] = "4 cm",
                    [19] = "4D GUIDANCE SYSTEM stability",
                    [21] = "Standard width",
                    [22] = "1 year"
                },
                [25] = new()
                {
                    [1] = "Dell",
                    [2] = "Platinum Silver",
                    [4] = "XPS 13 Plus 9320",
                    [5] = "XPS9320-7846SLV",
                    [13] = "China",
                    [14] = "Ultrabook",
                    [15] = "All-season",
                    [16] = "1.26 kg",
                    [19] = "Backlit keyboard; Thunderbolt 4",
                    [20] = "512GB",
                    [21] = "295 x 199 x 15.3 mm",
                    [22] = "1 year",
                    [23] = "Wi-Fi 6E; Bluetooth 5.3",
                    [25] = "512GB SSD",
                    [26] = "16GB LPDDR5",
                    [27] = "Intel Core i7-1360P",
                    [28] = "13.4 inch",
                    [29] = "2880 x 1800 OLED",
                    [30] = "Windows 11 Home",
                    [31] = "USB-C docks; Thunderbolt accessories",
                    [32] = "65W USB-C"
                },
                [26] = new()
                {
                    [1] = "Google",
                    [2] = "Obsidian",
                    [4] = "Pixel 8 Pro",
                    [5] = "GC3VE",
                    [13] = "Vietnam",
                    [14] = "Flagship Smartphone",
                    [15] = "All-season",
                    [16] = "213 g",
                    [19] = "Magic Eraser; Best Take",
                    [20] = "5050 mAh",
                    [21] = "162.6 x 76.5 x 8.8 mm",
                    [22] = "1 year",
                    [23] = "5G; Wi-Fi 7; Bluetooth 5.3",
                    [24] = "24+ hours",
                    [25] = "128GB",
                    [26] = "12GB",
                    [28] = "6.7 inch",
                    [29] = "2992 x 1344",
                    [30] = "Android 14",
                    [31] = "Nano SIM; eSIM"
                },
                [27] = new()
                {
                    [1] = "Apple",
                    [2] = "Midnight",
                    [4] = "Watch Series 9",
                    [5] = "MR9A3LL/A",
                    [13] = "China",
                    [14] = "Smartwatch",
                    [15] = "All-season",
                    [16] = "38.7 g",
                    [19] = "ECG app; blood oxygen",
                    [20] = "308 mAh",
                    [21] = "45 x 38 x 10.7 mm",
                    [22] = "1 year",
                    [23] = "Wi‑Fi; Bluetooth 5.3; GPS",
                    [24] = "Up to 18 hours",
                    [29] = "396 x 484",
                    [31] = "iPhone Xs or later"
                },
                [28] = new()
                {
                    [1] = "Nikon",
                    [2] = "Black",
                    [4] = "Z6 II",
                    [5] = "1598",
                    [13] = "Thailand",
                    [14] = "Mirrorless Camera",
                    [15] = "All-season",
                    [16] = "705 g",
                    [19] = "Dual card slots; 4K UHD video",
                    [20] = "EN-EL15c battery",
                    [21] = "134 x 101 x 70 mm",
                    [22] = "1 year",
                    [23] = "Wi‑Fi; Bluetooth",
                    [24] = "Approx. 410 shots",
                    [29] = "24.5 MP",
                    [31] = "NIKKOR Z lenses",
                    [32] = "Rechargeable Li-ion"
                },
                [29] = new()
                {
                    [1] = "Microsoft",
                    [2] = "Black",
                    [3] = "1TB",
                    [4] = "Xbox Series X",
                    [5] = "RRT-00001",
                    [13] = "China",
                    [14] = "Home Console",
                    [15] = "All-season",
                    [16] = "4.45 kg",
                    [19] = "Quick Resume; ray tracing",
                    [20] = "1TB",
                    [21] = "151 x 151 x 301 mm",
                    [22] = "1 year",
                    [23] = "Wi‑Fi 802.11ac; Ethernet",
                    [24] = "N/A (mains powered)",
                    [25] = "1TB NVMe SSD",
                    [31] = "Xbox Wireless Controllers; HDMI 2.1"
                },
                [30] = new()
                {
                    [1] = "IKEA",
                    [2] = "White",
                    [3] = "6-drawer",
                    [13] = "Poland",
                    [14] = "Modern",
                    [15] = "All-season",
                    [16] = "48 kg",
                    [18] = "Particleboard and fiberboard",
                    [19] = "Smooth-running drawers",
                    [20] = "6 drawers",
                    [21] = "160 x 78 x 48 cm",
                    [22] = "1 year",
                    [33] = "Freestanding",
                    [34] = "true",
                    [35] = "Bedroom",
                    [36] = "Painted finish"
                },
                [31] = new()
                {
                    [1] = "Bosch",
                    [2] = "Blue/Black",
                    [3] = "12V kit",
                    [13] = "Malaysia",
                    [14] = "Power Tool",
                    [15] = "All-season",
                    [16] = "0.95 kg tool only",
                    [18] = "Steel and reinforced polymer",
                    [19] = "Two-speed gearbox",
                    [20] = "2.0Ah",
                    [21] = "178 x 51 x 178 mm",
                    [22] = "3 years",
                    [32] = "12V Li-ion",
                    [33] = "Handheld",
                    [39] = "PS31-2A"
                },
                [32] = new()
                {
                    [1] = "LEGO",
                    [2] = "Multicolor",
                    [3] = "484 pieces",
                    [13] = "Denmark",
                    [14] = "Creative Learning",
                    [15] = "All-season",
                    [16] = "0.62 kg",
                    [18] = "ABS plastic",
                    [19] = "Includes storage box and idea booklet",
                    [20] = "484 pieces",
                    [21] = "37 x 18 x 18 cm",
                    [22] = "1 year",
                    [40] = "4-99 years"
                }
            };

            var nextId = properties.Max(p => p.Id) + 1;
            foreach (var entry in fullySpecifiedProducts)
            {
                foreach (var property in entry.Value.OrderBy(p => p.Key))
                {
                    properties.Add(new ProductProperty
                    {
                        Id = nextId++,
                        ProductId = entry.Key,
                        PropertyDefinitionId = property.Key,
                        Value = property.Value
                    });
                }
            }

            return properties;
        }

        public static List<ProductVariant> GetProductVariants()
        {
            return new List<ProductVariant>
            {
                // Existing variants
                new ProductVariant { Id = 1, ProductId = 1, Quantity = 20 },
                new ProductVariant { Id = 2, ProductId = 1, Quantity = 15 },
                new ProductVariant { Id = 3, ProductId = 2, Quantity = 10 },
                new ProductVariant { Id = 4, ProductId = 2, Quantity = 5 },
                new ProductVariant { Id = 5, ProductId = 22, Quantity = 12 },
                new ProductVariant { Id = 6, ProductId = 22, Quantity = 14 },
                new ProductVariant { Id = 7, ProductId = 22, Quantity = 11 },
                new ProductVariant { Id = 8, ProductId = 22, Quantity = 9 },
                new ProductVariant { Id = 9, ProductId = 22, Quantity = 8 },
                new ProductVariant { Id = 10, ProductId = 22, Quantity = 7 },

                // Added variants for all other seeded products
                new ProductVariant { Id = 11, ProductId = 3, Quantity = 9 },
                new ProductVariant { Id = 12, ProductId = 3, Quantity = 7 },
                new ProductVariant { Id = 13, ProductId = 4, Quantity = 14 },
                new ProductVariant { Id = 14, ProductId = 4, Quantity = 10 },
                new ProductVariant { Id = 15, ProductId = 5, Quantity = 13 },
                new ProductVariant { Id = 16, ProductId = 5, Quantity = 8 },
                new ProductVariant { Id = 17, ProductId = 6, Quantity = 6 },
                new ProductVariant { Id = 18, ProductId = 6, Quantity = 4 },
                new ProductVariant { Id = 19, ProductId = 7, Quantity = 16 },
                new ProductVariant { Id = 20, ProductId = 7, Quantity = 12 },

                new ProductVariant { Id = 21, ProductId = 23, Quantity = 18 },
                new ProductVariant { Id = 22, ProductId = 23, Quantity = 12 },
                new ProductVariant { Id = 23, ProductId = 24, Quantity = 11 },
                new ProductVariant { Id = 24, ProductId = 24, Quantity = 9 },
                new ProductVariant { Id = 25, ProductId = 25, Quantity = 6 },
                new ProductVariant { Id = 26, ProductId = 25, Quantity = 5 },
                new ProductVariant { Id = 27, ProductId = 26, Quantity = 10 },
                new ProductVariant { Id = 28, ProductId = 26, Quantity = 8 },
                new ProductVariant { Id = 29, ProductId = 27, Quantity = 9 },
                new ProductVariant { Id = 30, ProductId = 27, Quantity = 7 },
                new ProductVariant { Id = 31, ProductId = 28, Quantity = 5 },
                new ProductVariant { Id = 32, ProductId = 28, Quantity = 3 },
                new ProductVariant { Id = 33, ProductId = 29, Quantity = 12 },
                new ProductVariant { Id = 34, ProductId = 29, Quantity = 10 },
                new ProductVariant { Id = 35, ProductId = 30, Quantity = 7 },
                new ProductVariant { Id = 36, ProductId = 30, Quantity = 6 },
                new ProductVariant { Id = 37, ProductId = 31, Quantity = 15 },
                new ProductVariant { Id = 38, ProductId = 31, Quantity = 11 },
                new ProductVariant { Id = 39, ProductId = 32, Quantity = 20 },
                new ProductVariant { Id = 40, ProductId = 32, Quantity = 17 }
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

                // Product 22 variants: Size+Color
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
                new ProductVariantValue { Id = 20, ProductVariantId = 10, PropertyDefinitionId = 2, Value = "Brown" },

                // Product 3 (MacBook): Color
                new ProductVariantValue { Id = 21, ProductVariantId = 11, PropertyDefinitionId = 2, Value = "Space Gray" },
                new ProductVariantValue { Id = 22, ProductVariantId = 12, PropertyDefinitionId = 2, Value = "Silver" },

                // Product 4 (Galaxy S24): Color
                new ProductVariantValue { Id = 23, ProductVariantId = 13, PropertyDefinitionId = 2, Value = "Onyx Black" },
                new ProductVariantValue { Id = 24, ProductVariantId = 14, PropertyDefinitionId = 2, Value = "Amber Yellow" },

                // Product 5 (WH-1000XM5): Color
                new ProductVariantValue { Id = 25, ProductVariantId = 15, PropertyDefinitionId = 2, Value = "Black" },
                new ProductVariantValue { Id = 26, ProductVariantId = 16, PropertyDefinitionId = 2, Value = "Silver" },

                // Product 6 (Canon): Color
                new ProductVariantValue { Id = 27, ProductVariantId = 17, PropertyDefinitionId = 2, Value = "Black" },
                new ProductVariantValue { Id = 28, ProductVariantId = 18, PropertyDefinitionId = 2, Value = "Black + Kit Lens" },

                // Product 7 (PS5): Color+Size(selectable tier)
                new ProductVariantValue { Id = 29, ProductVariantId = 19, PropertyDefinitionId = 2, Value = "White" },
                new ProductVariantValue { Id = 30, ProductVariantId = 19, PropertyDefinitionId = 3, Value = "Standard" },
                new ProductVariantValue { Id = 31, ProductVariantId = 20, PropertyDefinitionId = 2, Value = "Midnight Black" },
                new ProductVariantValue { Id = 32, ProductVariantId = 20, PropertyDefinitionId = 3, Value = "Slim" },

                // Product 23 (Levi's): Color+Size
                new ProductVariantValue { Id = 33, ProductVariantId = 21, PropertyDefinitionId = 2, Value = "Dark Stonewash" },
                new ProductVariantValue { Id = 34, ProductVariantId = 21, PropertyDefinitionId = 3, Value = "32W x 32L" },
                new ProductVariantValue { Id = 35, ProductVariantId = 22, PropertyDefinitionId = 2, Value = "Rinse" },
                new ProductVariantValue { Id = 36, ProductVariantId = 22, PropertyDefinitionId = 3, Value = "34W x 32L" },

                // Product 24 (ASICS): Color+Size
                new ProductVariantValue { Id = 37, ProductVariantId = 23, PropertyDefinitionId = 2, Value = "Black/Glow Yellow" },
                new ProductVariantValue { Id = 38, ProductVariantId = 23, PropertyDefinitionId = 3, Value = "US 10" },
                new ProductVariantValue { Id = 39, ProductVariantId = 24, PropertyDefinitionId = 2, Value = "White/Blue" },
                new ProductVariantValue { Id = 40, ProductVariantId = 24, PropertyDefinitionId = 3, Value = "US 11" },

                // Product 25 (Dell): Color
                new ProductVariantValue { Id = 41, ProductVariantId = 25, PropertyDefinitionId = 2, Value = "Platinum Silver" },
                new ProductVariantValue { Id = 42, ProductVariantId = 26, PropertyDefinitionId = 2, Value = "Graphite" },

                // Product 26 (Pixel): Color
                new ProductVariantValue { Id = 43, ProductVariantId = 27, PropertyDefinitionId = 2, Value = "Obsidian" },
                new ProductVariantValue { Id = 44, ProductVariantId = 28, PropertyDefinitionId = 2, Value = "Bay" },

                // Product 27 (Apple Watch): Color
                new ProductVariantValue { Id = 45, ProductVariantId = 29, PropertyDefinitionId = 2, Value = "Midnight" },
                new ProductVariantValue { Id = 46, ProductVariantId = 30, PropertyDefinitionId = 2, Value = "Starlight" },

                // Product 28 (Nikon): Color
                new ProductVariantValue { Id = 47, ProductVariantId = 31, PropertyDefinitionId = 2, Value = "Black" },
                new ProductVariantValue { Id = 48, ProductVariantId = 32, PropertyDefinitionId = 2, Value = "Black + 24-70mm Kit" },

                // Product 29 (Xbox): Color+Size(storage tier)
                new ProductVariantValue { Id = 49, ProductVariantId = 33, PropertyDefinitionId = 2, Value = "Black" },
                new ProductVariantValue { Id = 50, ProductVariantId = 33, PropertyDefinitionId = 3, Value = "1TB" },
                new ProductVariantValue { Id = 51, ProductVariantId = 34, PropertyDefinitionId = 2, Value = "Robot White" },
                new ProductVariantValue { Id = 52, ProductVariantId = 34, PropertyDefinitionId = 3, Value = "512GB" },

                // Product 30 (MALM): Color+Size
                new ProductVariantValue { Id = 53, ProductVariantId = 35, PropertyDefinitionId = 2, Value = "White" },
                new ProductVariantValue { Id = 54, ProductVariantId = 35, PropertyDefinitionId = 3, Value = "6-drawer" },
                new ProductVariantValue { Id = 55, ProductVariantId = 36, PropertyDefinitionId = 2, Value = "Black-Brown" },
                new ProductVariantValue { Id = 56, ProductVariantId = 36, PropertyDefinitionId = 3, Value = "3-drawer" },

                // Product 31 (Bosch): Color+Size
                new ProductVariantValue { Id = 57, ProductVariantId = 37, PropertyDefinitionId = 2, Value = "Blue/Black" },
                new ProductVariantValue { Id = 58, ProductVariantId = 37, PropertyDefinitionId = 3, Value = "12V Kit" },
                new ProductVariantValue { Id = 59, ProductVariantId = 38, PropertyDefinitionId = 2, Value = "Blue/Black" },
                new ProductVariantValue { Id = 60, ProductVariantId = 38, PropertyDefinitionId = 3, Value = "Bare Tool" },

                // Product 32 (LEGO): Color+Size(piece count)
                new ProductVariantValue { Id = 61, ProductVariantId = 39, PropertyDefinitionId = 2, Value = "Multicolor" },
                new ProductVariantValue { Id = 62, ProductVariantId = 39, PropertyDefinitionId = 3, Value = "484 Pieces" },
                new ProductVariantValue { Id = 63, ProductVariantId = 40, PropertyDefinitionId = 2, Value = "Multicolor" },
                new ProductVariantValue { Id = 64, ProductVariantId = 40, PropertyDefinitionId = 3, Value = "790 Pieces" }
            };
        }
    }
}