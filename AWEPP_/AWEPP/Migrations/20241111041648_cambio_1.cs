using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWEPP.Migrations
{
    /// <inheritdoc />
    public partial class cambio_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_TypeProducts_TypeProductsId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Savings_TypeProducts_TypeProductsId",
                table: "Savings");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeAccounts_TypeProducts_TypeproductsId",
                table: "TypeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeProductsHistory_TypeProducts_TypeProductsId",
                table: "TypeProductsHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeProducts",
                table: "TypeProducts");

            migrationBuilder.RenameTable(
                name: "TypeProducts",
                newName: "TypeProductss");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeProductss",
                table: "TypeProductss",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TypeProductss_TypeProductsId",
                table: "Products",
                column: "TypeProductsId",
                principalTable: "TypeProductss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Savings_TypeProductss_TypeProductsId",
                table: "Savings",
                column: "TypeProductsId",
                principalTable: "TypeProductss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeAccounts_TypeProductss_TypeproductsId",
                table: "TypeAccounts",
                column: "TypeproductsId",
                principalTable: "TypeProductss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeProductsHistory_TypeProductss_TypeProductsId",
                table: "TypeProductsHistory",
                column: "TypeProductsId",
                principalTable: "TypeProductss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_TypeProductss_TypeProductsId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Savings_TypeProductss_TypeProductsId",
                table: "Savings");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeAccounts_TypeProductss_TypeproductsId",
                table: "TypeAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeProductsHistory_TypeProductss_TypeProductsId",
                table: "TypeProductsHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeProductss",
                table: "TypeProductss");

            migrationBuilder.RenameTable(
                name: "TypeProductss",
                newName: "TypeProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeProducts",
                table: "TypeProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TypeProducts_TypeProductsId",
                table: "Products",
                column: "TypeProductsId",
                principalTable: "TypeProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Savings_TypeProducts_TypeProductsId",
                table: "Savings",
                column: "TypeProductsId",
                principalTable: "TypeProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeAccounts_TypeProducts_TypeproductsId",
                table: "TypeAccounts",
                column: "TypeproductsId",
                principalTable: "TypeProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeProductsHistory_TypeProducts_TypeProductsId",
                table: "TypeProductsHistory",
                column: "TypeProductsId",
                principalTable: "TypeProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
