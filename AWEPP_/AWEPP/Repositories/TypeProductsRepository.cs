using AWEPP.Context;
using AWEPP.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{

    public class TypeProductsRepository : ITypeProductsRepository
    {
        private readonly Aweppcontext _context;

        public TypeProductsRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TypeProducts>> GetAllTypeProductsAsync()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<TypeProducts> GetTypeProductsByIdAsync(int id)
        {
#pragma warning disable CS8603 //posible null
            return await _context.Product.FindAsync(id);
#pragma warning disable CS8603 //posible null
        }

        public async Task<TypeProducts> CreateTypeProductsAsync(TypeProducts typeProducts)
        {
            _context.Product.Add(typeProducts);
            await _context.SaveChangesAsync();
            return typeProducts;
        }

        public async Task<TypeProducts> UpdateTypeProductsAsync(TypeProducts typeProducts)
        {
            _context.Entry(typeProducts).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return typeProducts;
        }

        public async Task SoftDeleteTypeProductsAsync(int id)
        {
            var typeProducts = await _context.Product.FindAsync(id);

            if (typeProducts != null)
            {
                _context.Product.Remove(typeProducts);
                await _context.SaveChangesAsync();
            }
        }
    }
}