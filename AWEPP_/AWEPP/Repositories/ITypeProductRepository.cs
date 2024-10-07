using AWEPP.Context;
using AWEPP.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
    public interface ITypeProductsRepository
    {
        Task<IEnumerable<TypeProduct>> GetAllTypeProductsAsync();
        Task<TypeProduct> GetTypeProductsByIdAsync(int id);
        Task<TypeProduct> CreateTypeProductsAsync(TypeProduct typeProducts);
        Task<TypeProduct> UpdateTypeProductsAsync(TypeProduct typeProducts);
        Task SoftDeleteTypeProductsAsync(int id);
    }

    public class TypeProductsRepository : ITypeProductsRepository
    {
        private readonly Aweppcontext _context;

        public TypeProductsRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TypeProduct>> GetAllTypeProductsAsync()
        {
            return await _context.TypeProducts.ToListAsync();
        }

        public async Task<TypeProduct> GetTypeProductsByIdAsync(int id)
        {
#pragma warning disable CS8603 //posible null
            return await _context.TypeProducts.FindAsync(id);
#pragma warning disable CS8603 //posible null
        }

        public async Task<TypeProduct> CreateTypeProductsAsync(TypeProduct typeProducts)
        {
            _context.TypeProducts.Add(typeProducts);
            await _context.SaveChangesAsync();
            return typeProducts;
        }

        public async Task<TypeProduct> UpdateTypeProductsAsync(TypeProduct typeProducts)
        {
            _context.Entry(typeProducts).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return typeProducts;
        }

        public async Task SoftDeleteTypeProductsAsync(int id)
        {
            var typeProducts = await _context.TypeProducts.FindAsync(id);

            if (typeProducts != null)
            {
                _context.TypeProducts.Remove(typeProducts);
                await _context.SaveChangesAsync();
            }
        }
    }
}