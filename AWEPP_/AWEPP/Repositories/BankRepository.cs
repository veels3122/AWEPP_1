using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AWEPP.Repositories
{
    public class BankRepository : IBankRepository
    {
        private readonly Aweppcontext _context;

        public BankRepository(Aweppcontext context)
        {
            _context = context;
        }

        // Método para crear un nuevo gasto
        public async Task CreateBankAsync(Bank Banks)
        {
            
            await _context.Banks.AddAsync(Banks); // Añadir nuevo registro
            Banks.IsDeleted = false; // Asegurar que el campo delete sea false
            await _context.SaveChangesAsync(); // Guardar cambios
        }
        // Obtener todos los gastos que no están eliminados
        public async Task<IEnumerable<Bank>> GetAllBankAsync()
        {
            return await _context.Banks
                .Where(s => !s.IsDeleted) // Excluir los eliminados
                .ToListAsync();
        }
        // Obtener gasto por su Id, excluyendo eliminados
        public async Task<Bank> GetBankByIdAsync(int Id)
        {
            return await _context.Banks
                .FirstOrDefaultAsync(s => s.Id == Id && !s.IsDeleted);
        }
        // Eliminar gasto de manera lógica (Soft Delete)
        public async Task SoftDeleteBankAsync(int Id)
        {
            var Banks = await _context.Banks.FindAsync(Id);
            if (Banks != null)
            {
                Banks.IsDeleted = true; // Marcar como eliminado
                await _context.SaveChangesAsync(); // Guardar cambios
            }
        }

       
        // Actualizar un gasto existente
        public async Task UpdateBankAsync(Bank Banks)
        {
            var existingBank = await _context.Banks.FindAsync(Banks.Id);
            if (existingBank != null)
            {
                // Actualizar campos
                existingBank.Banks = Banks.Banks;
                existingBank.IsDeleted = Banks.IsDeleted;


                // Guardar cambios
                await _context.SaveChangesAsync();
            }
        }

    }
}




