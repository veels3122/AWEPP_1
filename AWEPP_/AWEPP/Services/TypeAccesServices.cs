using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Repositories;
using AWEPP.Services;

namespace AWEPP.Services
{
    public class TypeAccesServices : ITypeAccesServices
    {
        private readonly ITypeAccesRepository _typeAccesRepository;

        public TypeAccesServices(ITypeAccesRepository typeAccesRepository)
        {
            _typeAccesRepository = typeAccesRepository;
        }

        public async Task CreateTypeAccesAsync(TypeAcces TypeAccesses)
        {
            await _typeAccesRepository.CreateTypeAccesAsync(TypeAccesses);
        }

        public async Task<IEnumerable<TypeAcces>> GetAllTypeAccesAsync()
        {
            return await _typeAccesRepository.GetAllTypeAccesAsync();
        }

        public async Task<TypeAcces> GetTypeAccesByIdAsync(int Id)
        {
            return await _typeAccesRepository.GetTypeAccesByIdAsync(Id);
        }

        public async Task SoftDeleteTypeAccesAsync(int Id)
        {
            await _typeAccesRepository.SoftDeleteTypeAccesAsync(Id);
        }

        public async Task UpdateTypeAccesAsync(TypeAcces TypeAccesses)
        {
            await _typeAccesRepository.UpdateTypeAccesAsync(TypeAccesses);
        }
    }
}

