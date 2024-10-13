using AWEPP.Context;
using AWEPP.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
   
    public class TypeAccesUserRepository : ITypeAccesUserRepository
    {
        private readonly Aweppcontext _context;

        public TypeAccesUserRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TypeAccesUser>> GetAllTypeAccesUsersAsync()
        {
            return await _context.TypeAccessUsers
              .ToListAsync();
        }

        public async Task<TypeAccesUser> GetTypeAccesUserByIdAsync(int id)
        {
#pragma warning disable CS8603
            return await _context.TypeAccessUsers
              .FirstOrDefaultAsync(tau => tau.Id == id);
#pragma warning disable CS8603
        }

        public async Task<TypeAccesUser> CreateTypeAccesUserAsync(TypeAccesUser typeAccesUser)
        {
            _context.TypeAccessUsers.Add(typeAccesUser);
            await _context.SaveChangesAsync();
            return typeAccesUser;
        }

        public async Task<TypeAccesUser> UpdateTypeAccesUserAsync(TypeAccesUser typeAccesUser)
        {
            _context.Entry(typeAccesUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return typeAccesUser;
        }

        public async Task SoftDeleteTypeAccesUserAsync(int id)
        {
            var typeAccesUser = await _context.TypeAccessUsers.FindAsync(id);

            if (typeAccesUser != null)
            {
                _context.TypeAccessUsers.Remove(typeAccesUser);
                await _context.SaveChangesAsync();
            }
        }
    }
}