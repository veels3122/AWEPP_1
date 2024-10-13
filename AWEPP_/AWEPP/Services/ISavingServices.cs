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

}