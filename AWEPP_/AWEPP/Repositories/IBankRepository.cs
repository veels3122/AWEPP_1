using AWEPP.Model;
using AWEPP.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AWEPP.Repositories
{
    public interface IBankRepository
    {
        Task<ActionResult<IEnumerable<Bank>>> GetAllBankAsync();
        Task<Bank> GetBankByIdAsync(int Id);
        Task CreateBankAsync(Bank Banks);
        Task UpdateBankAsync(Bank Banks);
        Task SoftDeleteBankAsync(int Id);
    }
}


