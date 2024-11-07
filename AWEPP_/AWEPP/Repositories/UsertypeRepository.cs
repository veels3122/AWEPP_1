using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AWEPP.Repositories
{
    public class UserTypeRepository : IUserTypeRepository
    {


        private readonly Aweppcontext _context;

        public UserTypeRepository(Aweppcontext context)
        {
            _context = context;
        }

        // Método para crear un nuevo gasto
        public async Task CreateUsertypeAsync(Usertype UserTypes)
        {
            await _context.UserTypes.AddAsync(UserTypes); // Añadir nuevo registro
            await _context.SaveChangesAsync(); // Guardar cambios
        }

        // Obtener todos los gastos que no están eliminados
        public async Task<IEnumerable<Usertype>> GetAllUsertypeAsync()
        {
            return await _context.UserTypes
                .Where(s => !s.IsDeleted) // Excluir los eliminados
                .ToListAsync();
        }
        // Obtener gasto por su Id, excluyendo eliminados
        public async Task<Usertype> GetUsertypeByIdAsync(int Id)
        {
            return await _context.UserTypes
                .FirstOrDefaultAsync(s => s.Id == Id && !s.IsDeleted);
        }
        // Eliminar gasto de manera lógica (Soft Delete)
        public async Task SoftDeleteUsertypeAsync(int Id)
        {
            var Usertype = await _context.UserTypes.FindAsync(Id);
            if (Usertype != null)
            {
                Usertype.IsDeleted = true; // Marcar como eliminado
                await _context.SaveChangesAsync(); // Guardar cambios
            }
        }


        // Actualizar un gasto existente
        public async Task UpdateUsertypeAsync(Usertype UserTypes)
        {
            var existingUsertype = await _context.UserTypes.FindAsync(UserTypes.Id);
            if (existingUsertype != null)
            {
                // Actualizar campos
                existingUsertype.Name = UserTypes.Name;
                existingUsertype.IsDeleted = UserTypes.IsDeleted;


                // Guardar cambios
                await _context.SaveChangesAsync();
            }
        }
    }
}





