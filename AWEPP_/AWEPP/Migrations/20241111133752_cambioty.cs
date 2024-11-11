using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWEPP.Migrations
{
    /// <inheritdoc />
    public partial class cambioty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypeAccesUserHistory_TypeAccessUsers_TypeAccesUserId",
                table: "TypeAccesUserHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_TypeAccessUsers_TypeAccesUserId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "TypeAccessUsers");

            migrationBuilder.DropIndex(
                name: "IX_Users_TypeAccesUserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_TypeAccesUserHistory_TypeAccesUserId",
                table: "TypeAccesUserHistory");

            migrationBuilder.DropColumn(
                name: "TypeAccesUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TypeAccesUserId",
                table: "TypeAccesUserHistory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeAccesUserId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeAccesUserId",
                table: "TypeAccesUserHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TypeAccessUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeAccesId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAccessUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeAccessUsers_TypeAccesses_TypeAccesId",
                        column: x => x.TypeAccesId,
                        principalTable: "TypeAccesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_TypeAccesUserId",
                table: "Users",
                column: "TypeAccesUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeAccesUserHistory_TypeAccesUserId",
                table: "TypeAccesUserHistory",
                column: "TypeAccesUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeAccessUsers_TypeAccesId",
                table: "TypeAccessUsers",
                column: "TypeAccesId");

            migrationBuilder.AddForeignKey(
                name: "FK_TypeAccesUserHistory_TypeAccessUsers_TypeAccesUserId",
                table: "TypeAccesUserHistory",
                column: "TypeAccesUserId",
                principalTable: "TypeAccessUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_TypeAccessUsers_TypeAccesUserId",
                table: "Users",
                column: "TypeAccesUserId",
                principalTable: "TypeAccessUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
