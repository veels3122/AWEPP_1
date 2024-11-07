using AWEPP.Context;
using AWEPP.Modelo;
using AWEPP.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AWEPP.Repositories
{
    public class SavingRepository : ISavingRepository
    {
        private readonly Aweppcontext _context;

        public SavingRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task CreateSavingAsync(Saving saving)
        {
            await _context.Savingss.AddAsync(saving); // Añadir nuevo registro
            await _context.SaveChangesAsync(); // Guardar cambios
        }

        public async Task<IEnumerable<Saving>> GetAllSavingAsync()
        {
            return await _context.Savingss
                .Where(s => !s.IsDeleted) // Excluir los eliminados
                .ToListAsync();
        }

        public async Task<Saving> GetSavingByIdAsync(int Id)
        {
            return await _context.Savingss
                .FirstOrDefaultAsync(s => s.Id == Id && !s.IsDeleted);
        }

        public async Task SoftDeleteSavingAsync(int Id)
        {
            var Saving = await _context.Savingss.FindAsync(Id);
            if (Saving != null)
            {
                Saving.IsDeleted = true; // Marcar como eliminado
                await _context.SaveChangesAsync(); // Guardar cambios
            }
        }

        public async Task UpdateSavingAsync(Saving saving)
        {
            var existingSaving = await _context.Savingss.FindAsync(saving.Id); // Usar Savings (plural)
            if (existingSaving != null)
            {
                // Actualizar los campos necesarios
                existingSaving.dateStar = saving.dateStar;
                existingSaving.dateEnd = saving.dateEnd;
                existingSaving.SavingAmount = saving.SavingAmount;
                existingSaving.paymentAmount = saving.paymentAmount;
                existingSaving.Description = saving.Description;
                existingSaving.TypeProducts = saving.TypeProducts;
                existingSaving.TypeAccounts = saving.TypeAccounts;
                existingSaving.Products = saving.Products;
                existingSaving.Bank = saving.Bank;
                existingSaving.Customer = saving.Customer;

                // Guardar cambios en la base de datos
                await _context.SaveChangesAsync();
            }
        }
    }
}
