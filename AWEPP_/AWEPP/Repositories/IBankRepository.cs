using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Modelo;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace AWEPP.Repositories
{
    public interface IBankRepository
    {
        Task<IEnumerable<Bank>> GetAllBanksAsync();
        Task<Bank> GetBankByIdAsync(int id);
        Task<Bank> CreateBankAsync(Bank bank);
        Task<Bank> UpdateBankAsync(Bank bank);
        Task SoftDeleteBankAsync(int id);

    }
}