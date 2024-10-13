using AWEPP.Modelo;
using AWEPP.Context;
using Microsoft.EntityFrameworkCore;
using AWEPP.Model;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
    public interface ICitiesRepository
    {
        Task<IEnumerable<Cities>> GetAllCitiesAsync();
        Task<Cities> GetCityByIdAsync(int id);
        Task<Cities> CreateCityAsync(Cities cities);
        Task<Cities> UpdateCityAsync(Cities cities);
        Task SoftDeleteCityAsync(int id);
    }
}