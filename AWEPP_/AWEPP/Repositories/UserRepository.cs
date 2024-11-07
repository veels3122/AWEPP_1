using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AWEPP.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly Aweppcontext _context;

        public UserRepository(Aweppcontext context)
        {
            _context = context;
        }

        // Método para crear un nuevo gasto
        public async Task CreateUserAsync(User Users)
        {
            await _context.Users.AddAsync(Users); // Añadir nuevo registro
            await _context.SaveChangesAsync(); // Guardar cambios
        }
        // Obtener todos los gastos que no están eliminados
        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await _context.Users
                .Where(s => !s.IsDeleted) // Excluir los eliminados
                .ToListAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .AsNoTracking()
                .Include(u => u.Usertype) // Incluir tipo de usuario si es necesario
                .FirstOrDefaultAsync(s => s.Email == email && !s.IsDeleted);
        }


        // Obtener gasto por su Id, excluyendo eliminados
        public async Task<User> GetUserByIdAsync(int Id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(s => s.Id == Id && !s.IsDeleted);
        }
        // Eliminar gasto de manera lógica (Soft Delete)
        public async Task SoftDeleteUserAsync(int Id)
        {
            var User = await _context.Users.FindAsync(Id);
            if (User != null)
            {
                User.IsDeleted = true; // Marcar como eliminado
                await _context.SaveChangesAsync(); // Guardar cambios
            }
        }


        // Actualizar un gasto existente
        public async Task UpdateUserAsync(User Users)
        {
            var existingUser = await _context.Users.FindAsync(Users.Id);
            if (existingUser != null)
            {
                // Actualizar campos
                existingUser.Name = Users.Name;
                existingUser.Email = Users.Email;
                existingUser.Password = Users.Password;
                existingUser.PhoneNumber = Users.PhoneNumber;
                existingUser.UserName = Users.UserName;
                existingUser.date = Users.date;
                existingUser.Modified = Users.Modified;
                existingUser.ModifiedBy = Users.ModifiedBy;
                existingUser.Usertype = Users.Usertype;
                existingUser.TypeAcces = Users.TypeAcces;
                existingUser.TypeAccesUser = Users.TypeAccesUser;
                existingUser.IsDeleted = Users.IsDeleted;


                // Guardar cambios
                await _context.SaveChangesAsync();
            }
           
        }
    }
}





