using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class levisImagefix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ContentType", "FileName", "ImageUrl" },
                values: new object[] { "image/png", "levis_501.png", "/images/products/levis501.png" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ContentType", "FileName", "ImageUrl" },
                values: new object[] { "image/jfif", "levis501.jfif", "/images/products/levis501.jfif" });
        }
    }
}
