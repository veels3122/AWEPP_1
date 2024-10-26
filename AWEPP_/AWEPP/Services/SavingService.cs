using AWEPP.Modelo;
using AWEPP.Repositories;

namespace AWEPP.Services
{
    public class SavingService : ISavingService
    {
        private readonly ISavingRepository _savingRepository;

        public SavingService(ISavingRepository savingRepository)
        {
            _savingRepository = savingRepository;
        }
        public async Task CreateSavingAsync(Saving saving)
        {
            await _savingRepository.CreateSavingAsync(saving);
        }

        public async Task<IEnumerable<Saving>> GetAllSavingAsync()
        {
            return await _savingRepository.GetAllSavingAsync();
        }

        public async Task<Saving> GetSavingByIdAsync(int Id)
        {
            return await _savingRepository.GetSavingByIdAsync(Id);
        }

        public async Task SoftDeleteSavingAsync(int Id)
        {
            await _savingRepository.SoftDeleteSavingAsync(Id);
        }

        public async Task UpdateSavingAsync(Saving saving)
        {
            await _savingRepository.UpdateSavingAsync(saving);
        }
    }
}
