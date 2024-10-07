using AWEPP.Model;

namespace AWEPP.Services
{
    public interface ITypeAccountsService
    {
        Task<IEnumerable<TypeAccount>> GetAllTypeAccountsAsync();
        Task<TypeAccount> GetTypeAccountsByIdAsync(int Id);
        Task CreateTypeAccountsAsync(TypeAccount typeAccounts);
        Task UpdateTypeAccountsAsync(TypeAccount typeAccounts);
        Task SoftDeleteTypeAccountsAsync(int Id);
    }
}
