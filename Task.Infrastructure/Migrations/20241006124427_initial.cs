using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    IsInvoiceDirect = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoreSpaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreSpaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreSpaces_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreSpaceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_StoreSpaces_StoreSpaceId",
                        column: x => x.StoreSpaceId,
                        principalTable: "StoreSpaces",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "IsInvoiceDirect", "IsMain", "Name" },
                values: new object[,]
                {
                    { 1, "Al Gammal St - Cairo - Egypt", true, true, "Main Store" },
                    { 2, "Ain Shams St - Cairo - Egypt", true, false, "Electric Store" },
                    { 3, "Port Said St - Cairo - Egypt", false, false, "Food Store" },
                    { 4, "Port Said St - Cairo - Egypt", false, false, "Machines Store" }
                });

            migrationBuilder.InsertData(
                table: "StoreSpaces",
                columns: new[] { "Id", "IsDefault", "Name", "StoreId" },
                values: new object[,]
                {
                    { 1, true, "Default", 1 },
                    { 2, true, "Default", 2 },
                    { 3, true, "Default", 3 },
                    { 4, true, "Default", 4 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "StoreSpaceId" },
                values: new object[,]
                {
                    { 1, "Default Product Name 1", 1 },
                    { 2, "Default Product Name 2", 2 },
                    { 3, "Default Product Name 3", 3 },
                    { 4, "Default Product Name 4", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_StoreSpaceId",
                table: "Products",
                column: "StoreSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreSpaces_StoreId",
                table: "StoreSpaces",
                column: "StoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "StoreSpaces");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
