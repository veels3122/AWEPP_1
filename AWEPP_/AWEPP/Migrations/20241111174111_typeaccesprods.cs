using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWEPP.Migrations
{
    /// <inheritdoc />
    public partial class typeaccesprods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypeAccesses_TypeAccessUsers_TypeAccesUserId",
                table: "TypeAccesses");

            migrationBuilder.DropIndex(
                name: "IX_TypeAccesses_TypeAccesUserId",
                table: "TypeAccesses");

            migrationBuilder.DropColumn(
                name: "TypeAccesUserId",
                table: "TypeAccesses");

            migrationBuilder.AddColumn<int>(
                name: "TypeAccesUserId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_TypeAccesUserId",
                table: "Users",
                column: "TypeAccesUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_TypeAccessUsers_TypeAccesUserId",
                table: "Users",
                column: "TypeAccesUserId",
                principalTable: "TypeAccessUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_TypeAccessUsers_TypeAccesUserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TypeAccesUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TypeAccesUserId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "TypeAccesUserId",
                table: "TypeAccesses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TypeAccesses_TypeAccesUserId",
                table: "TypeAccesses",
                column: "TypeAccesUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TypeAccesses_TypeAccessUsers_TypeAccesUserId",
                table: "TypeAccesses",
                column: "TypeAccesUserId",
                principalTable: "TypeAccessUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
