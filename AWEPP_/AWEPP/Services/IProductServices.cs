using AWEPP.Model;
using AWEPP.Repositories;
using System.Threading.Tasks;

namespace AWEPP.Services
{
    public interface IProductServices
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task SoftDeleteProductAsync(int id);
    }

    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            // Aquí puedes agregar validaciones adicionales si es necesario
            return await _productRepository.CreateProductAsync(product);
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            // Aquí puedes agregar validaciones adicionales si es necesario
            return await _productRepository.UpdateProductAsync(product);
        }

        public async Task SoftDeleteProductAsync(int id)
        {
            await _productRepository.SoftDeleteProductAsync(id);
        }
    }
}