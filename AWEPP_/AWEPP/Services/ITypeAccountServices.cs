using AWEPP.Model;
using AWEPP.Repositories;
using System.Threading.Tasks;

namespace AWEPP.Services
{
    public interface ITypeAccountServices
    {
        Task<IEnumerable<TypeAccount>> GetAllTypeAccountsAsync();
        Task<TypeAccount> GetTypeAccountByIdAsync(int id);
        Task<TypeAccount> CreateTypeAccountAsync(TypeAccount typeAccount);
        Task<TypeAccount> UpdateTypeAccountAsync(TypeAccount typeAccount);
        Task SoftDeleteTypeAccountAsync(int id);
    }

    public class TypeAccountServices : ITypeAccountServices
    {
        private readonly ITypeAccountRepository _typeAccountRepository;

        public TypeAccountServices(ITypeAccountRepository typeAccountRepository)
        {
            _typeAccountRepository = typeAccountRepository;
        }

        public async Task<IEnumerable<TypeAccount>> GetAllTypeAccountsAsync()
        {
            return await _typeAccountRepository.GetAllTypeAccountsAsync();
        }

        public async Task<TypeAccount> GetTypeAccountByIdAsync(int id)
        {
            return await _typeAccountRepository.GetTypeAccountByIdAsync(id);
        }

        public async Task<TypeAccount> CreateTypeAccountAsync(TypeAccount typeAccount)
        {
            // Aquí puedes agregar validaciones adicionales si es necesario
            return await _typeAccountRepository.CreateTypeAccountAsync(typeAccount);
        }

        public async Task<TypeAccount> UpdateTypeAccountAsync(TypeAccount typeAccount)
        {
            // Aquí puedes agregar validaciones adicionales si es necesario
            return await _typeAccountRepository.UpdateTypeAccountAsync(typeAccount);
        }

        public async Task SoftDeleteTypeAccountAsync(int id)
        {
            await _typeAccountRepository.SoftDeleteTypeAccountAsync(id);
        }
    }
}