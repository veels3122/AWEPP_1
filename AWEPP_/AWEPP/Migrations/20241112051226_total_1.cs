using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWEPP.Migrations
{
    /// <inheritdoc />
    public partial class total_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeAccesUserId",
                table: "TypeAccesUserHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "ProductsHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExpensesId",
                table: "ExpensesHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TypeAccesUserHistory_TypeAccesUserId",
                table: "TypeAccesUserHistory",
                column: "TypeAccesUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsHistory_ProductsId",
                table: "ProductsHistory",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpensesHistory_ExpensesId",
                table: "ExpensesHistory",
                column: "ExpensesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpensesHistory_Expensess_ExpensesId",
                table: "ExpensesHistory",
                column: "ExpensesId",
                principalTable: "Expensess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsHistory_Productss_ProductsId",
                table: "ProductsHistory",
                column: "ProductsId",
                principalTable: "Productss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeAccesUserHistory_TypeAccessUsers_TypeAccesUserId",
                table: "TypeAccesUserHistory",
                column: "TypeAccesUserId",
                principalTable: "TypeAccessUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpensesHistory_Expensess_ExpensesId",
                table: "ExpensesHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsHistory_Productss_ProductsId",
                table: "ProductsHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeAccesUserHistory_TypeAccessUsers_TypeAccesUserId",
                table: "TypeAccesUserHistory");

            migrationBuilder.DropIndex(
                name: "IX_TypeAccesUserHistory_TypeAccesUserId",
                table: "TypeAccesUserHistory");

            migrationBuilder.DropIndex(
                name: "IX_ProductsHistory_ProductsId",
                table: "ProductsHistory");

            migrationBuilder.DropIndex(
                name: "IX_ExpensesHistory_ExpensesId",
                table: "ExpensesHistory");

            migrationBuilder.DropColumn(
                name: "TypeAccesUserId",
                table: "TypeAccesUserHistory");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "ProductsHistory");

            migrationBuilder.DropColumn(
                name: "ExpensesId",
                table: "ExpensesHistory");
        }
    }
}
