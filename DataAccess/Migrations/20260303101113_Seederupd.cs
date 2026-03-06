using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Seederupd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "Id", "Name", "ProductId", "Quantity", "Value" },
                values: new object[,]
                {
                    { 51, null, 22, 8, null },
                    { 52, null, 22, 6, null },
                    { 53, null, 22, 6, null },
                    { 54, null, 22, 5, null },
                    { 55, null, 22, 4, null },
                    { 56, null, 24, 7, null },
                    { 57, null, 3, 4, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "Id", "Name", "ProductId", "Quantity", "Value" },
                values: new object[,]
                {
                    { 41, null, 22, 8, null },
                    { 42, null, 22, 6, null },
                    { 43, null, 22, 6, null },
                    { 44, null, 22, 5, null },
                    { 45, null, 22, 4, null },
                    { 46, null, 24, 7, null },
                    { 47, null, 3, 4, null }
                });
        }
    }
}
