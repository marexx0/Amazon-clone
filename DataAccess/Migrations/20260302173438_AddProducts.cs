using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 7, 13 },
                column: "IsRequired",
                value: true);

            migrationBuilder.InsertData(
                table: "CategoryProperty",
                columns: new[] { "CategoryId", "PropertyDefinitionId", "IsRequired", "IsVariantOption" },
                values: new object[,]
                {
                    { 6, 13, true, false },
                    { 6, 14, false, false },
                    { 6, 15, false, false },
                    { 6, 16, false, false },
                    { 8, 4, false, false },
                    { 8, 5, false, false },
                    { 8, 13, true, false },
                    { 8, 14, false, false },
                    { 8, 15, false, false },
                    { 8, 16, false, false },
                    { 9, 4, false, false },
                    { 9, 5, false, false },
                    { 9, 13, true, false },
                    { 9, 14, false, false },
                    { 9, 15, false, false },
                    { 9, 16, false, false },
                    { 10, 4, false, false },
                    { 10, 5, false, false },
                    { 10, 13, true, false },
                    { 10, 14, false, false },
                    { 10, 15, false, false },
                    { 10, 16, false, false },
                    { 11, 4, false, false },
                    { 11, 5, false, false },
                    { 11, 13, true, false },
                    { 11, 14, false, false },
                    { 11, 15, false, false },
                    { 11, 16, false, false },
                    { 12, 4, false, false },
                    { 12, 5, false, false },
                    { 12, 13, true, false },
                    { 12, 14, false, false },
                    { 12, 15, false, false },
                    { 12, 16, false, false },
                    { 13, 13, true, false },
                    { 13, 14, false, false },
                    { 13, 15, false, false },
                    { 13, 16, false, false },
                    { 14, 13, true, false },
                    { 14, 14, false, false },
                    { 14, 15, false, false },
                    { 14, 16, false, false },
                    { 15, 13, true, false },
                    { 15, 14, false, false },
                    { 15, 15, false, false },
                    { 15, 16, false, false },
                    { 16, 13, true, false },
                    { 16, 14, false, false },
                    { 16, 15, false, false },
                    { 16, 16, false, false },
                    { 17, 13, true, false },
                    { 17, 14, false, false },
                    { 17, 15, false, false },
                    { 17, 16, false, false },
                    { 18, 13, true, false },
                    { 18, 14, false, false },
                    { 18, 15, false, false },
                    { 18, 16, false, false },
                    { 19, 13, true, false },
                    { 19, 14, false, false },
                    { 19, 15, false, false },
                    { 19, 16, false, false },
                    { 20, 13, true, false },
                    { 20, 14, false, false },
                    { 20, 15, false, false },
                    { 20, 16, false, false },
                    { 21, 13, true, false },
                    { 21, 14, false, false },
                    { 21, 15, false, false },
                    { 21, 16, false, false },
                    { 22, 13, true, false },
                    { 22, 14, false, false },
                    { 22, 15, false, false },
                    { 22, 16, false, false },
                    { 23, 13, true, false },
                    { 23, 14, false, false },
                    { 23, 15, false, false },
                    { 23, 16, false, false }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ContentType", "Data", "FileName", "ImageData", "ImageUrl", "IsPrimary", "Name", "ProductId" },
                values: new object[,]
                {
                    { 1, "image/png", null, "tshirt.png", null, "/images/products/tshirt.png", true, null, 1 },
                    { 2, "image/png", null, "sneakers.png", null, "/images/products/sneakers.png", true, null, 2 },
                    { 3, "image/png", null, "macbook_air_m2.png", null, "/images/products/macbook_air_m2.png", true, null, 3 },
                    { 4, "image/png", null, "galaxy_s24.png", null, "/images/products/galaxy_s24.png", true, null, 4 },
                    { 5, "image/png", null, "sony_xm5.png", null, "/images/products/sony_xm5.png", true, null, 5 },
                    { 6, "image/png", null, "canon_r10.png", null, "/images/products/canon_r10.png", true, null, 6 },
                    { 7, "image/png", null, "ps5.png", null, "/images/products/ps5.png", true, null, 7 },
                    { 22, "image/jpeg", null, "nike_dunk_cacao_pair.jpg", null, "/images/products/nike_dunk_cacao_pair.jpg", true, null, 22 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ContentType", "Data", "FileName", "ImageData", "ImageUrl", "Name", "ProductId", "SortOrder" },
                values: new object[,]
                {
                    { 23, "image/jpeg", null, "nike_dunk_cacao_outsole.jpg", null, "/images/products/nike_dunk_cacao_outsole.jpg", null, 22, 1 },
                    { 24, "image/jpeg", null, "nike_dunk_cacao_top.jpg", null, "/images/products/nike_dunk_cacao_top.jpg", null, 22, 2 },
                    { 25, "image/jpeg", null, "nike_dunk_cacao_side.jpg", null, "/images/products/nike_dunk_cacao_side.jpg", null, 22, 3 },
                    { 26, "image/jpeg", null, "nike_dunk_cacao_angle.jpg", null, "/images/products/nike_dunk_cacao_angle.jpg", null, 22, 4 }
                });

            migrationBuilder.UpdateData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 1,
                column: "Value",
                value: "Amazon Essentials");

            migrationBuilder.UpdateData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 2,
                column: "Value",
                value: "adidas");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 23, 6, "Iconic straight-leg men's jeans made with non-stretch denim and button fly construction for a timeless everyday fit.", "/images/products/levis_501.jpg", "Levi's 501 Original Fit Jeans", 59.5 },
                    { 24, 7, "Premium stability running shoe with FF BLAST PLUS ECO cushioning and 4D GUIDANCE SYSTEM support for long-distance comfort.", "/images/products/asics_kayano_30.jpg", "ASICS Gel-Kayano 30 Running Shoes", 159.94999999999999 },
                    { 25, 8, "Compact aluminum ultrabook featuring a 13.4-inch InfinityEdge display, 13th Gen Intel Core processor, 16GB RAM and fast 512GB SSD.", "/images/products/dell_xps_13_plus.jpg", "Dell XPS 13 Plus Laptop (13th Gen Intel, 16GB, 512GB)", 1399.99 },
                    { 26, 9, "Google flagship phone with advanced AI camera tools, 6.7-inch Super Actua display and all-day battery life.", "/images/products/pixel_8_pro.jpg", "Google Pixel 8 Pro Unlocked Smartphone", 999.0 },
                    { 27, 10, "Advanced smartwatch with bright Always-On Retina display, health sensors, workout tracking, and seamless iPhone integration.", "/images/products/apple_watch_series_9.jpg", "Apple Watch Series 9 GPS 45mm", 429.0 },
                    { 28, 11, "Full-frame mirrorless camera with dual EXPEED 6 processors, robust autofocus, and strong low-light image quality.", "/images/products/nikon_z6_ii.jpg", "Nikon Z6 II Mirrorless Camera Body", 1996.95 },
                    { 29, 12, "Microsoft's most powerful Xbox with 1TB SSD, 4K gaming support, and quick resume across multiple games.", "/images/products/xbox_series_x.jpg", "Xbox Series X Console", 499.99000000000001 },
                    { 30, 14, "Minimalist bedroom dresser with six smooth-glide drawers and a clean Scandinavian profile suitable for modern spaces.", "/images/products/malm_dresser.jpg", "IKEA MALM 6-Drawer Dresser", 279.0 },
                    { 31, 17, "Compact cordless drill/driver kit with two-speed transmission, 12V lithium-ion batteries, and durable carrying case.", "/images/products/bosch_12v_drill.jpg", "Bosch 12V Max Cordless Drill Driver Kit", 129.0 },
                    { 32, 21, "Creative building set with mixed LEGO bricks, wheels, and windows designed to inspire open-ended play for kids.", "/images/products/lego_10696.jpg", "LEGO Classic Medium Creative Brick Box 10696", 29.989999999999998 }
                });

            migrationBuilder.InsertData(
                table: "PropertyDefinition",
                columns: new[] { "Id", "DataType", "GroupName", "Name" },
                values: new object[,]
                {
                    { 18, "Text", "Material", "Material" },
                    { 19, "Text", "General", "Features" },
                    { 20, "Text", "Specification", "Capacity" },
                    { 21, "Text", "Specification", "Dimensions" },
                    { 22, "Text", "General", "Warranty" },
                    { 23, "Text", "Technology", "Connectivity" },
                    { 24, "Text", "Technology", "Battery Life" },
                    { 25, "Text", "Technology", "Storage Capacity" },
                    { 26, "Text", "Technology", "RAM" },
                    { 27, "Text", "Technology", "Processor" },
                    { 28, "Text", "Technology", "Display Size" },
                    { 29, "Text", "Technology", "Resolution" },
                    { 30, "Text", "Technology", "Operating System" },
                    { 31, "Text", "Technology", "Compatibility" },
                    { 32, "Text", "Specification", "Power Source" },
                    { 33, "Text", "Specification", "Installation Type" },
                    { 34, "Boolean", "Specification", "Assembly Required" },
                    { 35, "Text", "Home", "Room Type" },
                    { 36, "Text", "Home", "Finish Type" },
                    { 37, "Text", "Home", "Light Type" },
                    { 38, "Text", "Auto", "Vehicle Service Type" },
                    { 39, "Text", "Auto", "Part Number" },
                    { 40, "Text", "Kids", "Age Range" },
                    { 41, "Text", "Media", "Language" },
                    { 42, "Text", "Media", "Author" },
                    { 43, "Text", "Media", "Publisher" },
                    { 44, "Text", "Media", "ISBN" },
                    { 45, "Text", "Health", "Usage" }
                });

            migrationBuilder.InsertData(
                table: "CategoryProperty",
                columns: new[] { "CategoryId", "PropertyDefinitionId", "IsRequired", "IsVariantOption" },
                values: new object[,]
                {
                    { 6, 18, false, false },
                    { 6, 19, false, false },
                    { 6, 21, false, false },
                    { 6, 22, false, false },
                    { 7, 19, false, false },
                    { 7, 21, false, false },
                    { 7, 22, false, false },
                    { 8, 19, false, false },
                    { 8, 20, false, false },
                    { 8, 21, false, false },
                    { 8, 22, false, false },
                    { 8, 23, false, false },
                    { 8, 25, false, false },
                    { 8, 26, false, false },
                    { 8, 27, false, false },
                    { 8, 28, false, false },
                    { 8, 29, false, false },
                    { 8, 30, false, false },
                    { 8, 31, false, false },
                    { 8, 32, false, false },
                    { 9, 19, false, false },
                    { 9, 20, false, false },
                    { 9, 21, false, false },
                    { 9, 22, false, false },
                    { 9, 23, false, false },
                    { 9, 24, false, false },
                    { 9, 25, false, false },
                    { 9, 26, false, false },
                    { 9, 28, false, false },
                    { 9, 29, false, false },
                    { 9, 30, false, false },
                    { 9, 31, false, false },
                    { 10, 19, false, false },
                    { 10, 20, false, false },
                    { 10, 21, false, false },
                    { 10, 22, false, false },
                    { 10, 23, false, false },
                    { 10, 24, false, false },
                    { 10, 29, false, false },
                    { 10, 31, false, false },
                    { 11, 19, false, false },
                    { 11, 20, false, false },
                    { 11, 21, false, false },
                    { 11, 22, false, false },
                    { 11, 23, false, false },
                    { 11, 24, false, false },
                    { 11, 29, false, false },
                    { 11, 31, false, false },
                    { 11, 32, false, false },
                    { 12, 19, false, false },
                    { 12, 20, false, false },
                    { 12, 21, false, false },
                    { 12, 22, false, false },
                    { 12, 23, false, false },
                    { 12, 24, false, false },
                    { 12, 25, false, false },
                    { 12, 31, false, false },
                    { 13, 18, false, false },
                    { 13, 19, false, false },
                    { 13, 21, false, false },
                    { 13, 22, false, false },
                    { 13, 34, false, false },
                    { 13, 35, false, false },
                    { 13, 36, false, false },
                    { 14, 18, false, false },
                    { 14, 19, false, false },
                    { 14, 20, false, false },
                    { 14, 21, false, false },
                    { 14, 22, false, false },
                    { 14, 33, false, false },
                    { 14, 34, false, false },
                    { 14, 35, false, false },
                    { 14, 36, false, false },
                    { 15, 19, false, false },
                    { 15, 21, false, false },
                    { 15, 22, false, false },
                    { 15, 32, false, false },
                    { 15, 33, false, false },
                    { 15, 34, false, false },
                    { 15, 35, false, false },
                    { 15, 37, false, false },
                    { 16, 18, false, false },
                    { 16, 19, false, false },
                    { 16, 20, false, false },
                    { 16, 21, false, false },
                    { 16, 22, false, false },
                    { 16, 33, false, false },
                    { 16, 34, false, false },
                    { 17, 18, false, false },
                    { 17, 19, false, false },
                    { 17, 20, false, false },
                    { 17, 21, false, false },
                    { 17, 22, false, false },
                    { 17, 32, false, false },
                    { 17, 33, false, false },
                    { 17, 39, false, false },
                    { 18, 18, false, false },
                    { 18, 19, false, false },
                    { 18, 20, false, false },
                    { 18, 21, false, false },
                    { 18, 22, false, false },
                    { 18, 33, false, false },
                    { 18, 34, false, false },
                    { 18, 39, false, false },
                    { 19, 18, false, false },
                    { 19, 19, false, false },
                    { 19, 20, false, false },
                    { 19, 21, false, false },
                    { 19, 22, false, false },
                    { 19, 24, false, false },
                    { 19, 32, false, false },
                    { 19, 38, false, false },
                    { 20, 18, false, false },
                    { 20, 19, false, false },
                    { 20, 21, false, false },
                    { 20, 22, false, false },
                    { 20, 31, false, false },
                    { 20, 38, false, false },
                    { 20, 39, false, false },
                    { 21, 18, false, false },
                    { 21, 19, false, false },
                    { 21, 20, false, false },
                    { 21, 21, false, false },
                    { 21, 22, false, false },
                    { 21, 40, false, false },
                    { 22, 19, false, false },
                    { 22, 21, false, false },
                    { 22, 22, false, false },
                    { 22, 41, false, false },
                    { 22, 42, false, false },
                    { 22, 43, false, false },
                    { 22, 44, false, false },
                    { 23, 18, false, false },
                    { 23, 19, false, false },
                    { 23, 20, false, false },
                    { 23, 21, false, false },
                    { 23, 22, false, false },
                    { 23, 40, false, false },
                    { 23, 45, false, false }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ContentType", "Data", "FileName", "ImageData", "ImageUrl", "IsPrimary", "Name", "ProductId" },
                values: new object[,]
                {
                    { 27, "image/jfif", null, "levis501.jfif", null, "/images/products/levis501.jfif", true, null, 23 },
                    { 28, "image/jpg", null, "asics_kayano_30.jpg", null, "/images/products/asics_kayano_30.jpg", true, null, 24 },
                    { 29, "image/png", null, "dell_xps_13_plus.png", null, "/images/products/dell_xps_13_plus.png", true, null, 25 },
                    { 30, "image/png", null, "pixel_8_pro.png", null, "/images/products/pixel_8_pro.png", true, null, 26 },
                    { 31, "image/jpeg", null, "apple_watch_series_9.jpg", null, "/images/products/apple_watch_series_9.jpg", true, null, 27 },
                    { 32, "image/png", null, "nikon_z6_ii.png", null, "/images/products/nikon_z6_ii.png", true, null, 28 },
                    { 33, "image/png", null, "xbox_series_x.png", null, "/images/products/xbox_series_x.png", true, null, 29 },
                    { 34, "image/png", null, "malm_dresser.png", null, "/images/products/malm_dresser.png", true, null, 30 },
                    { 35, "image/png", null, "bosch_12v_drill.png", null, "/images/products/bosch_12v_drill.png", true, null, 31 },
                    { 36, "image/png", null, "lego_10696.png", null, "/images/products/lego_10696.png", true, null, 32 }
                });

            migrationBuilder.InsertData(
                table: "ProductProperties",
                columns: new[] { "Id", "Name", "ProductId", "PropertyDefinitionId", "Value" },
                values: new object[,]
                {
                    { 22, null, 23, 1, "Levi's" },
                    { 23, null, 23, 2, "Dark Stonewash" },
                    { 24, null, 23, 3, "32W x 32L" },
                    { 25, null, 23, 13, "Mexico" },
                    { 26, null, 23, 14, "Straight Leg" },
                    { 27, null, 23, 15, "All-season" },
                    { 28, null, 23, 16, "590 g" },
                    { 29, null, 23, 18, "100% Cotton Denim" },
                    { 30, null, 23, 19, "Button fly; five-pocket styling" },
                    { 31, null, 23, 21, "Regular fit" },
                    { 32, null, 23, 22, "Limited lifetime" },
                    { 33, null, 24, 1, "ASICS" },
                    { 34, null, 24, 2, "Black/Glow Yellow" },
                    { 35, null, 24, 3, "US 10" },
                    { 36, null, 24, 4, "Gel-Kayano 30" },
                    { 37, null, 24, 5, "1011B548" },
                    { 38, null, 24, 6, "Running" },
                    { 39, null, 24, 7, "Engineered stretch knit upper" },
                    { 40, null, 24, 8, "Textile" },
                    { 41, null, 24, 9, "OrthoLite X-55 sockliner" },
                    { 42, null, 24, 10, "FF BLAST PLUS ECO" },
                    { 43, null, 24, 11, "AHARPLUS rubber" },
                    { 44, null, 24, 12, "Round" },
                    { 45, null, 24, 13, "Vietnam" },
                    { 46, null, 24, 14, "Road Running" },
                    { 47, null, 24, 15, "All-season" },
                    { 48, null, 24, 16, "303 g per shoe" },
                    { 49, null, 24, 17, "4 cm" },
                    { 50, null, 24, 19, "4D GUIDANCE SYSTEM stability" },
                    { 51, null, 24, 21, "Standard width" },
                    { 52, null, 24, 22, "1 year" },
                    { 53, null, 25, 1, "Dell" },
                    { 54, null, 25, 2, "Platinum Silver" },
                    { 55, null, 25, 4, "XPS 13 Plus 9320" },
                    { 56, null, 25, 5, "XPS9320-7846SLV" },
                    { 57, null, 25, 13, "China" },
                    { 58, null, 25, 14, "Ultrabook" },
                    { 59, null, 25, 15, "All-season" },
                    { 60, null, 25, 16, "1.26 kg" },
                    { 61, null, 25, 19, "Backlit keyboard; Thunderbolt 4" },
                    { 62, null, 25, 20, "512GB" },
                    { 63, null, 25, 21, "295 x 199 x 15.3 mm" },
                    { 64, null, 25, 22, "1 year" },
                    { 65, null, 25, 23, "Wi-Fi 6E; Bluetooth 5.3" },
                    { 66, null, 25, 25, "512GB SSD" },
                    { 67, null, 25, 26, "16GB LPDDR5" },
                    { 68, null, 25, 27, "Intel Core i7-1360P" },
                    { 69, null, 25, 28, "13.4 inch" },
                    { 70, null, 25, 29, "2880 x 1800 OLED" },
                    { 71, null, 25, 30, "Windows 11 Home" },
                    { 72, null, 25, 31, "USB-C docks; Thunderbolt accessories" },
                    { 73, null, 25, 32, "65W USB-C" },
                    { 74, null, 26, 1, "Google" },
                    { 75, null, 26, 2, "Obsidian" },
                    { 76, null, 26, 4, "Pixel 8 Pro" },
                    { 77, null, 26, 5, "GC3VE" },
                    { 78, null, 26, 13, "Vietnam" },
                    { 79, null, 26, 14, "Flagship Smartphone" },
                    { 80, null, 26, 15, "All-season" },
                    { 81, null, 26, 16, "213 g" },
                    { 82, null, 26, 19, "Magic Eraser; Best Take" },
                    { 83, null, 26, 20, "5050 mAh" },
                    { 84, null, 26, 21, "162.6 x 76.5 x 8.8 mm" },
                    { 85, null, 26, 22, "1 year" },
                    { 86, null, 26, 23, "5G; Wi-Fi 7; Bluetooth 5.3" },
                    { 87, null, 26, 24, "24+ hours" },
                    { 88, null, 26, 25, "128GB" },
                    { 89, null, 26, 26, "12GB" },
                    { 90, null, 26, 28, "6.7 inch" },
                    { 91, null, 26, 29, "2992 x 1344" },
                    { 92, null, 26, 30, "Android 14" },
                    { 93, null, 26, 31, "Nano SIM; eSIM" },
                    { 94, null, 27, 1, "Apple" },
                    { 95, null, 27, 2, "Midnight" },
                    { 96, null, 27, 4, "Watch Series 9" },
                    { 97, null, 27, 5, "MR9A3LL/A" },
                    { 98, null, 27, 13, "China" },
                    { 99, null, 27, 14, "Smartwatch" },
                    { 100, null, 27, 15, "All-season" },
                    { 101, null, 27, 16, "38.7 g" },
                    { 102, null, 27, 19, "ECG app; blood oxygen" },
                    { 103, null, 27, 20, "308 mAh" },
                    { 104, null, 27, 21, "45 x 38 x 10.7 mm" },
                    { 105, null, 27, 22, "1 year" },
                    { 106, null, 27, 23, "Wi‑Fi; Bluetooth 5.3; GPS" },
                    { 107, null, 27, 24, "Up to 18 hours" },
                    { 108, null, 27, 29, "396 x 484" },
                    { 109, null, 27, 31, "iPhone Xs or later" },
                    { 110, null, 28, 1, "Nikon" },
                    { 111, null, 28, 2, "Black" },
                    { 112, null, 28, 4, "Z6 II" },
                    { 113, null, 28, 5, "1598" },
                    { 114, null, 28, 13, "Thailand" },
                    { 115, null, 28, 14, "Mirrorless Camera" },
                    { 116, null, 28, 15, "All-season" },
                    { 117, null, 28, 16, "705 g" },
                    { 118, null, 28, 19, "Dual card slots; 4K UHD video" },
                    { 119, null, 28, 20, "EN-EL15c battery" },
                    { 120, null, 28, 21, "134 x 101 x 70 mm" },
                    { 121, null, 28, 22, "1 year" },
                    { 122, null, 28, 23, "Wi‑Fi; Bluetooth" },
                    { 123, null, 28, 24, "Approx. 410 shots" },
                    { 124, null, 28, 29, "24.5 MP" },
                    { 125, null, 28, 31, "NIKKOR Z lenses" },
                    { 126, null, 28, 32, "Rechargeable Li-ion" },
                    { 127, null, 29, 1, "Microsoft" },
                    { 128, null, 29, 2, "Black" },
                    { 129, null, 29, 3, "1TB" },
                    { 130, null, 29, 4, "Xbox Series X" },
                    { 131, null, 29, 5, "RRT-00001" },
                    { 132, null, 29, 13, "China" },
                    { 133, null, 29, 14, "Home Console" },
                    { 134, null, 29, 15, "All-season" },
                    { 135, null, 29, 16, "4.45 kg" },
                    { 136, null, 29, 19, "Quick Resume; ray tracing" },
                    { 137, null, 29, 20, "1TB" },
                    { 138, null, 29, 21, "151 x 151 x 301 mm" },
                    { 139, null, 29, 22, "1 year" },
                    { 140, null, 29, 23, "Wi‑Fi 802.11ac; Ethernet" },
                    { 141, null, 29, 24, "N/A (mains powered)" },
                    { 142, null, 29, 25, "1TB NVMe SSD" },
                    { 143, null, 29, 31, "Xbox Wireless Controllers; HDMI 2.1" },
                    { 144, null, 30, 1, "IKEA" },
                    { 145, null, 30, 2, "White" },
                    { 146, null, 30, 3, "6-drawer" },
                    { 147, null, 30, 13, "Poland" },
                    { 148, null, 30, 14, "Modern" },
                    { 149, null, 30, 15, "All-season" },
                    { 150, null, 30, 16, "48 kg" },
                    { 151, null, 30, 18, "Particleboard and fiberboard" },
                    { 152, null, 30, 19, "Smooth-running drawers" },
                    { 153, null, 30, 20, "6 drawers" },
                    { 154, null, 30, 21, "160 x 78 x 48 cm" },
                    { 155, null, 30, 22, "1 year" },
                    { 156, null, 30, 33, "Freestanding" },
                    { 157, null, 30, 34, "true" },
                    { 158, null, 30, 35, "Bedroom" },
                    { 159, null, 30, 36, "Painted finish" },
                    { 160, null, 31, 1, "Bosch" },
                    { 161, null, 31, 2, "Blue/Black" },
                    { 162, null, 31, 3, "12V kit" },
                    { 163, null, 31, 13, "Malaysia" },
                    { 164, null, 31, 14, "Power Tool" },
                    { 165, null, 31, 15, "All-season" },
                    { 166, null, 31, 16, "0.95 kg tool only" },
                    { 167, null, 31, 18, "Steel and reinforced polymer" },
                    { 168, null, 31, 19, "Two-speed gearbox" },
                    { 169, null, 31, 20, "2.0Ah" },
                    { 170, null, 31, 21, "178 x 51 x 178 mm" },
                    { 171, null, 31, 22, "3 years" },
                    { 172, null, 31, 32, "12V Li-ion" },
                    { 173, null, 31, 33, "Handheld" },
                    { 174, null, 31, 39, "PS31-2A" },
                    { 175, null, 32, 1, "LEGO" },
                    { 176, null, 32, 2, "Multicolor" },
                    { 177, null, 32, 3, "484 pieces" },
                    { 178, null, 32, 13, "Denmark" },
                    { 179, null, 32, 14, "Creative Learning" },
                    { 180, null, 32, 15, "All-season" },
                    { 181, null, 32, 16, "0.62 kg" },
                    { 182, null, 32, 18, "ABS plastic" },
                    { 183, null, 32, 19, "Includes storage box and idea booklet" },
                    { 184, null, 32, 20, "484 pieces" },
                    { 185, null, 32, 21, "37 x 18 x 18 cm" },
                    { 186, null, 32, 22, "1 year" },
                    { 187, null, 32, 40, "4-99 years" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 6, 13 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 6, 14 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 6, 15 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 6, 16 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 6, 18 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 6, 19 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 6, 21 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 6, 22 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 7, 19 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 7, 21 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 7, 22 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 8, 13 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 8, 14 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 8, 15 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 8, 16 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 8, 19 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 8, 20 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 8, 21 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 8, 22 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 8, 23 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 8, 25 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 8, 26 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 8, 27 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 8, 28 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 8, 29 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 8, 30 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 8, 31 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 8, 32 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 9, 4 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 9, 5 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 9, 13 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 9, 14 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 9, 15 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 9, 16 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 9, 19 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 9, 20 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 9, 21 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 9, 22 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 9, 23 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 9, 24 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 9, 25 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 9, 26 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 9, 28 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 9, 29 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 9, 30 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 9, 31 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 10, 4 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 10, 5 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 10, 13 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 10, 14 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 10, 15 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 10, 16 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 10, 19 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 10, 20 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 10, 21 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 10, 22 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 10, 23 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 10, 24 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 10, 29 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 10, 31 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 11, 4 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 11, 5 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 11, 13 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 11, 14 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 11, 15 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 11, 16 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 11, 19 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 11, 20 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 11, 21 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 11, 22 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 11, 23 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 11, 24 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 11, 29 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 11, 31 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 11, 32 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 12, 4 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 12, 5 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 12, 13 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 12, 14 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 12, 15 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 12, 16 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 12, 19 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 12, 20 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 12, 21 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 12, 22 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 12, 23 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 12, 24 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 12, 25 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 12, 31 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 13, 13 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 13, 14 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 13, 15 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 13, 16 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 13, 18 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 13, 19 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 13, 21 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 13, 22 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 13, 34 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 13, 35 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 13, 36 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 14, 13 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 14, 14 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 14, 15 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 14, 16 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 14, 18 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 14, 19 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 14, 20 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 14, 21 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 14, 22 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 14, 33 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 14, 34 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 14, 35 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 14, 36 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 15, 13 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 15, 14 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 15, 15 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 15, 16 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 15, 19 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 15, 21 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 15, 22 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 15, 32 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 15, 33 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 15, 34 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 15, 35 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 15, 37 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 16, 13 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 16, 14 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 16, 15 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 16, 16 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 16, 18 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 16, 19 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 16, 20 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 16, 21 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 16, 22 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 16, 33 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 16, 34 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 17, 13 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 17, 14 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 17, 15 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 17, 16 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 17, 18 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 17, 19 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 17, 20 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 17, 21 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 17, 22 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 17, 32 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 17, 33 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 17, 39 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 18, 13 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 18, 14 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 18, 15 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 18, 16 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 18, 18 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 18, 19 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 18, 20 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 18, 21 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 18, 22 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 18, 33 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 18, 34 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 18, 39 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 19, 13 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 19, 14 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 19, 15 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 19, 16 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 19, 18 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 19, 19 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 19, 20 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 19, 21 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 19, 22 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 19, 24 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 19, 32 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 19, 38 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 20, 13 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 20, 14 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 20, 15 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 20, 16 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 20, 18 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 20, 19 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 20, 21 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 20, 22 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 20, 31 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 20, 38 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 20, 39 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 21, 13 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 21, 14 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 21, 15 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 21, 16 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 21, 18 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 21, 19 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 21, 20 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 21, 21 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 21, 22 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 21, 40 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 22, 13 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 22, 14 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 22, 15 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 22, 16 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 22, 19 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 22, 21 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 22, 22 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 22, 41 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 22, 42 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 22, 43 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 22, 44 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 23, 13 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 23, 14 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 23, 15 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 23, 16 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 23, 18 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 23, 19 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 23, 20 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 23, 21 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 23, 22 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 23, 40 });

            migrationBuilder.DeleteData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 23, 45 });

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "PropertyDefinition",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.UpdateData(
                table: "CategoryProperty",
                keyColumns: new[] { "CategoryId", "PropertyDefinitionId" },
                keyValues: new object[] { 7, 13 },
                column: "IsRequired",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 1,
                column: "Value",
                value: "Generic Brand");

            migrationBuilder.UpdateData(
                table: "ProductProperties",
                keyColumn: "Id",
                keyValue: 2,
                column: "Value",
                value: "RunFast");
        }
    }
}
