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
    public class BankRepository : IBankRepository
    {
        private readonly Aweppcontext _context;

        public BankRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bank>> GetAllBanksAsync()
        {
            return await _context.Banks
                .ToListAsync();
        }

        public async Task<Bank> GetBankByIdAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Banks
               .FirstOrDefaultAsync(b => b.Id == id );
#pragma warning restore CS8603 // Possible null reference return.
        }

        


        public async Task<Bank> CreateBankAsync(Bank bank)
        {
            _context.Banks.Add(bank);
            await _context.SaveChangesAsync();
            return bank;
        }
        public async Task<Bank> UpdateBankAsync(Bank bank)
        {
            _context.Entry(bank).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return bank;
        }

        public async Task SoftDeleteBankAsync(int id)
        {
            var bank = await _context.Banks.FindAsync(id);
            
            if (bank != null)
            {
               _context.Banks.Remove(bank);
                await _context.SaveChangesAsync();
            }
            
        }
    }
}
