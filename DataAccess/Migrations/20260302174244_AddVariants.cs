using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddVariants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "Id", "Name", "ProductId", "Quantity", "Value" },
                values: new object[,]
                {
                    { 11, null, 3, 9, null },
                    { 12, null, 3, 7, null },
                    { 13, null, 4, 14, null },
                    { 14, null, 4, 10, null },
                    { 15, null, 5, 13, null },
                    { 16, null, 5, 8, null },
                    { 17, null, 6, 6, null },
                    { 18, null, 6, 4, null },
                    { 19, null, 7, 16, null },
                    { 20, null, 7, 12, null },
                    { 21, null, 23, 18, null },
                    { 22, null, 23, 12, null },
                    { 23, null, 24, 11, null },
                    { 24, null, 24, 9, null },
                    { 25, null, 25, 6, null },
                    { 26, null, 25, 5, null },
                    { 27, null, 26, 10, null },
                    { 28, null, 26, 8, null },
                    { 29, null, 27, 9, null },
                    { 30, null, 27, 7, null },
                    { 31, null, 28, 5, null },
                    { 32, null, 28, 3, null },
                    { 33, null, 29, 12, null },
                    { 34, null, 29, 10, null },
                    { 35, null, 30, 7, null },
                    { 36, null, 30, 6, null },
                    { 37, null, 31, 15, null },
                    { 38, null, 31, 11, null },
                    { 39, null, 32, 20, null },
                    { 40, null, 32, 17, null }
                });

            migrationBuilder.InsertData(
                table: "ProductVariantValue",
                columns: new[] { "Id", "ProductVariantId", "PropertyDefinitionId", "Value" },
                values: new object[,]
                {
                    { 21, 11, 2, "Space Gray" },
                    { 22, 12, 2, "Silver" },
                    { 23, 13, 2, "Onyx Black" },
                    { 24, 14, 2, "Amber Yellow" },
                    { 25, 15, 2, "Black" },
                    { 26, 16, 2, "Silver" },
                    { 27, 17, 2, "Black" },
                    { 28, 18, 2, "Black + Kit Lens" },
                    { 29, 19, 2, "White" },
                    { 30, 19, 3, "Standard" },
                    { 31, 20, 2, "Midnight Black" },
                    { 32, 20, 3, "Slim" },
                    { 33, 21, 2, "Dark Stonewash" },
                    { 34, 21, 3, "32W x 32L" },
                    { 35, 22, 2, "Rinse" },
                    { 36, 22, 3, "34W x 32L" },
                    { 37, 23, 2, "Black/Glow Yellow" },
                    { 38, 23, 3, "US 10" },
                    { 39, 24, 2, "White/Blue" },
                    { 40, 24, 3, "US 11" },
                    { 41, 25, 2, "Platinum Silver" },
                    { 42, 26, 2, "Graphite" },
                    { 43, 27, 2, "Obsidian" },
                    { 44, 28, 2, "Bay" },
                    { 45, 29, 2, "Midnight" },
                    { 46, 30, 2, "Starlight" },
                    { 47, 31, 2, "Black" },
                    { 48, 32, 2, "Black + 24-70mm Kit" },
                    { 49, 33, 2, "Black" },
                    { 50, 33, 3, "1TB" },
                    { 51, 34, 2, "Robot White" },
                    { 52, 34, 3, "512GB" },
                    { 53, 35, 2, "White" },
                    { 54, 35, 3, "6-drawer" },
                    { 55, 36, 2, "Black-Brown" },
                    { 56, 36, 3, "3-drawer" },
                    { 57, 37, 2, "Blue/Black" },
                    { 58, 37, 3, "12V Kit" },
                    { 59, 38, 2, "Blue/Black" },
                    { 60, 38, 3, "Bare Tool" },
                    { 61, 39, 2, "Multicolor" },
                    { 62, 39, 3, "484 Pieces" },
                    { 63, 40, 2, "Multicolor" },
                    { 64, 40, 3, "790 Pieces" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 40);
        }
    }
}
