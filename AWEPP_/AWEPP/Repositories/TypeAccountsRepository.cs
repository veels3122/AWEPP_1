using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AWEPP.Repositories
{
    public class TypeAccountsRepository : ITypeAccountsRepository
    {
        private readonly Aweppcontext _context;

        public TypeAccountsRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task CreateTypeAccountsAsync(TypeAccounts typeAccounts)
        {
            await _context.TypeAccounts.AddAsync(typeAccounts); // Añadir nuevo registro
            await _context.SaveChangesAsync(); // Guardar cambios
        }

        public async Task<IEnumerable<TypeAccounts>> GetAllTypeAccountsAsync()
        {
            return await _context.TypeAccounts
                .Where(s => !s.IsDeleted) // Excluir los eliminados
                .ToListAsync();
        }

        public async Task<TypeAccounts> GetTypeAccountsByIdAsync(int Id)
        {
            
           return await _context.TypeAccounts
           .FirstOrDefaultAsync(s => s.Id == Id && !s.IsDeleted);
            
        }

        public async Task SoftDeleteTypeAccountsAsync(int Id)
        {
            var typeAccounts = await _context.TypeAccounts.FindAsync(Id);
            if (typeAccounts != null)
            {
                typeAccounts.IsDeleted = true; // Marcar como eliminado
                await _context.SaveChangesAsync(); // Guardar cambios
            }
        }


        public async Task UpdateTypeAccountsAsync(TypeAccounts typeAccounts)
        {
            var existingTypeAccounts = await _context.TypeAccounts.FindAsync(typeAccounts.Id);
            if (existingTypeAccounts == null)
            {
                throw new Exception("El TypeAccount no fue encontrado.");
            }
            // Verificar si el registro fue encontrado
            if (existingTypeAccounts != null)
            {
                // Actualizar los campos necesarios
                existingTypeAccounts.Accounts = typeAccounts.Accounts;
                existingTypeAccounts.IsDeleted = typeAccounts.IsDeleted;

                // Guardar cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            


        }
    }
}






























