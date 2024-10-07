using AWEPP.Model;
using AWEPP.Repositories;
using System.Threading.Tasks;

namespace AWEPP.Services
{
    public interface ITypeProductsServices
    {
        Task<IEnumerable<TypeProduct>> GetAllTypeProductsAsync();
        Task<TypeProduct> GetTypeProductsByIdAsync(int id);
        Task<TypeProduct> CreateTypeProductsAsync(TypeProduct typeProducts);
        Task<TypeProduct> UpdateTypeProductsAsync(TypeProduct typeProducts);
        Task SoftDeleteTypeProductsAsync(int id);
    }

    public class TypeProductsServices : ITypeProductsServices
    {
        private readonly ITypeProductsRepository _typeProductsRepository;

        public TypeProductsServices(ITypeProductsRepository typeProductsRepository)
        {
            _typeProductsRepository = typeProductsRepository;
        }

        public async Task<IEnumerable<TypeProduct>> GetAllTypeProductsAsync()
        {
            return await _typeProductsRepository.GetAllTypeProductsAsync();
        }

        public async Task<TypeProduct> GetTypeProductsByIdAsync(int id)
        {
            return await _typeProductsRepository.GetTypeProductsByIdAsync(id);
        }

        public async Task<TypeProduct> CreateTypeProductsAsync(TypeProduct typeProducts)
        {
            if (string.IsNullOrEmpty(typeProducts.Description))
            {
                throw new ArgumentException("La descripción del tipo de producto es obligatoria.");
            }

            return await _typeProductsRepository.CreateTypeProductsAsync(typeProducts);
        }

        public async Task<TypeProduct> UpdateTypeProductsAsync(TypeProduct typeProducts)
        {
            return await _typeProductsRepository.UpdateTypeProductsAsync(typeProducts);
        }

        public async Task SoftDeleteTypeProductsAsync(int id)
        {
            await _typeProductsRepository.SoftDeleteTypeProductsAsync(id);
        }
    }
}