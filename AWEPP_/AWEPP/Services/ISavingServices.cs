using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Repositories;
using System.Threading.Tasks;

namespace AWEPP.Services
{
    public interface ISavingServices
    {
        Task<IEnumerable<Saving>> GetAllSavingsAsync();
        Task<Saving> GetSavingByIdAsync(int id);
        Task<Saving> CreateSavingAsync(Saving saving);
        Task<Saving> UpdateSavingAsync(Saving saving);
        Task SoftDeleteSavingAsync(int id);
    }

    public class SavingServices : ISavingServices
    {
        private readonly ISavingRepository _savingRepository;

        public SavingServices(ISavingRepository savingRepository)
        {
            _savingRepository = savingRepository;
        }

        public async Task<IEnumerable<Saving>> GetAllSavingsAsync()
        {
            return await _savingRepository.GetAllSavingsAsync();
        }

        public async Task<Saving> GetSavingByIdAsync(int id)
        {
            return await _savingRepository.GetSavingByIdAsync(id);
        }

        public async Task<Saving> CreateSavingAsync(Saving saving)
        {
            // Aquí puedes agregar validaciones adicionales si es necesario
            return await _savingRepository.CreateSavingAsync(saving);
        }

        public async Task<Saving> UpdateSavingAsync(Saving saving)
        {
            // Aquí puedes agregar validaciones adicionales si es necesario
            return await _savingRepository.UpdateSavingAsync(saving);
        }

        public async Task SoftDeleteSavingAsync(int id)
        {
            await _savingRepository.SoftDeleteSavingAsync(id);
        }
    }
}