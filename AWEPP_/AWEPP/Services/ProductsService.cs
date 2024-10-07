using AWEPP.Model;
using AWEPP.Repositories;

namespace AWEPP.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public async Task CreateProductsAsync(Product products)
        {
            await _productsRepository.CreateProductsAsync(products);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productsRepository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductsByIdAsync(int Id)
        {
            return await _productsRepository.GetProductsByIdAsync(Id);
        }

        public async Task SoftDeleteProductsAsync(int Id)
        {
            await _productsRepository.SoftDeleteProductsAsync(Id);
        }

        public async Task UpdateProductsAsync(Product products)
        {
           await _productsRepository.UpdateProductsAsync(products);
        }
    }
}
