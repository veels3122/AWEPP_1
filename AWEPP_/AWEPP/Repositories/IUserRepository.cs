using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task SoftDeleteUserAsync(int id);
    }

    public class UserRepository : IUserRepository
    {
        private readonly Aweppcontext _context;

        public UserRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users
                .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
#pragma warning disable CS8603
            return await _context.Users
                .FirstOrDefaultAsync(c => c.Id == id);
#pragma warning disable CS8603
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);

            if (existingUser == null)
            {
                throw new NotFoundException("User not found");
            }

            // Actualiza las propiedades según sea necesario
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Passaword = user.Passaword;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.UserName = user.UserName;
            existingUser.date = user.date;
            existingUser.Modified = user.Modified;
            existingUser.ModifiedBy = user.ModifiedBy;
            existingUser.UsertypeId = user.UsertypeId;
            existingUser.TypeAccesId = user.TypeAccesId;
            existingUser.TypeAccesUserId = user.TypeAccesUserId;

            _context.Entry(existingUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return existingUser;
        }

        public async Task SoftDeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}