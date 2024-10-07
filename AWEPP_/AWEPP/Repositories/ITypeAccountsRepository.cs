using AWEPP.Model;

namespace AWEPP.Repositories
{
    public interface ITypeAccountsRepository
    {
        Task<IEnumerable<TypeAccount>> GetAllTypeAccountsAsync();
        Task<TypeAccount> GetTypeAccountsByIdAsync(int Id);
        Task CreateTypeAccountsAsync(TypeAccount typeAccounts);
        Task UpdateTypeAccountsAsync(TypeAccount typeAccounts);
        Task SoftDeleteTypeAccountsAsync(int Id);
    }
}
