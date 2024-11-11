using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Repositories;
using Microsoft.EntityFrameworkCore;
namespace AWEPP.Repositories
{
    public class TypeAccesUserRepository: ITypeAccesUserRepository
    {
        
            private readonly Aweppcontext _context;

            public TypeAccesUserRepository(Aweppcontext context)
            {
                _context = context;
            }

            // Método para crear un nuevo gasto
            public async Task CreateTypeAccesUserAsync(TypeAccesUser TypeAccessUsers)
            {
                await _context.TypeAccessUsers.AddAsync(TypeAccessUsers); // Añadir nuevo registro
                await _context.SaveChangesAsync(); // Guardar cambios
            }
            // Obtener todos los gastos que no están eliminados
            public async Task<IEnumerable<TypeAccesUser>> GetAllTypeAccesUserAsync()
            {
                return await _context.TypeAccessUsers
                    .Where(s => !s.IsDeleted) // Excluir los eliminados
                    .ToListAsync();
            }
            // Obtener gasto por su Id, excluyendo eliminados
            public async Task<TypeAccesUser> GetTypeAccesUserByIdAsync(int Id)
            {
                return await _context.TypeAccessUsers
                    .FirstOrDefaultAsync(s => s.Id == Id && !s.IsDeleted);
            }
            // Eliminar gasto de manera lógica (Soft Delete)
            public async Task SoftDeleteTypeAccesUserAsync(int Id)
            {
                var TypeAccesUser = await _context.TypeAccessUsers.FindAsync(Id);
                if (TypeAccesUser != null)
                {
                TypeAccesUser.IsDeleted = true; // Marcar como eliminado
                    await _context.SaveChangesAsync(); // Guardar cambios
                }
            }


            // Actualizar un gasto existente
            public async Task UpdateTypeAccesUserAsync(TypeAccesUser TypeAccessUsers)
            {
                var existingTypeAccesUser = await _context.TypeAccessUsers.FindAsync(TypeAccessUsers.Id);
                if (existingTypeAccesUser != null)
                {
                // Actualizar campos
                existingTypeAccesUser.TypeAccesUserss = TypeAccessUsers.TypeAccesUserss;
                existingTypeAccesUser.IsDeleted = TypeAccessUsers.IsDeleted;


                    // Guardar cambios
                    await _context.SaveChangesAsync();
                }
            }
        }
}





