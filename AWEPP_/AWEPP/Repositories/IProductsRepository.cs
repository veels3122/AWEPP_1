using AWEPP.Model;

namespace AWEPP.Repositories
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductsByIdAsync(int Id);
        Task CreateProductsAsync(Product products);
        Task UpdateProductsAsync(Product products);
        Task SoftDeleteProductsAsync(int Id);

    }
}
