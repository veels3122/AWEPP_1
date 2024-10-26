using AWEPP.Model;
using AWEPP.Repositories;

namespace AWEPP.Services
{
    public class TypeProductsServices : ITypeProductsServices
    {
        private readonly ITypeProductsRepository _typeProductsRepository;
        public TypeProductsServices(ITypeProductsRepository typeProductsRepository)
        {
            _typeProductsRepository = typeProductsRepository;
        }

        public async Task CreateTypeProductsAsync(TypeProducts TypeProducts)
        {
            await _typeProductsRepository.CreateTypeProductsAsync(TypeProducts);
        }

        public async Task<IEnumerable<TypeProducts>> GetAllTypeProductsAsync()
        {
            return await _typeProductsRepository.GetAllTypeProductsAsync();
        }

        public async Task<TypeProducts> GetTypeProductsByIdAsync(int Id)
        {
            return await _typeProductsRepository.GetTypeProductsByIdAsync(Id);
        }

        public async Task SoftDeleteTypeProductsAsync(int Id)
        {
            await _typeProductsRepository.SoftDeleteTypeProductsAsync(Id);
        }

        public async Task UpdateTypeProductsAsync(TypeProducts TypeProducts)
        {
            await _typeProductsRepository.UpdateTypeProductsAsync(TypeProducts);
        }
    }
}

