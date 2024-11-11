using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWEPP.Migrations
{
    /// <inheritdoc />
    public partial class typeaccesprobe2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeAccesUserId",
                table: "TypeAccesses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeAccesId",
                table: "TypeAccesHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TypeAccesses_TypeAccesUserId",
                table: "TypeAccesses",
                column: "TypeAccesUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeAccesHistory_TypeAccesId",
                table: "TypeAccesHistory",
                column: "TypeAccesId");

            migrationBuilder.AddForeignKey(
                name: "FK_TypeAccesHistory_TypeAccesses_TypeAccesId",
                table: "TypeAccesHistory",
                column: "TypeAccesId",
                principalTable: "TypeAccesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeAccesses_TypeAccessUsers_TypeAccesUserId",
                table: "TypeAccesses",
                column: "TypeAccesUserId",
                principalTable: "TypeAccessUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypeAccesHistory_TypeAccesses_TypeAccesId",
                table: "TypeAccesHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeAccesses_TypeAccessUsers_TypeAccesUserId",
                table: "TypeAccesses");

            migrationBuilder.DropIndex(
                name: "IX_TypeAccesses_TypeAccesUserId",
                table: "TypeAccesses");

            migrationBuilder.DropIndex(
                name: "IX_TypeAccesHistory_TypeAccesId",
                table: "TypeAccesHistory");

            migrationBuilder.DropColumn(
                name: "TypeAccesUserId",
                table: "TypeAccesses");

            migrationBuilder.DropColumn(
                name: "TypeAccesId",
                table: "TypeAccesHistory");
        }
    }
}
