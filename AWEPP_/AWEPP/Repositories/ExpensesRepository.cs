using AWEPP.Context;
using AWEPP.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
 
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly Aweppcontext _context;

        public ExpensesRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Expenses>> GetAllExpensesAsync()
        {
            return await _context.Expense
                .ToListAsync();
        }

        public async Task<Expenses> GetExpenseByIdAsync(int id)
        {
#pragma warning disable CS8603
            return await _context.Expense
                .FirstOrDefaultAsync(c => c.Id == id);
#pragma warning disable CS8603
        }

        public async Task<Expenses> CreateExpenseAsync(Expenses expenses)
        {
            _context.Expense.Add(expenses);
            await _context.SaveChangesAsync();
            return expenses;
        }

        public async Task<Expenses> UpdateExpenseAsync(Expenses expenses)
        {
            var existingExpenses = await _context.Expense.FindAsync(expenses.Id);

            if (existingExpenses == null)
            {
                throw new NotFoundException("Expense not found");
            }

            // Actualiza las propiedades según sea necesario
            existingExpenses.Description = expenses.Description;
            existingExpenses.TotalExpense = expenses.TotalExpense;
            existingExpenses.NumberFee = expenses.NumberFee;
            existingExpenses.DateExpense = expenses.DateExpense;
            existingExpenses.DateStart = expenses.DateStart;
            existingExpenses.DateEnd = expenses.DateEnd;
            existingExpenses.BalanceFee = expenses.BalanceFee;

            _context.Entry(existingExpenses).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return existingExpenses;
        }

        public async Task SoftDeleteExpenseAsync(int id)
        {
            var expense = await _context.Expense.FindAsync(id);
            if (expense != null)
            {
                _context.Expense.Remove(expense);
                await _context.SaveChangesAsync();
            }
        }
    }
}