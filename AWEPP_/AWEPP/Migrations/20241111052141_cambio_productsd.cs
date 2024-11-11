using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWEPP.Migrations
{
    /// <inheritdoc />
    public partial class cambio_productsd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeProductsId = table.Column<int>(type: "int", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    Account = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalBalance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartialBalance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Debt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePayment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productss_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productss_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productss_TypeProductss_TypeProductsId",
                        column: x => x.TypeProductsId,
                        principalTable: "TypeProductss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productss_BankId",
                table: "Productss",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Productss_CustomerId",
                table: "Productss",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Productss_TypeProductsId",
                table: "Productss",
                column: "TypeProductsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productss");
        }
    }
}
