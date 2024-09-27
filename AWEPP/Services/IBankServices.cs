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
        Task<Bank> UpdateBankAsync(Bank bank);
        Task SoftDeleteBankAsync(int id);
    }
    public class BankServices : IBankServices
    {
        private readonly IBankRepository _bankRepository;

        public BankServices(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;

        }

        public async Task<IEnumerable<Bank>> GetAllBanksAsync()

        {
            return await _bankRepository.GetAllBanksAsync();
        }

        public async Task<Bank> GetBankByIdAsync(int id)
        {
            return await _bankRepository.GetBankByIdAsync(id);
        }

        public async Task<Bank> CreateBankAsync(Bank bank)
        {

            if (string.IsNullOrEmpty(bank.Banks))
            {
                throw new ArgumentException("El nombre del banco es obligatorio.");
            }

            return await _bankRepository.CreateBankAsync(bank);
        }

        public async Task<Bank> UpdateBankAsync(Bank bank)
        {

            if (bank.Id <= 0)
            {
                throw new ArgumentException("El ID del banco es inválido.");
            }


            if (string.IsNullOrEmpty(bank.Banks))
            {
                throw new ArgumentException("El nombre del banco es obligatorio.");
            }

            return await _bankRepository.UpdateBankAsync(bank);
        }

        public async Task SoftDeleteBankAsync(int id)
        {
            await _bankRepository.SoftDeleteBankAsync(id);
        }
    }
}
