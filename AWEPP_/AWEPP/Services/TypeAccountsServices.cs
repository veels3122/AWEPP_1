using AWEPP.Model;
using AWEPP.Repositories;
using System.Threading.Tasks;

namespace AWEPP.Services
{
  
    public class TypeAccountServices : ITypeAccountsServices
    {
        private readonly ITypeAccountsRepository _typeAccountRepository;

        public TypeAccountServices(ITypeAccountsRepository typeAccountRepository)
        {
            _typeAccountRepository = typeAccountRepository;
        }

        public async Task<IEnumerable<TypeAccounts>> GetAllTypeAccountsAsync()
        {
            return await _typeAccountRepository.GetAllTypeAccountsAsync();
        }

        public async Task<TypeAccounts> GetTypeAccountByIdAsync(int id)
        {
            return await _typeAccountRepository.GetTypeAccountByIdAsync(id);
        }

        public async Task<TypeAccounts> CreateTypeAccountAsync(TypeAccounts typeAccount)
        {
            // Aquí puedes agregar validaciones adicionales si es necesario
            return await _typeAccountRepository.CreateTypeAccountAsync(typeAccount);
        }

        public async Task<TypeAccounts> UpdateTypeAccountAsync(TypeAccounts typeAccount)
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