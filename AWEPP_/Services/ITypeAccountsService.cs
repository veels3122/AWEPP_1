using AWEPP.Model;

namespace AWEPP.Services
{
    public interface ITypeAccountsService
    {
        Task<IEnumerable<TypeAccounts>> GetAllTypeAccountsAsync();
        Task<TypeAccounts> GetTypeAccountsByIdAsync(int Id);
        Task CreateTypeAccountsAsync(TypeAccounts typeAccounts);
        Task UpdateTypeAccountsAsync(TypeAccounts typeAccounts);
        Task SoftDeleteTypeAccountsAsync(int Id);
    }
}
