using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dukkantek.Inventory.Infrastructure.Migrations
{
    public partial class initialcreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1L, "Category 1" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2L, "Category 2" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "CategoryId", "Description", "Name", "Status", "Weight" },
                values: new object[,]
                {
                    { 1L, "123456789", 1L, "Product 1 Description", "Product 1", "Sold", "0.95 kg" },
                    { 2L, "123456789", 2L, "Product 2 Description", "Product 2", "Sold", "0.75 kg" },
                    { 3L, "123456789", 1L, "Product 3 Description", "Product 3", "Sold", "0.70 kg" },
                    { 4L, "123456789", 2L, "Product 4 Description", "Product 4", "InStock", "2 kg" },
                    { 5L, "123456789", 1L, "Product 5 Description", "Product 5", "InStock", "1.5 kg" },
                    { 6L, "123456789", 2L, "Product 6 Description", "Product 6", "InStock", "2 kg" },
                    { 7L, "123456789", 1L, "Product 7 Description", "Product 7", "InStock", "0.5 kg" },
                    { 8L, "123456789", 2L, "Product 8 Description", "Product 8", "InStock", "1.5 kg" },
                    { 9L, "123456789", 1L, "Product 9 Description", "Product 9", "InStock", "2.75 kg" },
                    { 10L, "123456789", 2L, "Product 10 Description", "Product 10", "Damaged", "0.65 kg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
