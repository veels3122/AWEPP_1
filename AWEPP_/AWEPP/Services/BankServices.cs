using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AWEPP.Services
{
    public class BankServices : IBankServices

    {

        private readonly IBankRepository _bankRepository;

        public BankServices(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }



        public async Task CreateBankAsync(Bank Banks)
        {
            await _bankRepository.CreateBankAsync(Banks);
        }

        public async Task<ActionResult<IEnumerable<Bank>>> GetAllBankAsync()
        {
            return await _bankRepository.GetAllBankAsync();
        }

        public async  Task<Bank> GetBankByIdAsync(int Id)
        {
            return await _bankRepository.GetBankByIdAsync(Id);
        }

        public async Task SoftDeleteBankAsync(int Id)
        {
            await _bankRepository.SoftDeleteBankAsync(Id);
        }

        public async Task UpdateBankAsync(Bank Banks)
        {
            await _bankRepository.UpdateBankAsync(Banks);
        }
    }
}





