using AWEPP.Context;
using AWEPP.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
    public interface ITypeAccountsRepository
    {
        Task<IEnumerable<TypeAccounts>> GetAllTypeAccountsAsync();
        Task<TypeAccounts> GetTypeAccountByIdAsync(int id);
        Task<TypeAccounts> CreateTypeAccountAsync(TypeAccounts typeAccounts);
        Task<TypeAccounts> UpdateTypeAccountAsync(TypeAccounts typeAccounts);
        Task SoftDeleteTypeAccountAsync(int id);
    }

}