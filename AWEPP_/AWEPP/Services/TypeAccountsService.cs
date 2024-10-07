using AWEPP.Model;
using AWEPP.Repositories;

namespace AWEPP.Services
{
    public class TypeAccountsService : ITypeAccountsService
    {
        private readonly ITypeAccountsRepository _typeAccountsRepository;

        public TypeAccountsService(ITypeAccountsRepository typeAccountsRepository)
        {
            _typeAccountsRepository = typeAccountsRepository;
        }
        public async Task CreateTypeAccountsAsync(TypeAccount typeAccounts)
        {
            await _typeAccountsRepository.UpdateTypeAccountsAsync(typeAccounts);
        }

        public async Task<IEnumerable<TypeAccount>> GetAllTypeAccountsAsync()
        {
            return await _typeAccountsRepository.GetAllTypeAccountsAsync();
        }

        public async Task<TypeAccount> GetTypeAccountsByIdAsync(int Id)
        {
            return await _typeAccountsRepository.GetTypeAccountsByIdAsync(Id);
        }

        public async Task SoftDeleteTypeAccountsAsync(int Id)
        {
           await _typeAccountsRepository.SoftDeleteTypeAccountsAsync(Id);
        }

        public async Task UpdateTypeAccountsAsync(TypeAccount typeAccounts)
        {
            await _typeAccountsRepository.UpdateTypeAccountsAsync(typeAccounts);
        }
    }
}
