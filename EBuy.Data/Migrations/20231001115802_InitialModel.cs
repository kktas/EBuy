using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_business",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_business", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_category_t_category_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "t_category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "t_user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_user_t_business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "t_business",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "t_product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float(2)", precision: 2, nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_product_t_business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "t_business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_product_t_category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "t_category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_product_property_type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_product_property_type", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_product_property_type_t_category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "t_category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_product_property",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProductPropertyTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_product_property", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_product_property_t_product_property_type_ProductPropertyTypeId",
                        column: x => x.ProductPropertyTypeId,
                        principalTable: "t_product_property_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "t_user",
                columns: new[] { "Id", "Address", "BusinessId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Email", "FirstName", "LastName", "Password", "PhoneNumber" },
                values: new object[] { 1, "Acıbadem, 34660 Üsküdar/İstanbul", null, new DateTime(2023, 10, 1, 14, 58, 2, 822, DateTimeKind.Local).AddTicks(2800), 0, null, null, "ebuyaliveli@gmail.com", "Ali", "Veli", "1234567890", "+901234567890" });

            migrationBuilder.CreateIndex(
                name: "IX_t_category_ParentCategoryId",
                table: "t_category",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_t_product_BusinessId",
                table: "t_product",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_t_product_CategoryId",
                table: "t_product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_t_product_property_ProductPropertyTypeId",
                table: "t_product_property",
                column: "ProductPropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_t_product_property_type_CategoryId",
                table: "t_product_property_type",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_BusinessId",
                table: "t_user",
                column: "BusinessId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_product");

            migrationBuilder.DropTable(
                name: "t_product_property");

            migrationBuilder.DropTable(
                name: "t_user");

            migrationBuilder.DropTable(
                name: "t_product_property_type");

            migrationBuilder.DropTable(
                name: "t_business");

            migrationBuilder.DropTable(
                name: "t_category");
        }
    }
}
