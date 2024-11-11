using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWEPP.Migrations
{
    /// <inheritdoc />
    public partial class completet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expensess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalExpense = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberFee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateExpense = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateStart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateEnd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BalanceFee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeExpensesId = table.Column<int>(type: "int", nullable: false),
                    TypeAccountsId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expensess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expensess_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expensess_TypeAccounts_TypeAccountsId",
                        column: x => x.TypeAccountsId,
                        principalTable: "TypeAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expensess_TypeExpenses_TypeExpensesId",
                        column: x => x.TypeExpensesId,
                        principalTable: "TypeExpenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expensess_CustomerId",
                table: "Expensess",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Expensess_TypeAccountsId",
                table: "Expensess",
                column: "TypeAccountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Expensess_TypeExpensesId",
                table: "Expensess",
                column: "TypeExpensesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expensess");
        }
    }
}
