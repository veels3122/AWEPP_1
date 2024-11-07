using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWEPP.Migrations
{
    /// <inheritdoc />
    public partial class Historietables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    Datecreate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modifed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datemodified = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankHistory_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CitiesHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CitiesId = table.Column<int>(type: "int", nullable: false),
                    Datecreate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modifed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datemodified = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitiesHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CitiesHistory_Cities_CitiesId",
                        column: x => x.CitiesId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactsHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactsId = table.Column<int>(type: "int", nullable: false),
                    Datecreate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modifed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datemodified = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactsHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactsHistory_Contacts_ContactsId",
                        column: x => x.ContactsId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Datecreate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modifed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datemodified = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerHistory_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpensesHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpensesId = table.Column<int>(type: "int", nullable: false),
                    Datecreate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modifed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datemodified = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpensesHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpensesHistory_Expenses_ExpensesId",
                        column: x => x.ExpensesId,
                        principalTable: "Expenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    Datecreate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modifed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datemodified = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsHistory_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavingHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SavingId = table.Column<int>(type: "int", nullable: false),
                    Datecreate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modifed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datemodified = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavingHistory_Savings_SavingId",
                        column: x => x.SavingId,
                        principalTable: "Savings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeAccesHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeAccesId = table.Column<int>(type: "int", nullable: false),
                    Datecreate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modifed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datemodified = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAccesHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeAccesHistory_TypeAccesses_TypeAccesId",
                        column: x => x.TypeAccesId,
                        principalTable: "TypeAccesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeAccesUserHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeAccesUserId = table.Column<int>(type: "int", nullable: false),
                    Datecreate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modifed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datemodified = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAccesUserHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeAccesUserHistory_TypeAccessUsers_TypeAccesUserId",
                        column: x => x.TypeAccesUserId,
                        principalTable: "TypeAccessUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeAccountsHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeAccountsId = table.Column<int>(type: "int", nullable: false),
                    Datecreate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modifed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datemodified = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAccountsHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeAccountsHistory_TypeAccounts_TypeAccountsId",
                        column: x => x.TypeAccountsId,
                        principalTable: "TypeAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeExpensesHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeExpensesId = table.Column<int>(type: "int", nullable: false),
                    Datecreate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modifed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datemodified = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeExpensesHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeExpensesHistory_TypeExpenses_TypeExpensesId",
                        column: x => x.TypeExpensesId,
                        principalTable: "TypeExpenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeIdentyHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeIdentyId = table.Column<int>(type: "int", nullable: false),
                    Datecreate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modifed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datemodified = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeIdentyHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeIdentyHistory_TypeIdentities_TypeIdentyId",
                        column: x => x.TypeIdentyId,
                        principalTable: "TypeIdentities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeProductsHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeProductsId = table.Column<int>(type: "int", nullable: false),
                    Datecreate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modifed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datemodified = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeProductsHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeProductsHistory_TypeProducts_TypeProductsId",
                        column: x => x.TypeProductsId,
                        principalTable: "TypeProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsertypeHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsertypeId = table.Column<int>(type: "int", nullable: false),
                    Datecreate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modifed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datemodified = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsertypeHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsertypeHistory_UserTypes_UsertypeId",
                        column: x => x.UsertypeId,
                        principalTable: "UserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankHistory_BankId",
                table: "BankHistory",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_CitiesHistory_CitiesId",
                table: "CitiesHistory",
                column: "CitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactsHistory_ContactsId",
                table: "ContactsHistory",
                column: "ContactsId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerHistory_CustomerId",
                table: "CustomerHistory",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpensesHistory_ExpensesId",
                table: "ExpensesHistory",
                column: "ExpensesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsHistory_ProductsId",
                table: "ProductsHistory",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_SavingHistory_SavingId",
                table: "SavingHistory",
                column: "SavingId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeAccesHistory_TypeAccesId",
                table: "TypeAccesHistory",
                column: "TypeAccesId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeAccesUserHistory_TypeAccesUserId",
                table: "TypeAccesUserHistory",
                column: "TypeAccesUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeAccountsHistory_TypeAccountsId",
                table: "TypeAccountsHistory",
                column: "TypeAccountsId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeExpensesHistory_TypeExpensesId",
                table: "TypeExpensesHistory",
                column: "TypeExpensesId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeIdentyHistory_TypeIdentyId",
                table: "TypeIdentyHistory",
                column: "TypeIdentyId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeProductsHistory_TypeProductsId",
                table: "TypeProductsHistory",
                column: "TypeProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_UsertypeHistory_UsertypeId",
                table: "UsertypeHistory",
                column: "UsertypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankHistory");

            migrationBuilder.DropTable(
                name: "CitiesHistory");

            migrationBuilder.DropTable(
                name: "ContactsHistory");

            migrationBuilder.DropTable(
                name: "CustomerHistory");

            migrationBuilder.DropTable(
                name: "ExpensesHistory");

            migrationBuilder.DropTable(
                name: "ProductsHistory");

            migrationBuilder.DropTable(
                name: "SavingHistory");

            migrationBuilder.DropTable(
                name: "TypeAccesHistory");

            migrationBuilder.DropTable(
                name: "TypeAccesUserHistory");

            migrationBuilder.DropTable(
                name: "TypeAccountsHistory");

            migrationBuilder.DropTable(
                name: "TypeExpensesHistory");

            migrationBuilder.DropTable(
                name: "TypeIdentyHistory");

            migrationBuilder.DropTable(
                name: "TypeProductsHistory");

            migrationBuilder.DropTable(
                name: "UsertypeHistory");
        }
    }
}
