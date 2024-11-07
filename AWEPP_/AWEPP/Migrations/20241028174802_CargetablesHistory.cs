using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWEPP.Migrations
{
    /// <inheritdoc />
    public partial class CargetablesHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberAccount",
                table: "Products",
                newName: "NumberAccount");

            
           
           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserHistories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TypeProducts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TypeIdentities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TypeExpenses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TypeAccounts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TypeAccessUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TypeAccesses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Savings");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Banks");

            migrationBuilder.RenameColumn(
                name: "NumberAccount",
                table: "Products",
                newName: "NumberAcount");
        }
    }
}
