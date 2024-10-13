using AWEPP.Context;
using AWEPP.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Products>> GetAllProductsAsync();
        Task<Products> GetProductByIdAsync(int id);
        Task<Products> CreateProductAsync(Products products);
        Task<Products> UpdateProductAsync(Products products);
        Task SoftDeleteProductAsync(int id);
    }

}