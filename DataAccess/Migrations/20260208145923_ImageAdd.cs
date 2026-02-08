using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ImageAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ContentType", "FileName", "ImageData", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[,]
                {
                    { 1, "image/png", "tshirt.png", null, "/images/products/tshirt.png", true, 1 },
                    { 2, "image/png", "sneakers.png", null, "/images/products/sneakers.png", true, 2 },
                    { 3, "image/png", "macbook_air_m2.png", null, "/images/products/macbook_air_m2.png", true, 3 },
                    { 4, "image/png", "galaxy_s24.png", null, "/images/products/galaxy_s24.png", true, 4 },
                    { 5, "image/png", "sony_xm5.png", null, "/images/products/sony_xm5.png", true, 5 },
                    { 6, "image/png", "canon_r10.png", null, "/images/products/canon_r10.png", true, 6 },
                    { 7, "image/png", "ps5.png", null, "/images/products/ps5.png", true, 7 },
                    { 8, "image/png", "wall_clock.png", null, "/images/products/wall_clock.png", true, 8 },
                    { 9, "image/png", "dining_table.png", null, "/images/products/dining_table.png", true, 9 },
                    { 10, "image/png", "desk_lamp.png", null, "/images/products/desk_lamp.png", true, 10 },
                    { 11, "image/png", "garden_tools.png", null, "/images/products/garden_tools.png", true, 11 },
                    { 12, "image/png", "drill.png", null, "/images/products/drill.png", true, 12 },
                    { 13, "image/png", "concrete.png", null, "/images/products/concrete.png", true, 13 },
                    { 14, "image/png", "dumbbells.png", null, "/images/products/dumbbells.png", true, 14 },
                    { 15, "image/png", "car_holder.png", null, "/images/products/car_holder.png", true, 15 },
                    { 16, "image/png", "blocks.png", null, "/images/products/blocks.png", true, 16 },
                    { 17, "image/png", "csharp_book.png", null, "/images/products/csharp_book.png", true, 17 },
                    { 18, "image/png", "vitamin_c.png", null, "/images/products/vitamin_c.png", true, 18 }
                });

            migrationBuilder.UpdateData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ProductId", "Value" },
                values: new object[] { 6, "Canon" });

            migrationBuilder.InsertData(
                table: "ProductProperty",
                columns: new[] { "Id", "ProductId", "PropertyDefinitionId", "Value" },
                values: new object[,]
                {
                    { 7, 7, 1, "Sony" },
                    { 8, 8, 1, "Nordic" },
                    { 9, 9, 1, "OakWorks" },
                    { 10, 10, 1, "BrightLite" },
                    { 11, 11, 1, "GardenPro" },
                    { 12, 12, 1, "ToolMaster" },
                    { 13, 13, 1, "BuildRight" },
                    { 14, 14, 1, "FitZone" },
                    { 15, 15, 1, "AutoGrip" },
                    { 16, 16, 1, "PlayKids" },
                    { 17, 17, 1, "TechPress" },
                    { 18, 18, 1, "HealthPlus" }
                });

            migrationBuilder.InsertData(
                table: "ProductVariant",
                columns: new[] { "Id", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 5, 2, 8 },
                    { 6, 3, 6 },
                    { 7, 3, 4 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/images/products/tshirt.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/products/sneakers.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/images/products/macbook_air_m2.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/images/products/galaxy_s24.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/images/products/sony_xm5.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "/images/products/canon_r10.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "/images/products/ps5.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "/images/products/wall_clock.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "/images/products/dining_table.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "/images/products/desk_lamp.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "/images/products/garden_tools.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "/images/products/drill.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "/images/products/concrete.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "/images/products/dumbbells.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "/images/products/car_holder.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImageUrl",
                value: "/images/products/blocks.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImageUrl",
                value: "/images/products/csharp_book.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImageUrl",
                value: "/images/products/vitamin_c.png");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 19, 8, "Ergonomic wireless mouse with long battery life.", "/images/products/wireless_mouse.png", "Wireless Mouse", 29.989999999999998 },
                    { 20, 10, "Track workouts, heart rate, and sleep with ease.", "/images/products/smart_watch.png", "Smart Fitness Watch", 199.99000000000001 },
                    { 21, 19, "Non-slip yoga mat with extra cushioning.", "/images/products/yoga_mat.png", "Premium Yoga Mat", 39.990000000000002 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ContentType", "FileName", "ImageData", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[,]
                {
                    { 19, "image/png", "wireless_mouse.png", null, "/images/products/wireless_mouse.png", true, 19 },
                    { 20, "image/png", "smart_watch.png", null, "/images/products/smart_watch.png", true, 20 },
                    { 21, "image/png", "yoga_mat.png", null, "/images/products/yoga_mat.png", true, 21 }
                });

            migrationBuilder.InsertData(
                table: "ProductProperty",
                columns: new[] { "Id", "ProductId", "PropertyDefinitionId", "Value" },
                values: new object[,]
                {
                    { 19, 19, 1, "LogiTech" },
                    { 20, 20, 1, "Pulse" },
                    { 21, 21, 1, "ZenFlex" }
                });

            migrationBuilder.InsertData(
                table: "ProductVariantValue",
                columns: new[] { "Id", "ProductVariantId", "PropertyDefinitionId", "Value" },
                values: new object[,]
                {
                    { 9, 5, 3, "43" },
                    { 10, 5, 2, "Gray" },
                    { 11, 6, 2, "Space Gray" },
                    { 12, 7, 2, "Silver" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId_IsPrimary",
                table: "ProductImages",
                columns: new[] { "ProductId", "IsPrimary" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductVariantValue",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.UpdateData(
                table: "ProductProperty",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ProductId", "Value" },
                values: new object[] { 7, "Sony" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/images/products/tshirt.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/products/sneakers.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/images/products/macbook_air_m2.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/images/products/galaxy_s24.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/images/products/sony_xm5.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "/images/products/canon_r10.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "/images/products/ps5.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "/images/products/wall_clock.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "/images/products/dining_table.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "/images/products/desk_lamp.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "/images/products/garden_tools.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "/images/products/drill.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "/images/products/concrete.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "/images/products/dumbbells.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "/images/products/car_holder.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImageUrl",
                value: "/images/products/blocks.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImageUrl",
                value: "/images/products/csharp_book.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImageUrl",
                value: "/images/products/vitamin_c.jpg");
        }
    }
}
