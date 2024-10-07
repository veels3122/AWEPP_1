using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWEPP.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Banks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeAccesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Typeacces = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAccesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Expenses = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeExpenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeIdentities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoIdenty = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeIdentities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeAccessUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeAccesId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "TypeAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accounts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeproductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeAccounts_TypeProducts_TypeproductsId",
                        column: x => x.TypeproductsId,
                        principalTable: "TypeProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

                               migrationBuilder.CreateTable(
                    name: "Users",
                    columns: table => new
                    {
                        Id = table.Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Passaword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Modified = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        UsertypeId = table.Column<int>(type: "int", nullable: false),
                        TypeAccesId = table.Column<int>(type: "int", nullable: false),
                        TypeAccesUserId = table.Column<int>(type: "int", nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Users", x => x.Id);
                        table.ForeignKey(
                            name: "FK_Users_TypeAccessUsers_TypeAccesUserId",
                            column: x => x.TypeAccesUserId,
                            principalTable: "TypeAccessUsers",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Restrict); // Cambiado a Restrict
                        table.ForeignKey(
                            name: "FK_Users_TypeAccesses_TypeAccesId",
                            column: x => x.TypeAccesId,
                            principalTable: "TypeAccesses",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Restrict); // Cambiado a Restrict
                        table.ForeignKey(
                            name: "FK_Users_UserTypes_UsertypeId",
                            column: x => x.UsertypeId,
                            principalTable: "UserTypes",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Restrict); // Cambiado a Restrict
                    });



            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumIdenty = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TypeIdentyId = table.Column<int>(type: "int", nullable: false),
                    ContactsId = table.Column<int>(type: "int", nullable: false),
                    CitiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Cities_CitiesId",
                        column: x => x.CitiesId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Contacts_ContactsId",
                        column: x => x.ContactsId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_TypeIdentities_TypeIdentyId",
                        column: x => x.TypeIdentyId,
                        principalTable: "TypeIdentities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Datecreate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modifed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datemodified = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserHistories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
    name: "Expenses",
    columns: table => new
    {
        Id = table.Column<int>(type: "int", nullable: false)
            .Annotation("SqlServer:Identity", "1, 1"),
        Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
        TotalExpense = table.Column<string>(type: "nvarchar(max)", nullable: false),
        NumberFee = table.Column<string>(type: "nvarchar(max)", nullable: false),
        DateExpense = table.Column<string>(type: "nvarchar(max)", nullable: false),
        DateStart = table.Column<string>(type: "nvarchar(max)", nullable: false),
        DateEnd = table.Column<string>(type: "nvarchar(max)", nullable: false),
        BalanceFee = table.Column<string>(type: "nvarchar(max)", nullable: false),
        TypeExpensesId = table.Column<int>(type: "int", nullable: false),
        TypeAccountsId = table.Column<int>(type: "int", nullable: false),
        TypeProductsId = table.Column<int>(type: "int", nullable: false),
        CustomerId = table.Column<int>(type: "int", nullable: false)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_Expenses", x => x.Id);
        table.ForeignKey(
            name: "FK_Expenses_Customers_CustomerId",
            column: x => x.CustomerId,
            principalTable: "Customers",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict); // Cambiado a Restrict
        table.ForeignKey(
            name: "FK_Expenses_TypeAccounts_TypeAccountsId",
            column: x => x.TypeAccountsId,
            principalTable: "TypeAccounts",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict); // Cambiado a Restrict
        table.ForeignKey(
            name: "FK_Expenses_TypeExpenses_TypeExpensesId",
            column: x => x.TypeExpensesId,
            principalTable: "TypeExpenses",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict); // Cambiado a Restrict
        table.ForeignKey(
            name: "FK_Expenses_TypeProducts_TypeProductsId",
            column: x => x.TypeProductsId,
            principalTable: "TypeProducts",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict); // Cambiado a Restrict
    });


            migrationBuilder.CreateTable(
    name: "Products",
    columns: table => new
    {
        Id = table.Column<int>(type: "int", nullable: false)
            .Annotation("SqlServer:Identity", "1, 1"),
        TypeAccountsId = table.Column<int>(type: "int", nullable: false),
        TypeProductsId = table.Column<int>(type: "int", nullable: false),
        BankId = table.Column<int>(type: "int", nullable: false),
        Account = table.Column<string>(type: "nvarchar(max)", nullable: false),
        NumberAcount = table.Column<string>(type: "nvarchar(max)", nullable: false),
        TotalBalance = table.Column<string>(type: "nvarchar(max)", nullable: false),
        PartialBalance = table.Column<string>(type: "nvarchar(max)", nullable: false),
        Debt = table.Column<string>(type: "nvarchar(max)", nullable: false),
        DatePayment = table.Column<string>(type: "nvarchar(max)", nullable: false),
        Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
        CustomerId = table.Column<int>(type: "int", nullable: false)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_Products", x => x.Id);
        table.ForeignKey(
            name: "FK_Products_Banks_BankId",
            column: x => x.BankId,
            principalTable: "Banks",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction); // Cambiado a NoAction
        table.ForeignKey(
            name: "FK_Products_Customers_CustomerId",
            column: x => x.CustomerId,
            principalTable: "Customers",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction); // Cambiado a NoAction
        table.ForeignKey(
            name: "FK_Products_TypeAccounts_TypeAccountsId",
            column: x => x.TypeAccountsId,
            principalTable: "TypeAccounts",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction); // Cambiado a NoAction
        table.ForeignKey(
            name: "FK_Products_TypeProducts_TypeProductsId",
            column: x => x.TypeProductsId,
            principalTable: "TypeProducts",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction); // Cambiado a NoAction
    });


            migrationBuilder.CreateTable(
    name: "Savings",
    columns: table => new
    {
        Id = table.Column<int>(type: "int", nullable: false)
            .Annotation("SqlServer:Identity", "1, 1"),
        dateStar = table.Column<string>(type: "nvarchar(max)", nullable: false),
        dateEnd = table.Column<string>(type: "nvarchar(max)", nullable: false),
        SavingAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
        paymentAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
        Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
        TypeProductsId = table.Column<int>(type: "int", nullable: false),
        TypeAccountsId = table.Column<int>(type: "int", nullable: false),
        ProductsId = table.Column<int>(type: "int", nullable: false),
        BankId = table.Column<int>(type: "int", nullable: false),
        CustomerId = table.Column<int>(type: "int", nullable: false)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_Savings", x => x.Id);
        table.ForeignKey(
            name: "FK_Savings_Banks_BankId",
            column: x => x.BankId,
            principalTable: "Banks",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction); // Cambiado a NoAction
        table.ForeignKey(
            name: "FK_Savings_Customers_CustomerId",
            column: x => x.CustomerId,
            principalTable: "Customers",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction); // Cambiado a NoAction
        table.ForeignKey(
            name: "FK_Savings_Products_ProductsId",
            column: x => x.ProductsId,
            principalTable: "Products",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction); // Cambiado a NoAction
        table.ForeignKey(
            name: "FK_Savings_TypeAccounts_TypeAccountsId",
            column: x => x.TypeAccountsId,
            principalTable: "TypeAccounts",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction); // Cambiado a NoAction
        table.ForeignKey(
            name: "FK_Savings_TypeProducts_TypeProductsId",
            column: x => x.TypeProductsId,
            principalTable: "TypeProducts",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction); // Cambiado a NoAction
    });


            migrationBuilder.CreateIndex(
                name: "IX_Customers_CitiesId",
                table: "Customers",
                column: "CitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ContactsId",
                table: "Customers",
                column: "ContactsId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_TypeIdentyId",
                table: "Customers",
                column: "TypeIdentyId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CustomerId",
                table: "Expenses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_TypeAccountsId",
                table: "Expenses",
                column: "TypeAccountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_TypeExpensesId",
                table: "Expenses",
                column: "TypeExpensesId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_TypeProductsId",
                table: "Expenses",
                column: "TypeProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BankId",
                table: "Products",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CustomerId",
                table: "Products",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeAccountsId",
                table: "Products",
                column: "TypeAccountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeProductsId",
                table: "Products",
                column: "TypeProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Savings_BankId",
                table: "Savings",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Savings_CustomerId",
                table: "Savings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Savings_ProductsId",
                table: "Savings",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Savings_TypeAccountsId",
                table: "Savings",
                column: "TypeAccountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Savings_TypeProductsId",
                table: "Savings",
                column: "TypeProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeAccessUsers_TypeAccesId",
                table: "TypeAccessUsers",
                column: "TypeAccesId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeAccounts_TypeproductsId",
                table: "TypeAccounts",
                column: "TypeproductsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHistories_UserId",
                table: "UserHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TypeAccesId",
                table: "Users",
                column: "TypeAccesId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TypeAccesUserId",
                table: "Users",
                column: "TypeAccesUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UsertypeId",
                table: "Users",
                column: "UsertypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Savings");

            migrationBuilder.DropTable(
                name: "UserHistories");

            migrationBuilder.DropTable(
                name: "TypeExpenses");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "TypeAccounts");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "TypeIdentities");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "TypeProducts");

            migrationBuilder.DropTable(
                name: "TypeAccessUsers");

            migrationBuilder.DropTable(
                name: "UserTypes");

            migrationBuilder.DropTable(
                name: "TypeAccesses");
        }
    }
}
