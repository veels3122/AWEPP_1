using AWEPP.Model;

namespace AWEPP.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductsByIdAsync(int Id);
        Task CreateProductsAsync(Product products);
        Task UpdateProductsAsync(Product products);
        Task SoftDeleteProductsAsync(int Id);
    }
}
