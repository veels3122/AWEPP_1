using AWEPP.Model;
using AWEPP.Modelo;

namespace AWEPP.Repositories
{
    public interface IBankRepository
    {
        Task<IEnumerable<Bank>> GetAllBankAsync();
        Task<Bank> GetBankByIdAsync(int Id);
        Task CreateBankAsync(Bank Banks);
        Task UpdateBankAsync(Bank Banks);
        Task SoftDeleteBankAsync(int Id);
    }
}


