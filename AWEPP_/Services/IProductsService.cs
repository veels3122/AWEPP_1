using AWEPP.Model;

namespace AWEPP.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Products>> GetAllProductsAsync();
        Task<Products> GetProductsByIdAsync(int Id);
        Task CreateProductsAsync(Products products);
        Task UpdateProductsAsync(Products products);
        Task SoftDeleteProductsAsync(int Id);
    }
}
