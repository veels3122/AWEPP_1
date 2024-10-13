using AWEPP.Modelo;
using AWEPP.Context;
using Microsoft.EntityFrameworkCore;
using AWEPP.Model;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{

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
                .ToListAsync();
        }

        public async Task<Cities> GetCityByIdAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.City
                .FirstOrDefaultAsync(c => c.Id == id );
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
            var cities = await _context.City.FindAsync(id);
            if (cities != null)
            {
                _context.City.Remove(cities);
                await _context.SaveChangesAsync();
            }
        }
    }

}