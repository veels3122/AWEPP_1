using AWEPP.Model;
using AWEPP.Repositories;
using System.Threading.Tasks;

namespace AWEPP.Services
{
   
    public class ProductServices : IProductsServices
    {
        private readonly IProductRepository _productsRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productsRepository = productRepository;
        }

        public async Task<IEnumerable<Products>> GetAllProductsAsync()
        {
            return await _productsRepository.GetAllProductsAsync();
        }

        public async Task<Products> GetProductByIdAsync(int id)
        {
            return await _productsRepository.GetProductByIdAsync(id);
        }

        public async Task<Products> CreateProductAsync(Products products)
        {
            // Aquí puedes agregar validaciones adicionales si es necesario
            return await _productsRepository.CreateProductAsync(products);
        }

        public async Task<Products> UpdateProductAsync(Products products)
        {
            // Aquí puedes agregar validaciones adicionales si es necesario
            return await _productsRepository.UpdateProductAsync(products);
        }

        public async Task SoftDeleteProductAsync(int id)
        {
            await _productsRepository.SoftDeleteProductAsync(id);
        }
    }
}