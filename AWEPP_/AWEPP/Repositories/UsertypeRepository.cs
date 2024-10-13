using AWEPP.Context;
using AWEPP.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
  
    public class UsertypeRepository : IUsertypeRepository
    {
        private readonly Aweppcontext _context;

        public UsertypeRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usertype>> GetAllUsertypesAsync()
        {
            return await _context.UserTypes
              .ToListAsync();
        }

        public async Task<Usertype> GetUsertypeByIdAsync(int id)
        {
#pragma warning disable CS8603
            return await _context.UserTypes
              .FirstOrDefaultAsync(ut => ut.Id == id);
#pragma warning disable CS8603
        }

        public async Task<Usertype> CreateUsertypeAsync(Usertype usertype)
        {
            _context.UserTypes.Add(usertype);
            await _context.SaveChangesAsync();
            return usertype;
        }

        public async Task<Usertype> UpdateUsertypeAsync(Usertype
     usertype)
        {
            _context.Entry(usertype).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return usertype;
        }

        public async Task SoftDeleteUsertypeAsync(int id)
        {
            var usertype = await _context.UserTypes.FindAsync(id);

            if (usertype != null)
            {
                _context.UserTypes.Remove(usertype);
                await _context.SaveChangesAsync();

            }
        }
    }
}