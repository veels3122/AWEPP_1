using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWEPP.Migrations
{
    /// <inheritdoc />
    public partial class AddUsertype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsertypeId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Usertypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usertypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UsertypeId",
                table: "Users",
                column: "UsertypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Usertypes_UsertypeId",
                table: "Users",
                column: "UsertypeId",
                principalTable: "Usertypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Usertypes_UsertypeId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Usertypes");

            migrationBuilder.DropIndex(
                name: "IX_Users_UsertypeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UsertypeId",
                table: "Users");
        }
    }
}
