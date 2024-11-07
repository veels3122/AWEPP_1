using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWEPP.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditLogTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "AuditLogs",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Action = table.Column<string>(maxLength: 100, nullable: false),
                UserId = table.Column<int>(nullable: true),
                Timestamp = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                Details = table.Column<string>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AuditLogs", x => x.Id);
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "AuditLogs");
        }
    }
}
