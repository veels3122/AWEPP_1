using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AWEPP.Migrations
{
    /// <inheritdoc />
    public partial class triggers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Triggers for CitiesHistory
            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_CitiesHistory_AfterInsert
                ON dbo.CitiesHistory
                AFTER INSERT
                AS
                BEGIN
                    PRINT 'Nuevo registro insertado en CitiesHistory'
                END;
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_CitiesHistory_AfterUpdate
                ON dbo.CitiesHistory
                AFTER UPDATE
                AS
                BEGIN
                    PRINT 'Registro actualizado en CitiesHistory'
                END;
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_CitiesHistory_AfterDelete
                ON dbo.CitiesHistory
                AFTER DELETE
                AS
                BEGIN
                    PRINT 'Registro eliminado de CitiesHistory'
                END;
            ");

            // Triggers for ContactsHistory
            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_ContactsHistory_AfterInsert
                ON dbo.ContactsHistory
                AFTER INSERT
                AS
                BEGIN
                    PRINT 'Nuevo registro insertado en ContactsHistory'
                END;
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_ContactsHistory_AfterUpdate
                ON dbo.ContactsHistory
                AFTER UPDATE
                AS
                BEGIN
                    PRINT 'Registro actualizado en ContactsHistory'
                END;
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_ContactsHistory_AfterDelete
                ON dbo.ContactsHistory
                AFTER DELETE
                AS
                BEGIN
                    PRINT 'Registro eliminado de ContactsHistory'
                END;
            ");

            // Triggers for CustomerHistory
            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_CustomerHistory_AfterInsert
                ON dbo.CustomerHistory
                AFTER INSERT
                AS
                BEGIN
                    PRINT 'Nuevo registro insertado en CustomerHistory'
                END;
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_CustomerHistory_AfterUpdate
                ON dbo.CustomerHistory
                AFTER UPDATE
                AS
                BEGIN
                    PRINT 'Registro actualizado en CustomerHistory'
                END;
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_CustomerHistory_AfterDelete
                ON dbo.CustomerHistory
                AFTER DELETE
                AS
                BEGIN
                    PRINT 'Registro eliminado de CustomerHistory'
                END;
            ");

            // Triggers for ExpensesHistory
            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_ExpensesHistory_AfterInsert
                ON dbo.ExpensesHistory
                AFTER INSERT
                AS
                BEGIN
                    PRINT 'Nuevo registro insertado en ExpensesHistory'
                END;
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_ExpensesHistory_AfterUpdate
                ON dbo.ExpensesHistory
                AFTER UPDATE
                AS
                BEGIN
                    PRINT 'Registro actualizado en ExpensesHistory'
                END;
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_ExpensesHistory_AfterDelete
                ON dbo.ExpensesHistory
                AFTER DELETE
                AS
                BEGIN
                    PRINT 'Registro eliminado de ExpensesHistory'
                END;
            ");

            // Triggers for SavingHistory
            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_SavingHistory_AfterInsert
                ON dbo.SavingHistory
                AFTER INSERT
                AS
                BEGIN
                    PRINT 'Nuevo registro insertado en SavingHistory'
                END;
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_SavingHistory_AfterUpdate
                ON dbo.SavingHistory
                AFTER UPDATE
                AS
                BEGIN
                    PRINT 'Registro actualizado en SavingHistory'
                END;
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_SavingHistory_AfterDelete
                ON dbo.SavingHistory
                AFTER DELETE
                AS
                BEGIN
                    PRINT 'Registro eliminado de SavingHistory'
                END;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop triggers for CitiesHistory
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_CitiesHistory_AfterInsert;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_CitiesHistory_AfterUpdate;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_CitiesHistory_AfterDelete;");

            // Drop triggers for ContactsHistory
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_ContactsHistory_AfterInsert;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_ContactsHistory_AfterUpdate;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_ContactsHistory_AfterDelete;");

            // Drop triggers for CustomerHistory
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_CustomerHistory_AfterInsert;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_CustomerHistory_AfterUpdate;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_CustomerHistory_AfterDelete;");

            // Drop triggers for ExpensesHistory
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_ExpensesHistory_AfterInsert;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_ExpensesHistory_AfterUpdate;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_ExpensesHistory_AfterDelete;");

            // Drop triggers for SavingHistory
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_SavingHistory_AfterInsert;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_SavingHistory_AfterUpdate;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_SavingHistory_AfterDelete;");
        }
    }
}
