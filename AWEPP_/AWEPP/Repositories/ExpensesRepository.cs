using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AWEPP.Repositories
{
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly Aweppcontext _context;

        public ExpensesRepository(Aweppcontext context)
        {
            _context = context;
        }

        // Método para crear un nuevo gasto
        public async Task CreateExpensesAsync(Expenses expenses)
        {
            await _context.Expensess.AddAsync(expenses); // Añadir nuevo registro
            await _context.SaveChangesAsync(); // Guardar cambios
        }

        // Obtener todos los gastos que no están eliminados
        public async Task<IEnumerable<Expenses>> GetAllExpensesAsync()
        {
            return await _context.Expensess
                .Where(s => !s.IsDeleted) // Excluir los eliminados
                .ToListAsync();
        }

        // Obtener gasto por su Id, excluyendo eliminados
        public async Task<Expenses> GetExpensesByIdAsync(int Id)
        {
            return await _context.Expensess
                .FirstOrDefaultAsync(s => s.Id == Id && !s.IsDeleted);
        }

        // Eliminar gasto de manera lógica (Soft Delete)
        public async Task SoftDeleteExpensesAsync(int Id)
        {
            var expenses = await _context.Expensess.FindAsync(Id);
            if (expenses != null)
            {
                expenses.IsDeleted = true; // Marcar como eliminado
                await _context.SaveChangesAsync(); // Guardar cambios
            }
        }

        // Actualizar un gasto existente
        public async Task UpdateExpensesAsync(Expenses expenses)
        {
            var existingExpenses = await _context.Expensess.FindAsync(expenses.Id);
            if (existingExpenses != null)
            {
                // Actualizar campos
                existingExpenses.Description = expenses.Description;
                existingExpenses.TotalExpense = expenses.TotalExpense;
                existingExpenses.NumberFee = expenses.NumberFee;
                existingExpenses.DateExpense = expenses.DateExpense;
                existingExpenses.DateStart = expenses.DateStart;
                existingExpenses.DateEnd = expenses.DateEnd;
                existingExpenses.BalanceFee = expenses.BalanceFee;
                existingExpenses.TypeExpenses = expenses.TypeExpenses;
                existingExpenses.TypeAccounts = expenses.TypeAccounts;
                existingExpenses.Customer = expenses.Customer;

                // Guardar cambios
                await _context.SaveChangesAsync();
            }
        }
    }
}
