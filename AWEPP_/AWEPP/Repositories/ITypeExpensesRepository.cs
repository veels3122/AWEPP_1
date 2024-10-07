using AWEPP.Context;
using AWEPP.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
    public interface ITypeExpensesRepository
    {
        Task<IEnumerable<TypeExpense>> GetAllTypeExpensesAsync();
        Task<TypeExpense> GetTypeExpensesByIdAsync(int id);
        Task<TypeExpense> CreateTypeExpensesAsync(TypeExpense typeExpenses);
        Task<TypeExpense> UpdateTypeExpensesAsync(TypeExpense typeExpenses);
        Task SoftDeleteTypeExpensesAsync(int id);
    }

    public class TypeExpensesRepository : ITypeExpensesRepository
    {
        private readonly Aweppcontext _context;

        public TypeExpensesRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TypeExpense>> GetAllTypeExpensesAsync()
        {
            return await _context.TypeExpenses.ToListAsync();
        }

        public async Task<TypeExpense> GetTypeExpensesByIdAsync(int id)
        {
#pragma warning disable CS8603 //posible null
            return await _context.TypeExpenses.FindAsync(id);
        }
#pragma warning disable CS8603 //posible null
        public async Task<TypeExpense> CreateTypeExpensesAsync(TypeExpense typeExpenses)
        {
            _context.TypeExpenses.Add(typeExpenses);
            await _context.SaveChangesAsync();
            return typeExpenses;
        }

        public async Task<TypeExpense> UpdateTypeExpensesAsync(TypeExpense typeExpenses)
        {
            _context.Entry(typeExpenses).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return typeExpenses;
        }

        public async Task SoftDeleteTypeExpensesAsync(int id)
        {
            var typeExpenses = await _context.TypeExpenses.FindAsync(id);

            if (typeExpenses != null)
            {
                _context.TypeExpenses.Remove(typeExpenses);
                await _context.SaveChangesAsync();
            }
        }
    }
}