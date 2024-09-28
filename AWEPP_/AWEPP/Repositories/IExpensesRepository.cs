using AWEPP.Context;
using AWEPP.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
    public interface IExpensesRepository
    {
        Task<IEnumerable<Expenses>> GetAllExpensesAsync();
        Task<Expenses> GetExpenseByIdAsync(int id);
        Task<Expenses> CreateExpenseAsync(Expenses expense);
        Task<Expenses> UpdateExpenseAsync(Expenses expense);
        Task SoftDeleteExpenseAsync(int id);
    }
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly Aweppcontext _context;

        public ExpensesRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Expenses>> GetAllExpensesAsync()
        {
            return await _context.Expenses.ToListAsync();
        }

        public async Task<Expenses> GetExpenseByIdAsync(int id)
        {
#pragma warning disable CS8603 //possible null return
            return await _context.Expenses.FirstOrDefaultAsync(e => e.Id == id);
        }
#pragma warning disable CS8603 //possible null return
        public async Task<Expenses> CreateExpenseAsync(Expenses expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
            return expense;
        }

        public async Task<Expenses> UpdateExpenseAsync(Expenses expense)
        {
            _context.Entry(expense).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return expense;
        }

        public async Task
     SoftDeleteExpenseAsync(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense != null)
            {
                // Implement soft delete logic here (e.g., set a flag)
                // expense.IsDeleted = true;
                // await _context.SaveChangesAsync();
            }
        }
    }
}