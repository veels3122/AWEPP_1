using AWEPP.Modelo;
using System.Threading.Tasks;
using AWEPP.Repositories;

namespace AWEPP.Services
{
    public interface ICitiesServices
    {
        Task<IEnumerable<Cities>> GetAllCitiesAsync();
        Task<Cities> GetCityByIdAsync(int id);
        Task<Cities> CreateCityAsync(Cities cities);
        Task<Cities> UpdateCityAsync(Cities cities);
        Task SoftDeleteCityAsync(int id);
    }
}