using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertyDefinition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyDefinition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProperty",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    PropertyDefinitionId = table.Column<int>(type: "int", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    IsVariantOption = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProperty", x => new { x.CategoryId, x.PropertyDefinitionId });
                    table.ForeignKey(
                        name: "FK_CategoryProperty_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryProperty_PropertyDefinition_PropertyDefinitionId",
                        column: x => x.PropertyDefinitionId,
                        principalTable: "PropertyDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "ProductProperty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PropertyDefinitionId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductProperty_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProperty_PropertyDefinition_PropertyDefinitionId",
                        column: x => x.PropertyDefinitionId,
                        principalTable: "PropertyDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariant_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariantValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductVariantId = table.Column<int>(type: "int", nullable: false),
                    PropertyDefinitionId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariantValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariantValue_ProductVariant_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "ProductVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariantValue_PropertyDefinition_PropertyDefinitionId",
                        column: x => x.PropertyDefinitionId,
                        principalTable: "PropertyDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, "Lifestyle", null },
                    { 2, "Technology", null },
                    { 3, "Home", null },
                    { 4, "Auto", null },
                    { 5, "Health", null }
                });

            migrationBuilder.InsertData(
                table: "PropertyDefinition",
                columns: new[] { "Id", "DataType", "GroupName", "Name" },
                values: new object[,]
                {
                    { 1, "Text", "General", "Brand" },
                    { 2, "Text", "Variant", "Color" },
                    { 3, "Text", "Variant", "Size" },
                    { 4, "Text", "General", "Model Name" },
                    { 5, "Text", "General", "Model Number" },
                    { 6, "Text", "General", "Collection" },
                    { 7, "Text", "Material", "Upper Material" },
                    { 8, "Text", "Material", "Lining" },
                    { 9, "Text", "Comfort", "Insole" },
                    { 10, "Text", "Comfort", "Midsole" },
                    { 11, "Text", "Material", "Outsole" },
                    { 12, "Text", "Fit", "Toe Shape" },
                    { 13, "Text", "General", "Country of Origin" },
                    { 14, "Text", "General", "Style" },
                    { 15, "Text", "General", "Season" },
                    { 16, "Text", "General", "Weight" },
                    { 17, "Text", "Fit", "Sole Height" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 6, "Clothing", 1 },
                    { 7, "Shoes", 1 },
                    { 8, "Computers / Laptops / Tablets", 2 },
                    { 9, "Mobile Phones", 2 },
                    { 10, "Audio and Wearables", 2 },
                    { 11, "Cameras / Photo Equipment", 2 },
                    { 12, "Gaming", 2 },
                    { 13, "Home Decor", 3 },
                    { 14, "Furniture", 3 },
                    { 15, "Lighting", 3 },
                    { 16, "Yard and Garden", 3 },
                    { 17, "Tools / Hardware / Plumbing", 3 },
                    { 18, "Building Materials", 3 },
                    { 19, "Sports / Outdoor / Fitness", 4 },
                    { 20, "Auto Parts / Accessories", 4 },
                    { 21, "Toys Kids", 5 },
                    { 22, "Books / Media", 5 },
                    { 23, "Health", 5 }
                });

            migrationBuilder.InsertData(
                table: "CategoryProperty",
                columns: new[] { "CategoryId", "PropertyDefinitionId", "IsRequired", "IsVariantOption" },
                values: new object[,]
                {
                    { 6, 1, true, false },
                    { 6, 2, false, true },
                    { 6, 3, false, true },
                    { 7, 1, true, false },
                    { 7, 2, false, true },
                    { 7, 3, false, true },
                    { 7, 4, false, false },
                    { 7, 5, false, false },
                    { 7, 6, false, false },
                    { 7, 7, false, false },
                    { 7, 8, false, false },
                    { 7, 9, false, false },
                    { 7, 10, false, false },
                    { 7, 11, false, false },
                    { 7, 12, false, false },
                    { 7, 13, false, false },
                    { 7, 14, false, false },
                    { 7, 15, false, false },
                    { 7, 16, false, false },
                    { 7, 17, false, false },
                    { 8, 1, true, false },
                    { 9, 1, true, false },
                    { 10, 1, true, false },
                    { 11, 1, true, false },
                    { 12, 1, true, false },
                    { 13, 1, true, false },
                    { 14, 1, true, false },
                    { 15, 1, true, false },
                    { 16, 1, true, false },
                    { 17, 1, true, false },
                    { 18, 1, true, false },
                    { 19, 1, true, false },
                    { 20, 1, true, false },
                    { 21, 1, true, false },
                    { 22, 1, true, false },
                    { 23, 1, true, false }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 6, "Amazon Essentials men's short-sleeve crewneck t-shirt in soft jersey knit.", "/images/products/amazon_essentials_tshirt.png", "Amazon Essentials Men's Short-Sleeve Crewneck T-Shirt", 18.989999999999998 },
                    { 2, 7, "adidas Grand Court 2.0 sneakers with a synthetic leather upper and rubber outsole.", "/images/products/adidas_grand_court.png", "adidas Men's Grand Court 2.0 Sneakers", 69.989999999999995 },
                    { 3, 8, "Apple MacBook Air 13-inch laptop with M2 chip, 8GB RAM, and 256GB SSD storage.", "/images/products/macbook_air_m2.png", "Apple MacBook Air 13-inch Laptop (M2, 8GB, 256GB)", 1099.0 },
                    { 4, 9, "Samsung Galaxy S24 unlocked smartphone with advanced camera system.", "/images/products/galaxy_s24.png", "Samsung Galaxy S24 Unlocked Smartphone", 799.99000000000001 },
                    { 5, 10, "Sony WH-1000XM5 wireless noise canceling headphones with premium sound.", "/images/products/sony_wh1000xm5.png", "Sony WH-1000XM5 Wireless Noise Canceling Headphones", 398.0 },
                    { 6, 11, "Canon EOS R10 mirrorless camera kit with RF-S 18-45mm lens for versatile shooting.", "/images/products/canon_eos_r10.png", "Canon EOS R10 Mirrorless Camera with RF-S 18-45mm Lens", 999.0 },
                    { 7, 12, "PlayStation 5 console for next-gen gaming with ultra-high-speed SSD.", "/images/products/ps5_console.png", "PlayStation 5 Console", 499.99000000000001 },
                    { 22, 7, "Classic low-top silhouette with leather overlays, padded collar comfort, and durable rubber traction for daily wear.", "/images/products/nike_dunk_cacao_pair.jpg", "Nike Dunk Low Retro - Cacao Wow", 129.99000000000001 }
                });

            migrationBuilder.InsertData(
                table: "ProductProperty",
                columns: new[] { "Id", "ProductId", "PropertyDefinitionId", "Value" },
                values: new object[,]
                {
                    { 1, 1, 1, "Generic Brand" },
                    { 2, 2, 1, "RunFast" },
                    { 3, 3, 1, "Apple" },
                    { 4, 4, 1, "Samsung" },
                    { 5, 5, 1, "Sony" },
                    { 6, 7, 1, "Sony" },
                    { 7, 22, 1, "Nike" },
                    { 8, 22, 4, "Dunk Low Retro" },
                    { 9, 22, 5, "DD1503-124" },
                    { 10, 22, 6, "Nike Sportswear" },
                    { 11, 22, 7, "Leather upper with synthetic overlays" },
                    { 12, 22, 8, "Soft textile lining" },
                    { 13, 22, 9, "Cushioned foam insole" },
                    { 14, 22, 10, "Lightweight EVA midsole" },
                    { 15, 22, 11, "Durable rubber outsole with circular traction" },
                    { 16, 22, 12, "Round" },
                    { 17, 22, 13, "Vietnam" },
                    { 18, 22, 14, "Lifestyle / Casual" },
                    { 19, 22, 15, "All-season" },
                    { 20, 22, 16, "Approx. 820 g per pair (EU 42)" },
                    { 21, 22, 17, "3 cm" }
                });

            migrationBuilder.InsertData(
                table: "ProductVariant",
                columns: new[] { "Id", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 20 },
                    { 2, 1, 15 },
                    { 3, 2, 10 },
                    { 4, 2, 5 },
                    { 5, 22, 12 },
                    { 6, 22, 14 },
                    { 7, 22, 11 },
                    { 8, 22, 9 },
                    { 9, 22, 8 },
                    { 10, 22, 7 }
                });

            migrationBuilder.InsertData(
                table: "ProductVariantValue",
                columns: new[] { "Id", "ProductVariantId", "PropertyDefinitionId", "Value" },
                values: new object[,]
                {
                    { 1, 1, 3, "M" },
                    { 2, 1, 2, "White" },
                    { 3, 2, 3, "L" },
                    { 4, 2, 2, "Black" },
                    { 5, 3, 3, "41" },
                    { 6, 3, 2, "White" },
                    { 7, 4, 3, "42" },
                    { 8, 4, 2, "Black" },
                    { 9, 5, 3, "41" },
                    { 10, 5, 2, "White" },
                    { 11, 6, 3, "42" },
                    { 12, 6, 2, "White" },
                    { 13, 7, 3, "43" },
                    { 14, 7, 2, "White" },
                    { 15, 8, 3, "41" },
                    { 16, 8, 2, "Brown" },
                    { 17, 9, 3, "42" },
                    { 18, 9, 2, "Brown" },
                    { 19, 10, 3, "43" },
                    { 20, 10, 2, "Brown" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_UserId",
                table: "CartItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProperty_PropertyDefinitionId",
                table: "CategoryProperty",
                column: "PropertyDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId_IsPrimary",
                table: "ProductImages",
                columns: new[] { "ProductId", "IsPrimary" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperty_ProductId",
                table: "ProductProperty",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperty_PropertyDefinitionId",
                table: "ProductProperty",
                column: "PropertyDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariant_ProductId",
                table: "ProductVariant",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariantValue_ProductVariantId",
                table: "ProductVariantValue",
                column: "ProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariantValue_PropertyDefinitionId",
                table: "ProductVariantValue",
                column: "PropertyDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyDefinition_Name",
                table: "PropertyDefinition",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "CategoryProperty");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductProperty");

            migrationBuilder.DropTable(
                name: "ProductVariantValue");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductVariant");

            migrationBuilder.DropTable(
                name: "PropertyDefinition");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
