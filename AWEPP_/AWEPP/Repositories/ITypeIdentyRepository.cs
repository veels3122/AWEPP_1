using AWEPP.Context;
using AWEPP.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
    public interface ITypeIdentyRepository
    {
        Task<IEnumerable<TypeIdenty>> GetAllTypeIdentyAsync();
        Task<TypeIdenty> GetTypeIdentyByIdAsync(int id);
        Task<TypeIdenty> CreateTypeIdentyAsync(TypeIdenty typeIdenty);
        Task<TypeIdenty> UpdateTypeIdentyAsync(TypeIdenty typeIdenty);
        Task SoftDeleteTypeIdentyAsync(int id);
    }

    public class TypeIdentyRepository : ITypeIdentyRepository
    {
        private readonly Aweppcontext _context;

        public TypeIdentyRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TypeIdenty>> GetAllTypeIdentyAsync()
        {
            return await _context.TypeIdentys.ToListAsync();
        }

        public async Task<TypeIdenty> GetTypeIdentyByIdAsync(int id)
        {
#pragma warning disable CS8603 //posible null
            return await _context.TypeIdentys.FindAsync(id);
#pragma warning disable CS8603 //posible null
        }

        public async Task<TypeIdenty> CreateTypeIdentyAsync(TypeIdenty typeIdenty)
        {
            _context.TypeIdentys.Add(typeIdenty);
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
            var typeIdenty = await _context.TypeIdentys.FindAsync(id);

            if (typeIdenty != null)
            {
                _context.TypeIdentys.Remove(typeIdenty);
                await _context.SaveChangesAsync();
            }
        }
    }
}