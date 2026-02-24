using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProductPropertyAndVariantFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductVariant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "ProductVariant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductProperty",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 19,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 20,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Value" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Value" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Value" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "Value" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "Value" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "Value" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Name", "Value" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Name", "Value" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Name", "Value" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Name", "Value" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductVariant");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "ProductVariant");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductProperty");
        }
    }
}
