using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWEPP.Migrations
{
    /// <inheritdoc />
    public partial class cambio_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsHistory_Products_ProductsId",
                table: "ProductsHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Savings_Products_ProductsId",
                table: "Savings");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Savings_ProductsId",
                table: "Savings");

            migrationBuilder.DropIndex(
                name: "IX_ProductsHistory_ProductsId",
                table: "ProductsHistory");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "Savings");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "ProductsHistory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "Savings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "ProductsHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TypeAccountsId = table.Column<int>(type: "int", nullable: false),
                    TypeProductsId = table.Column<int>(type: "int", nullable: false),
                    Account = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePayment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Debt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    NumberAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartialBalance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalBalance = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_TypeAccounts_TypeAccountsId",
                        column: x => x.TypeAccountsId,
                        principalTable: "TypeAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_TypeProductss_TypeProductsId",
                        column: x => x.TypeProductsId,
                        principalTable: "TypeProductss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Savings_ProductsId",
                table: "Savings",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsHistory_ProductsId",
                table: "ProductsHistory",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BankId",
                table: "Products",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CustomerId",
                table: "Products",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeAccountsId",
                table: "Products",
                column: "TypeAccountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeProductsId",
                table: "Products",
                column: "TypeProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsHistory_Products_ProductsId",
                table: "ProductsHistory",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Savings_Products_ProductsId",
                table: "Savings",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
