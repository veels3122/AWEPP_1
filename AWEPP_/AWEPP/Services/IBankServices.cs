using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Repositories;
using System.Threading.Tasks;


namespace AWEPP.Services
{
    public interface IBankServices
    {
        Task<IEnumerable<Bank>> GetAllBanksAsync();
        Task<Bank> GetBankByIdAsync(int id);
        Task<Bank> CreateBankAsync(Bank bank);
        Task<Bank> UpdateBankAsync( Bank bank);
        Task SoftDeleteBankAsync(int id);
    }
}
