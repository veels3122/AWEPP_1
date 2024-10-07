using AWEPP.Modelo;
using AWEPP.Context;
using Microsoft.EntityFrameworkCore;
using AWEPP.Model;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllCitiesAsync();
        Task<City> GetCityByIdAsync(int id);
        Task<City> CreateCityAsync(City cities);
        Task<City> UpdateCityAsync(City cities);
        Task SoftDeleteCityAsync(int id);
    }
    public class CityRepository : ICityRepository
    {
        private readonly Aweppcontext _context;

        public CityRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> GetAllCitiesAsync()
        {
            return await _context.Cities
                .ToListAsync();
        }

        public async Task<City> GetCityByIdAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Cities
                .FirstOrDefaultAsync(c => c.Id == id );
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<City> UpdateCityAsync(City cities)
        {
            _context.Entry(cities).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cities;
        }

        public async Task<City> CreateCityAsync(City cities)
        {
            _context.Cities.Add(cities);
            await _context.SaveChangesAsync();
            return cities;
        }

        public async Task SoftDeleteCityAsync(int id)
        {
            var cities = await _context.Cities.FindAsync(id);
            if (cities != null)
            {
                _context.Cities.Remove(cities);
                await _context.SaveChangesAsync();
            }
        }
    }

}