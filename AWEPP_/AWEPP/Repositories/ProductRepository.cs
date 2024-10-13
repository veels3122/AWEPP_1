using AWEPP.Context;
using AWEPP.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
    
    public class ProductRepository : IProductRepository
    {
        private readonly Aweppcontext _context;

        public ProductRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Products>> GetAllProductsAsync()
        {
            return await _context.Products
                .ToListAsync();
        }

        public async Task<Products> GetProductByIdAsync(int id)
        {
#pragma warning disable CS8603
            return await _context.Products
                .FirstOrDefaultAsync(c => c.Id == id);
#pragma warning disable CS8603  
        }

        public async Task<Products> CreateProductAsync(Products products)
        {

            _context.Products.Add(products);
            await _context.SaveChangesAsync();
            return products;
        }

        public async Task<Products> UpdateProductAsync(Products products)
        {
            var existingProducts = await _context.Products.FindAsync(products.Id);

            if (existingProducts == null)
            {
                throw new NotFoundException("Product not found");
            }

            // Actualiza las propiedades según sea necesario

            existingProducts.Account = products.Account;
            existingProducts.NumberAcount = products.NumberAcount;
            existingProducts.TotalBalance = products.TotalBalance;
            existingProducts.PartialBalance = products.PartialBalance;
            existingProducts.Debt = products.Debt;
            existingProducts.DatePayment = products.DatePayment;
            existingProducts.Description = products.Description;

            _context.Entry(existingProducts).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return existingProducts;
        }

        public async Task SoftDeleteProductAsync(int id)
        {
            var products = await _context.Products.FindAsync(id);
            if (products != null)
            {
                _context.Products.Remove(products);
                await _context.SaveChangesAsync();
            }
        }
    }
}