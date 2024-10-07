using AWEPP.Model;
using AWEPP.Repositories;
using System.Threading.Tasks;

namespace AWEPP.Services
{
    public interface ITypeAccesUserServices
    {
        Task<IEnumerable<TypeAccesUser>> GetAllTypeAccesUsersAsync();
        Task<TypeAccesUser> GetTypeAccesUserByIdAsync(int id);
        Task<TypeAccesUser> CreateTypeAccesUserAsync(TypeAccesUser typeAccesUser);
        Task<TypeAccesUser> UpdateTypeAccesUserAsync(TypeAccesUser typeAccesUser);
        Task SoftDeleteTypeAccesUserAsync(int id);
    }

    public class TypeAccesUserServices : ITypeAccesUserServices
    {
        private readonly ITypeAccesUserRepository _typeAccesUserRepository;

        public TypeAccesUserServices(ITypeAccesUserRepository typeAccesUserRepository)
        {
            _typeAccesUserRepository = typeAccesUserRepository;
        }

        public async Task<IEnumerable<TypeAccesUser>> GetAllTypeAccesUsersAsync()
        {
            return await _typeAccesUserRepository.GetAllTypeAccesUsersAsync();
        }

        public async Task<TypeAccesUser> GetTypeAccesUserByIdAsync(int id)
        {
            return await _typeAccesUserRepository.GetTypeAccesUserByIdAsync(id);
        }

        public async Task<TypeAccesUser> CreateTypeAccesUserAsync(TypeAccesUser typeAccesUser)
        {
            // Aquí puedes agregar validaciones adicionales si es necesario
            return await _typeAccesUserRepository.CreateTypeAccesUserAsync(typeAccesUser);
        }

        public async Task<TypeAccesUser> UpdateTypeAccesUserAsync(TypeAccesUser typeAccesUser)
        {
            // Aquí puedes agregar validaciones adicionales si es necesario
            return await _typeAccesUserRepository.UpdateTypeAccesUserAsync(typeAccesUser);
        }

        public async Task SoftDeleteTypeAccesUserAsync(int id)
        {
            await _typeAccesUserRepository.SoftDeleteTypeAccesUserAsync(id);
        }
    }
}