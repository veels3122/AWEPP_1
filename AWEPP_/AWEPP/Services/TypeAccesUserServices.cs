using AWEPP.Model;
using AWEPP.Repositories;
using AWEPP.Services;

namespace AWEPP.Services
{
    public class TypeAccesUserServices : ITypeAccesUserServices
    {
        private readonly ITypeAccesUserRepository _typeAccesUserRepository;

        public TypeAccesUserServices(ITypeAccesUserRepository typeAccesUserRepository)
        {
            _typeAccesUserRepository = typeAccesUserRepository;
        }

        public async Task CreateTypeAccesUserAsync(TypeAccesUser TypeAccessUsers)
        {
            await _typeAccesUserRepository.CreateTypeAccesUserAsync(TypeAccessUsers);
        }

        public async Task<IEnumerable<TypeAccesUser>> GetAllTypeAccesUserAsync()
        {
            return await _typeAccesUserRepository.GetAllTypeAccesUserAsync();
        }

        public async Task<TypeAccesUser> GetTypeAccesUserByIdAsync(int Id)
        {
            return await _typeAccesUserRepository.GetTypeAccesUserByIdAsync(Id);
        }

        public async Task SoftDeleteTypeAccesUserAsync(int Id)
        {
            await _typeAccesUserRepository.SoftDeleteTypeAccesUserAsync(Id);
        }

        public async Task UpdateTypeAccesUserAsync(TypeAccesUser TypeAccessUsers)
        {
            await _typeAccesUserRepository.UpdateTypeAccesUserAsync(TypeAccessUsers);
        }
    }
}
