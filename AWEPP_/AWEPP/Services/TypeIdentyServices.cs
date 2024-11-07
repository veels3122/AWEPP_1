using AWEPP.Model;
using AWEPP.Repositories;
using AWEPP.Services;

namespace AWEPP.Services
{
    public class TypeIdentyServices : ITypeIdentyServices
    {
        private readonly ITypeIdentyRepository _typeIdentyRepository;
        public TypeIdentyServices(ITypeIdentyRepository typeIdentyRepository)
        {
            _typeIdentyRepository = typeIdentyRepository;
        }

        public async Task CreateTypeIdentyAsync(TypeIdenty TypeIdentities)
        {
            await _typeIdentyRepository.CreateTypeIdentyAsync(TypeIdentities);
        }

        public async Task<IEnumerable<TypeIdenty>> GetAllTypeIdentyAsync()
        {
            return await _typeIdentyRepository.GetAllTypeIdentyAsync();
        }

        public async Task<TypeIdenty> GetTypeIdentyByIdAsync(int Id)
        {
            return await _typeIdentyRepository.GetTypeIdentyByIdAsync(Id);
        }

        public async Task SoftDeleteTypeIdentyAsync(int Id)
        {
            await _typeIdentyRepository.SoftDeleteTypeIdentyAsync(Id);
        }

        public async Task UpdateTypeIdentyAsync(TypeIdenty TypeIdentities)
        {
            await _typeIdentyRepository.UpdateTypeIdentyAsync(TypeIdentities);
        }
    }
}

