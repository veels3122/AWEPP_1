using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Repositories;
using Microsoft.EntityFrameworkCore;
namespace AWEPP.Repositories
{
    public class TypeIdentyRepository : ITypeIdentyRepository
    {
        private readonly Aweppcontext _context;

        public TypeIdentyRepository(Aweppcontext context)
        {
            _context = context;
        }


        // Método para crear un nuevo gasto
        public async Task CreateTypeIdentyAsync(TypeIdenty TypeIdentities)
        {
            await _context.TypeIdentities.AddAsync(TypeIdentities); // Añadir nuevo registro
            await _context.SaveChangesAsync(); // Guardar cambios
        }
        // Obtener todos los gastos que no están eliminados
        public async Task<IEnumerable<TypeIdenty>> GetAllTypeIdentyAsync()
        {
            return await _context.TypeIdentities
                .Where(s => !s.IsDeleted) // Excluir los eliminados
                .ToListAsync();
        }
        // Obtener gasto por su Id, excluyendo eliminados
        public async Task<TypeIdenty> GetTypeIdentyByIdAsync(int Id)
        {
            return await _context.TypeIdentities
                .FirstOrDefaultAsync(s => s.Id == Id && !s.IsDeleted);
        }
        // Eliminar gasto de manera lógica (Soft Delete)
        public async Task SoftDeleteTypeIdentyAsync(int Id)
        {
            var TypeIdenty = await _context.TypeIdentities.FindAsync(Id);
            if (TypeIdenty != null)
            {
                TypeIdenty.IsDeleted = true; // Marcar como eliminado
                await _context.SaveChangesAsync(); // Guardar cambios
            }
        }


        // Actualizar un gasto existente
        public async Task UpdateTypeIdentyAsync(TypeIdenty TypeIdentities)
        {
            var existingTypeIdenty = await _context.TypeIdentities.FindAsync(TypeIdentities.Id);
            if (existingTypeIdenty != null)
            {
                // Actualizar campos
                existingTypeIdenty.TipoIdenty = TypeIdentities.TipoIdenty;
                existingTypeIdenty.IsDeleted = TypeIdentities.IsDeleted;


                // Guardar cambios
                await _context.SaveChangesAsync();
            }
        }
    }
}




        
