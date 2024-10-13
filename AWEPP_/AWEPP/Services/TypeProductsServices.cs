using AWEPP.Model;
using AWEPP.Repositories;
using System.Threading.Tasks;

namespace AWEPP.Services
{
   
    public class TypeProductsServices : ITypeProductsServices
    {
        private readonly ITypeProductsRepository _typeProductsRepository;

        public TypeProductsServices(ITypeProductsRepository typeProductsRepository)
        {
            _typeProductsRepository = typeProductsRepository;
        }

        public async Task<IEnumerable<TypeProducts>> GetAllTypeProductsAsync()
        {
            return await _typeProductsRepository.GetAllTypeProductsAsync();
        }

        public async Task<TypeProducts> GetTypeProductsByIdAsync(int id)
        {
            return await _typeProductsRepository.GetTypeProductsByIdAsync(id);
        }

        public async Task<TypeProducts> CreateTypeProductsAsync(TypeProducts typeProducts)
        {
            if (string.IsNullOrEmpty(typeProducts.Description))
            {
                throw new ArgumentException("La descripción del tipo de producto es obligatoria.");
            }

            return await _typeProductsRepository.CreateTypeProductsAsync(typeProducts);
        }

        public async Task<TypeProducts> UpdateTypeProductsAsync(TypeProducts typeProducts)
        {
            return await _typeProductsRepository.UpdateTypeProductsAsync(typeProducts);
        }

        public async Task SoftDeleteTypeProductsAsync(int id)
        {
            await _typeProductsRepository.SoftDeleteTypeProductsAsync(id);
        }
    }
}