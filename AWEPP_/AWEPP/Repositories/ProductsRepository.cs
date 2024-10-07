using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AWEPP.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        public Task CreateProductsAsync(Products products)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Products>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Products> GetProductsByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteProductsAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductsAsync(Products products)
        {
            throw new NotImplementedException();
        }
    }
}
        
    
