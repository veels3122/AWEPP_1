using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AWEPP.Repositories
{
    public class TypeProductsRepository :ITypeProductsRepository
    {
        private readonly Aweppcontext _context;

        public TypeProductsRepository(Aweppcontext context)
        {
            _context = context;
        }

        // Método para crear un nuevo gasto
        public async Task CreateTypeProductsAsync(TypeProducts TypeProducts)
        {
            await _context.TypeProductss.AddAsync(TypeProducts); // Añadir nuevo registro
            await _context.SaveChangesAsync(); // Guardar cambios
        }
        // Obtener todos los gastos que no están eliminados
        public async Task<IEnumerable<TypeProducts>> GetAllTypeProductsAsync()
        {
            return await _context.TypeProductss
                .Where(s => !s.IsDeleted) // Excluir los eliminados
                .ToListAsync();
        }
        // Obtener gasto por su Id, excluyendo eliminados
        public async Task<TypeProducts> GetTypeProductsByIdAsync(int Id)
        {
            return await _context.TypeProductss
                .FirstOrDefaultAsync(s => s.Id == Id && !s.IsDeleted);
        }
        // Eliminar gasto de manera lógica (Soft Delete)
        public async Task SoftDeleteTypeProductsAsync(int Id)
        {
            var TypeProducts = await _context.TypeProductss.FindAsync(Id);
            if (TypeProducts != null)
            {
                TypeProducts.IsDeleted = true; // Marcar como eliminado
                await _context.SaveChangesAsync(); // Guardar cambios
            }
        }


        // Actualizar un gasto existente
        public async Task UpdateTypeProductsAsync(TypeProducts TypeProducts)
        {
            var existingTypeProducts = await _context.TypeProductss.FindAsync(TypeProducts.Id);
            if (existingTypeProducts != null)
            {
                // Actualizar campos
                existingTypeProducts.Producd = TypeProducts.Producd;
                existingTypeProducts.Description = TypeProducts.Description;
                existingTypeProducts.IsDeleted = TypeProducts.IsDeleted;


                // Guardar cambios
                await _context.SaveChangesAsync();
            }
        }
    }
}

