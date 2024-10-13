using AWEPP.Context;
using AWEPP.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
   

    public class TypeAccesRepository : ITypeAccesRepository
    {
        private readonly Aweppcontext _context;

        public TypeAccesRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TypeAcces>> GetAllTypeAccesAsync()
        {
            return await _context.TypeAccesses.ToListAsync();
        }

        public async Task<TypeAcces> GetTypeAccesByIdAsync(int id)
        {
#pragma warning disable CS8603 //posible null
            return await _context.TypeAccesses.FindAsync(id);
        }
#pragma warning disable CS8603 //posible null
        public async Task<TypeAcces> CreateTypeAccesAsync(TypeAcces typeAcces)
        {
            _context.TypeAccesses.Add(typeAcces);
            await _context.SaveChangesAsync();
            return typeAcces;
        }

        public async Task<TypeAcces> UpdateTypeAccesAsync(TypeAcces typeAcces)
        {
            _context.Entry(typeAcces).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return typeAcces;
        }

        public async Task SoftDeleteTypeAccesAsync(int id)
        {
            var typeAcces = await _context.TypeAccesses.FindAsync(id);

            if (typeAcces != null)
            {
                _context.TypeAccesses.Remove(typeAcces);
                await _context.SaveChangesAsync();
            }
        }
    }
}