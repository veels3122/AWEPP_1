using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AWEPP.Repositories
{
    public class TypeExpensesRepository : ITypeExpensesRepository
    {
        private readonly Aweppcontext _context;

        public TypeExpensesRepository(Aweppcontext context)
        {
            _context = context;
        }
        public async Task CreateTypeExpensesAsync(TypeExpenses TypeExpenses)
        {
            await _context.TypeExpensess.AddAsync(TypeExpenses); // Añadir nuevo registro
            await _context.SaveChangesAsync(); // Guardar cambios
        }

        public async Task<IEnumerable<TypeExpenses>> GetAllTypeExpensesAsync()
        {
            return await _context.TypeExpensess
                .Where(s => !s.IsDeleted) // Excluir los eliminados
                .ToListAsync();
        }

        public async Task<TypeExpenses> GetTypeExpensesByIdAsync(int Id)
        {
            return await _context.TypeExpensess
                .FirstOrDefaultAsync(s => s.Id == Id && !s.IsDeleted);
        }

        public async Task SoftDeleteTypeExpensesAsync(int Id)
        {
            var TypeExpenses = await _context.TypeExpensess.FindAsync(Id);
            if (TypeExpenses != null)
            {
                TypeExpenses.IsDeleted = true; // Marcar como eliminado
                await _context.SaveChangesAsync(); // Guardar cambios
            }
        }

        public async Task UpdateTypeExpensesAsync(TypeExpenses TypeExpenses)
        {
            var existingBank = await _context.TypeExpensess.FindAsync(TypeExpenses.Id);
            if (existingBank != null)
            {
                // Actualizar campos
                existingBank.Expenses = TypeExpenses.Expenses;
                existingBank.IsDeleted = TypeExpenses.IsDeleted;


                // Guardar cambios
                await _context.SaveChangesAsync();
            }
        }
    }
}





  



