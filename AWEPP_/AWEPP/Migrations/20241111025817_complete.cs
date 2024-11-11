using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWEPP.Migrations
{
    /// <inheritdoc />
    public partial class complete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpensesHistory_Expenses_ExpensesId",
                table: "ExpensesHistory");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_ExpensesHistory_ExpensesId",
                table: "ExpensesHistory");

            migrationBuilder.DropColumn(
                name: "ExpensesId",
                table: "ExpensesHistory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpensesId",
                table: "ExpensesHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TypeAccountsId = table.Column<int>(type: "int", nullable: false),
                    TypeExpensesId = table.Column<int>(type: "int", nullable: false),
                    TypeProductsId = table.Column<int>(type: "int", nullable: false),
                    BalanceFee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateEnd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateExpense = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateStart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    NumberFee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalExpense = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_TypeAccounts_TypeAccountsId",
                        column: x => x.TypeAccountsId,
                        principalTable: "TypeAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_TypeExpenses_TypeExpensesId",
                        column: x => x.TypeExpensesId,
                        principalTable: "TypeExpenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_TypeProducts_TypeProductsId",
                        column: x => x.TypeProductsId,
                        principalTable: "TypeProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpensesHistory_ExpensesId",
                table: "ExpensesHistory",
                column: "ExpensesId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CustomerId",
                table: "Expenses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_TypeAccountsId",
                table: "Expenses",
                column: "TypeAccountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_TypeExpensesId",
                table: "Expenses",
                column: "TypeExpensesId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_TypeProductsId",
                table: "Expenses",
                column: "TypeProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpensesHistory_Expenses_ExpensesId",
                table: "ExpensesHistory",
                column: "ExpensesId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
