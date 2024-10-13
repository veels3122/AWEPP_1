using AWEPP.Model;
using AWEPP.Repositories;
using System.Threading.Tasks;

namespace AWEPP.Services
{
    public interface ITypeAccountsServices
    {
        Task<IEnumerable<TypeAccounts>> GetAllTypeAccountsAsync();
        Task<TypeAccounts> GetTypeAccountByIdAsync(int id);
        Task<TypeAccounts> CreateTypeAccountAsync(TypeAccounts typeAccount);
        Task<TypeAccounts> UpdateTypeAccountAsync(TypeAccounts typeAccount);
        Task SoftDeleteTypeAccountAsync(int id);
    }

}