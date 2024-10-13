using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
    public interface ISavingRepository
    {
        Task<IEnumerable<Saving>> GetAllSavingsAsync();
        Task<Saving> GetSavingByIdAsync(int id);
        Task<Saving> CreateSavingAsync(Saving saving);
        Task<Saving> UpdateSavingAsync(Saving saving);
        Task SoftDeleteSavingAsync(int id);
    }

}