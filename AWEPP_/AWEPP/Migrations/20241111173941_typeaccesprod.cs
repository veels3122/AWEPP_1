using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWEPP.Migrations
{
    /// <inheritdoc />
    public partial class typeaccesprod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeAccesId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_TypeAccesId",
                table: "Users",
                column: "TypeAccesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_TypeAccesses_TypeAccesId",
                table: "Users",
                column: "TypeAccesId",
                principalTable: "TypeAccesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_TypeAccesses_TypeAccesId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TypeAccesId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TypeAccesId",
                table: "Users");
        }
    }
}
