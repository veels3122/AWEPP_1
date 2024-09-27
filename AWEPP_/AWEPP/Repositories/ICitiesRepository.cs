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
    public class CitiesRepository : ICitiesRepository
    {
        private readonly Aweppcontext _context;

        public CitiesRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cities>> GetAllCitiesAsync()
        {
            return await _context.City
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }

        public async Task<Cities> GetCityByIdAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.City
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Cities> UpdateCityAsync(Cities cities)
        {
            _context.Entry(cities).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cities;
        }

        public async Task<Cities> CreateCityAsync(Cities cities)
        {
            _context.City.Add(cities);
            await _context.SaveChangesAsync();
            return cities;
        }

        public async Task SoftDeleteCityAsync(int id)
        {
            var city = await _context.City.FindAsync(id);
            if (city != null)
            {
                city.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }

}