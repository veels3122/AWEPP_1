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
        public async Task CreateTypeAccountsAsync(TypeAccounts typeAccounts)
        {
            await _typeAccountsRepository.CreateTypeAccountsAsync(typeAccounts);
        }

        public async Task<IEnumerable<TypeAccounts>> GetAllTypeAccountsAsync()
        {
            return await _typeAccountsRepository.GetAllTypeAccountsAsync();
        }

        public async Task<TypeAccounts> GetTypeAccountsByIdAsync(int Id)
        {
            return await _typeAccountsRepository.GetTypeAccountsByIdAsync(Id);
        }

        public async Task SoftDeleteTypeAccountsAsync(int Id)
        {
           await _typeAccountsRepository.SoftDeleteTypeAccountsAsync(Id);
        }

        public async Task UpdateTypeAccountsAsync(TypeAccounts typeAccounts)
        {
            await _typeAccountsRepository.UpdateTypeAccountsAsync(typeAccounts);
        }
    }
}
