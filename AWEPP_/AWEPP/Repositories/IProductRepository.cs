using AWEPP.Context;
using AWEPP.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task SoftDeleteProductAsync(int id);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly Aweppcontext _context;

        public ProductRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products
                .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
#pragma warning disable CS8603
            return await _context.Products
                .FirstOrDefaultAsync(c => c.Id == id);
#pragma warning disable CS8603  
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            var existingProduct = await _context.Products.FindAsync(product.Id);

            if (existingProduct == null)
            {
                throw new NotFoundException("Product not found");
            }

            // Actualiza las propiedades según sea necesario
            existingProduct.TypeAccountsId = product.TypeAccountsId;
            existingProduct.TypeProductsId = product.TypeProductsId;
            existingProduct.BankId = product.BankId;
            existingProduct.Account = product.Account;
            existingProduct.NumberAcount = product.NumberAcount;
            existingProduct.TotalBalance = product.TotalBalance;
            existingProduct.PartialBalance = product.PartialBalance;
            existingProduct.Debt = product.Debt;
            existingProduct.DatePayment = product.DatePayment;
            existingProduct.Description = product.Description;
            existingProduct.CustomerId = product.CustomerId;

            _context.Entry(existingProduct).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return existingProduct;
        }

        public async Task SoftDeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}