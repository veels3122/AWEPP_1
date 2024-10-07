using AWEPP.Model;
using AWEPP.Modelo;

namespace AWEPP.Repositories
{
    public interface ISavingRepository
    {
        Task<IEnumerable<Saving>> GetAllSavingAsync();
        Task<Saving> GetSavingByIdAsync(int Id);
        Task CreateSavingAsync(Saving saving);
        Task UpdateSavingAsync(Saving saving);
        Task SoftDeleteSavingAsync(int Id);
    }
}
