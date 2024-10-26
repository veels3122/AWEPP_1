using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AWEPP.Repositories
{
    public class TypeAccesRepository : ITypeAccesRepository
    {

        private readonly Aweppcontext _context;

        public TypeAccesRepository(Aweppcontext context)
        {
            _context = context;
        }

        // Método para crear un nuevo gasto
        public async Task CreateTypeAccesAsync(TypeAcces TypeAccesses)
        {
            await _context.TypeAccesses.AddAsync(TypeAccesses); // Añadir nuevo registro
            await _context.SaveChangesAsync(); // Guardar cambios
        }

        public async Task<IEnumerable<TypeAcces>> GetAllTypeAccesAsync()
        {
            return await _context.TypeAccesses
                .Where(s => !s.IsDeleted) // Excluir los eliminados
                .ToListAsync();
        }

        
        // Obtener gasto por su Id, excluyendo eliminados
        public async Task<TypeAcces> GetTypeAccesByIdAsync(int Id)
        {
            return await _context.TypeAccesses
                .FirstOrDefaultAsync(s => s.Id == Id && !s.IsDeleted);
        }

        // Eliminar gasto de manera lógica (Soft Delete)
        public async Task SoftDeleteTypeAccesAsync(int Id)
        {
            var TypeAcces = await _context.TypeAccesses.FindAsync(Id);
            if (TypeAcces != null)
            {
                TypeAcces.IsDeleted = true; // Marcar como eliminado
                await _context.SaveChangesAsync(); // Guardar cambios
            }
        }

        // Actualizar un gasto existente
        public async Task UpdateTypeAccesAsync(TypeAcces TypeAccesses)
        {
            var existingTypeAcces = await _context.TypeAccesses.FindAsync(TypeAccesses.Id);
            if (existingTypeAcces != null)
            {
                // Actualizar campos
                existingTypeAcces.Typeacces = TypeAccesses.Typeacces;
                existingTypeAcces.IsDeleted = TypeAccesses.IsDeleted;


                // Guardar cambios
                await _context.SaveChangesAsync();
            }

        }

    }
}



        
