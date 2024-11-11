using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWEPP.Migrations
{
    /// <inheritdoc />
    public partial class typeaccesssj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypeAccesHistory_TypeAccesses_TypeAccesId",
                table: "TypeAccesHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_TypeAccesses_TypeAccesId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "TypeAccesses");

            migrationBuilder.DropIndex(
                name: "IX_Users_TypeAccesId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_TypeAccesHistory_TypeAccesId",
                table: "TypeAccesHistory");

            migrationBuilder.DropColumn(
                name: "TypeAccesId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TypeAccesId",
                table: "TypeAccesHistory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeAccesId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeAccesId",
                table: "TypeAccesHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TypeAccesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Typeacces = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAccesses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_TypeAccesId",
                table: "Users",
                column: "TypeAccesId");

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
                name: "FK_Users_TypeAccesses_TypeAccesId",
                table: "Users",
                column: "TypeAccesId",
                principalTable: "TypeAccesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
