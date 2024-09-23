using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWEPP.Migrations
{
    /// <inheritdoc />
    public partial class Inictial : Migration
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
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type_expense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Expenses = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_expense", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type_Identys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoIdenty = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_Identys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type_product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeAcces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Typeacces = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAcces", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Type_account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accounts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeproductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Type_account_Type_product_TypeproductsId",
                        column: x => x.TypeproductsId,
                        principalTable: "Type_product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeAccesUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeAccesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAccesUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeAccesUser_TypeAcces_TypeAccesId",
                        column: x => x.TypeAccesId,
                        principalTable: "TypeAcces",
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
            name: "FK_Users_TypeAccesUser_TypeAccesUserId",
            column: x => x.TypeAccesUserId,
            principalTable: "TypeAccesUser",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction); // Cambiado a NoAction
        table.ForeignKey(
            name: "FK_Users_TypeAcces_TypeAccesId",
            column: x => x.TypeAccesId,
            principalTable: "TypeAcces",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction); // Cambiado a NoAction
        table.ForeignKey(
            name: "FK_Users_Usertypes_UsertypeId",
            column: x => x.UsertypeId,
            principalTable: "Usertypes",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction); // Cambiado a NoAction
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
                        name: "FK_Customers_City_CitiesId",
                        column: x => x.CitiesId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Contact_ContactsId",
                        column: x => x.ContactsId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Type_Identys_TypeIdentyId",
                        column: x => x.TypeIdentyId,
                        principalTable: "Type_Identys",
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
                name: "UserHistory",
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
                    table.PrimaryKey("PK_UserHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserHistory_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
    name: "Expense",
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
        table.PrimaryKey("PK_Expense", x => x.Id);
        table.ForeignKey(
            name: "FK_Expense_Customers_CustomerId",
            column: x => x.CustomerId,
            principalTable: "Customers",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction); // Cambiado a NoAction
        table.ForeignKey(
            name: "FK_Expense_Type_account_TypeAccountsId",
            column: x => x.TypeAccountsId,
            principalTable: "Type_account",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction); // Cambiado a NoAction
        table.ForeignKey(
            name: "FK_Expense_Type_expense_TypeExpensesId",
            column: x => x.TypeExpensesId,
            principalTable: "Type_expense",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction); // Cambiado a NoAction
        table.ForeignKey(
            name: "FK_Expense_Type_product_TypeProductsId",
            column: x => x.TypeProductsId,
            principalTable: "Type_product",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction); // Cambiado a NoAction
    });


            migrationBuilder.CreateTable(
    name: "Product",
    columns: table => new
    {
        Id = table.Column<int>(type: "int", nullable: false)
            .Annotation("SqlServer:Identity", "1, 1"),
        Type_productsId = table.Column<int>(type: "int", nullable: false),
        Type_accountsId = table.Column<int>(type: "int", nullable: false),
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
        table.PrimaryKey("PK_Product", x => x.Id);
        table.ForeignKey(
            name: "FK_Product_Banks_BankId",
            column: x => x.BankId,
            principalTable: "Banks",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction); // Cambiado a NoAction
        table.ForeignKey(
            name: "FK_Product_Customers_CustomerId",
            column: x => x.CustomerId,
            principalTable: "Customers",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction); // Cambiado a NoAction
        table.ForeignKey(
            name: "FK_Product_Type_account_Type_accountsId",
            column: x => x.Type_accountsId,
            principalTable: "Type_account",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction); // Cambiado a NoAction
        table.ForeignKey(
            name: "FK_Product_Type_product_Type_productsId",
            column: x => x.Type_productsId,
            principalTable: "Type_product",
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
            name: "FK_Savings_Product_ProductsId",
            column: x => x.ProductsId,
            principalTable: "Product",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction); // Cambiado a NoAction
        table.ForeignKey(
            name: "FK_Savings_Type_account_TypeAccountsId",
            column: x => x.TypeAccountsId,
            principalTable: "Type_account",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction); // Cambiado a NoAction
        table.ForeignKey(
            name: "FK_Savings_Type_product_TypeProductsId",
            column: x => x.TypeProductsId,
            principalTable: "Type_product",
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
                name: "IX_Expense_CustomerId",
                table: "Expense",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_TypeAccountsId",
                table: "Expense",
                column: "TypeAccountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_TypeExpensesId",
                table: "Expense",
                column: "TypeExpensesId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_TypeProductsId",
                table: "Expense",
                column: "TypeProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BankId",
                table: "Product",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CustomerId",
                table: "Product",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Type_accountsId",
                table: "Product",
                column: "Type_accountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Type_productsId",
                table: "Product",
                column: "Type_productsId");

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
                name: "IX_Type_account_TypeproductsId",
                table: "Type_account",
                column: "TypeproductsId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeAccesUser_TypeAccesId",
                table: "TypeAccesUser",
                column: "TypeAccesId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHistory_UserId",
                table: "UserHistory",
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
                name: "Expense");

            migrationBuilder.DropTable(
                name: "Savings");

            migrationBuilder.DropTable(
                name: "UserHistory");

            migrationBuilder.DropTable(
                name: "Type_expense");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Type_account");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Type_Identys");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Type_product");

            migrationBuilder.DropTable(
                name: "TypeAccesUser");

            migrationBuilder.DropTable(
                name: "Usertypes");

            migrationBuilder.DropTable(
                name: "TypeAcces");
        }
    }
}
