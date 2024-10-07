using AWEPP.Model;

namespace AWEPP.Repositories
{
    public interface ITypeProductRepository

    {
        Task<IEnumerable<Product>> GetAllProductAsync();
        Task<Product> GetProductByIdAsync(int Id);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task SoftDeleteProductAsync(int Id);
    }

}
