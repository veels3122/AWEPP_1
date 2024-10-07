using AWEPP.Context;
using AWEPP.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
    public interface IExpenseRepository
    {
        Task<IEnumerable<Expense>> GetAllExpensesAsync();
        Task<Expense> GetExpenseByIdAsync(int id);
        Task<Expense> CreateExpenseAsync(Expense expense);
        Task<Expense> UpdateExpenseAsync(Expense expense);
        Task SoftDeleteExpenseAsync(int id);
    }

    public class ExpenseRepository : IExpenseRepository
    {
        private readonly Aweppcontext _context;

        public ExpenseRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Expense>> GetAllExpensesAsync()
        {
            return await _context.Expenses
                .ToListAsync();
        }

        public async Task<Expense> GetExpenseByIdAsync(int id)
        {
#pragma warning disable CS8603
            return await _context.Expenses
                .FirstOrDefaultAsync(c => c.Id == id);
#pragma warning disable CS8603
        }

        public async Task<Expense> CreateExpenseAsync(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
            return expense;
        }

        public async Task<Expense> UpdateExpenseAsync(Expense expense)
        {
            var existingExpense = await _context.Expenses.FindAsync(expense.Id);

            if (existingExpense == null)
            {
                throw new NotFoundException("Expense not found");
            }

            // Actualiza las propiedades según sea necesario
            existingExpense.Description = expense.Description;
            existingExpense.TotalExpense = expense.TotalExpense;
            existingExpense.NumberFee = expense.NumberFee;
            existingExpense.DateExpense = expense.DateExpense;
            existingExpense.DateStart = expense.DateStart;
            existingExpense.DateEnd = expense.DateEnd;
            existingExpense.BalanceFee = expense.BalanceFee;
            existingExpense.TypeExpensesId = expense.TypeExpensesId;
            existingExpense.TypeAccountsId = expense.TypeAccountsId;
            existingExpense.TypeProductsId = expense.TypeProductsId;
            existingExpense.CustomerId = expense.CustomerId;

            _context.Entry(existingExpense).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return existingExpense;
        }

        public async Task SoftDeleteExpenseAsync(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                await _context.SaveChangesAsync();
            }
        }
    }
}