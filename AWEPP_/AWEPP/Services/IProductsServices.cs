using AWEPP.Model;
using AWEPP.Repositories;
using System.Threading.Tasks;

namespace AWEPP.Services
{
    public interface IProductsServices
    {
        Task<IEnumerable<Products>> GetAllProductsAsync();
        Task<Products> GetProductByIdAsync(int id);
        Task<Products> CreateProductAsync(Products products);
        Task<Products> UpdateProductAsync(Products products);
        Task SoftDeleteProductAsync(int id);
    }

}