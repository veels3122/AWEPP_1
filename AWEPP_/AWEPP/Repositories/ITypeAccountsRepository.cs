using AWEPP.Model;

namespace AWEPP.Repositories
{
    public interface ITypeAccountsRepository
    {
        Task<IEnumerable<TypeAccounts>> GetAllTypeAccountsAsync();
        Task<TypeAccounts> GetTypeAccountsByIdAsync(int Id);
        Task CreateTypeAccountsAsync(TypeAccounts typeAccounts);
        Task UpdateTypeAccountsAsync(TypeAccounts typeAccounts);
        Task SoftDeleteTypeAccountsAsync(int Id);
    }
}
