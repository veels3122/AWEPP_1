using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWEPP.Migrations
{
    /// <inheritdoc />
    public partial class arreglorelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Savings_TypeAccounts_TypeAccountsId",
                table: "Savings");

            migrationBuilder.DropIndex(
                name: "IX_Savings_TypeAccountsId",
                table: "Savings");

            migrationBuilder.DropColumn(
                name: "TypeAccountsId",
                table: "Savings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeAccountsId",
                table: "Savings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Savings_TypeAccountsId",
                table: "Savings",
                column: "TypeAccountsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Savings_TypeAccounts_TypeAccountsId",
                table: "Savings",
                column: "TypeAccountsId",
                principalTable: "TypeAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
