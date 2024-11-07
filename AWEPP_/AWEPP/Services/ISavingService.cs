using AWEPP.Modelo;

namespace AWEPP.Services
{
    public interface ISavingService
    {
        Task<IEnumerable<Saving>> GetAllSavingAsync();
        Task<Saving> GetSavingByIdAsync(int Id);
        Task CreateSavingAsync(Saving saving);
        Task UpdateSavingAsync(Saving saving);
        Task SoftDeleteSavingAsync(int Id);
    }
}
