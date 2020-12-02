using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WmTestProject.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ManufacturerId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 2, 13, 16, 20, 557, DateTimeKind.Local).AddTicks(9123), "Category1", null },
                    { 2, new DateTime(2020, 12, 2, 13, 16, 20, 560, DateTimeKind.Local).AddTicks(4383), "Category2", null },
                    { 3, new DateTime(2020, 12, 2, 13, 16, 20, 560, DateTimeKind.Local).AddTicks(4423), "Category3", null }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 2, 13, 16, 20, 560, DateTimeKind.Local).AddTicks(5518), "Manufacturer1", null },
                    { 2, new DateTime(2020, 12, 2, 13, 16, 20, 560, DateTimeKind.Local).AddTicks(5577), "Manufacturer2", null },
                    { 3, new DateTime(2020, 12, 2, 13, 16, 20, 560, DateTimeKind.Local).AddTicks(5582), "Manufacturer3", null }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 2, 13, 16, 20, 560, DateTimeKind.Local).AddTicks(6609), "Supplier1", null },
                    { 2, new DateTime(2020, 12, 2, 13, 16, 20, 560, DateTimeKind.Local).AddTicks(6672), "Supplier2", null },
                    { 3, new DateTime(2020, 12, 2, 13, 16, 20, 560, DateTimeKind.Local).AddTicks(6676), "Supplier3", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "ManufacturerId", "Name", "Price", "SupplierId", "UpdatedAt" },
                values: new object[] { 1, 1, new DateTime(2020, 12, 2, 13, 16, 20, 560, DateTimeKind.Local).AddTicks(9986), "Description 1234", 1, "Product 1", 346m, 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "ManufacturerId", "Name", "Price", "SupplierId", "UpdatedAt" },
                values: new object[] { 2, 2, new DateTime(2020, 12, 2, 13, 16, 20, 561, DateTimeKind.Local).AddTicks(82), "Description 1234", 2, "Product 2", 400m, 2, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "ManufacturerId", "Name", "Price", "SupplierId", "UpdatedAt" },
                values: new object[] { 3, 3, new DateTime(2020, 12, 2, 13, 16, 20, 561, DateTimeKind.Local).AddTicks(88), "Description 1234", 3, "Product 3", 100m, 3, null });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufacturerId",
                table: "Products",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
