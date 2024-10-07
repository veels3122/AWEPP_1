using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AWEPP.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task CreateProductsAsync(Product products)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductsByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteProductsAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductsAsync(Product products)
        {
            throw new NotImplementedException();
        }
    }
}
        
    
