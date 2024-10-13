using AWEPP.Context;
using AWEPP.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
    
    public class TypeIdentyRepository : ITypeIdentyRepository
    {
        private readonly Aweppcontext _context;

        public TypeIdentyRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TypeIdenty>> GetAllTypeIdentyAsync()
        {
            return await _context.TipoIdenty.ToListAsync();
        }

        public async Task<TypeIdenty> GetTypeIdentyByIdAsync(int id)
        {
#pragma warning disable CS8603 //posible null
            return await _context.TipoIdenty.FindAsync(id);
#pragma warning disable CS8603 //posible null
        }

        public async Task<TypeIdenty> CreateTypeIdentyAsync(TypeIdenty typeIdenty)
        {
            _context.TipoIdenty.Add(typeIdenty);
            await _context.SaveChangesAsync();
            return typeIdenty;
        }

        public async Task<TypeIdenty> UpdateTypeIdentyAsync(TypeIdenty typeIdenty)
        {
            _context.Entry(typeIdenty).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return typeIdenty;
        }

        public async Task SoftDeleteTypeIdentyAsync(int id)
        {
            var typeIdenty = await _context.TipoIdenty.FindAsync(id);

            if (typeIdenty != null)
            {
                _context.TipoIdenty.Remove(typeIdenty);
                await _context.SaveChangesAsync();
            }
        }
    }
}