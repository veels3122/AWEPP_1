using AWEPP.Context;
using AWEPP.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
    public interface ITypeExpensesRepository
    {
        Task<IEnumerable<TypeExpenses>> GetAllTypeExpensesAsync();
        Task<TypeExpenses> GetTypeExpenseByIdAsync(int id);
        Task<TypeExpenses> CreateTypeExpenseAsync(TypeExpenses typeExpense);
        Task<TypeExpenses> UpdateTypeExpenseAsync(TypeExpenses typeExpense);
        Task SoftDeleteTypeExpenseAsync(int id);
    }
    public class TypeExpensesRepository : ITypeExpensesRepository
    {
        private readonly Aweppcontext _context;

        public TypeExpensesRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TypeExpenses>> GetAllTypeExpensesAsync()
        {
            return await _context.TypeExpenses.ToListAsync();
        }

        public async Task<TypeExpenses> GetTypeExpenseByIdAsync(int id)
        {
#pragma warning disable CS8603  //posible null return
            return await _context.TypeExpenses.FirstOrDefaultAsync(te => te.Id == id);
        }
#pragma warning disable CS8603  //posible null return
        public async Task<TypeExpenses> CreateTypeExpenseAsync(TypeExpenses typeExpense)
        {
            _context.TypeExpenses.Add(typeExpense);
            await _context.SaveChangesAsync();
            return typeExpense;
        }

        public async Task<TypeExpenses> UpdateTypeExpenseAsync(TypeExpenses typeExpense)
        {
            _context.Entry(typeExpense).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return typeExpense;
        }

        public async Task SoftDeleteTypeExpenseAsync(int id)
        {
            var typeExpense = await _context.TypeExpenses.FindAsync(id);
            if (typeExpense != null)
            {
                // Implement soft delete logic here (e.g., set a flag)
                // typeExpense.IsDeleted = true;
                // await _context.SaveChangesAsync();
            }
        }
    }
}