using AWEPP.Context;
using AWEPP.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
  
    public class TypeExpensesRepository : ITypeExpensesRepository
    {
        private readonly Aweppcontext _context;

        public TypeExpensesRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TypeExpenses>> GetAllTypeExpensesAsync()
        {
            return await _context.Expenses.ToListAsync();
        }

        public async Task<TypeExpenses> GetTypeExpensesByIdAsync(int id)
        {
#pragma warning disable CS8603 //posible null
            return await _context.Expenses.FindAsync(id);
        }
#pragma warning disable CS8603 //posible null
        public async Task<TypeExpenses> CreateTypeExpensesAsync(TypeExpenses typeExpenses)
        {
            _context.Expenses.Add(typeExpenses);
            await _context.SaveChangesAsync();
            return typeExpenses;
        }

        public async Task<TypeExpenses> UpdateTypeExpensesAsync(TypeExpenses typeExpenses)
        {
            _context.Entry(typeExpenses).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return typeExpenses;
        }

        public async Task SoftDeleteTypeExpensesAsync(int id)
        {
            var typeExpenses = await _context.Expenses.FindAsync(id);

            if (typeExpenses != null)
            {
                _context.Expenses.Remove(typeExpenses);
                await _context.SaveChangesAsync();
            }
        }
    }
}