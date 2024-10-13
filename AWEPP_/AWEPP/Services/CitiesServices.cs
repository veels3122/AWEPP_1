using AWEPP.Modelo;
using System.Threading.Tasks;
using AWEPP.Repositories;

namespace AWEPP.Services
{
    
    public class CitiesServices : ICitiesServices
    {
        private readonly ICitiesRepository _citiesRepository;

        public CitiesServices(ICitiesRepository citiesRepository)
        {
            _citiesRepository = citiesRepository;
        }

        public async Task<IEnumerable<Cities>> GetAllCitiesAsync()
        {
            return await _citiesRepository.GetAllCitiesAsync();
        }

        public async Task<Cities> GetCityByIdAsync(int id)
        {
            return await _citiesRepository.GetCityByIdAsync(id);
        }

        public async Task<Cities> CreateCityAsync(Cities cities)
        {
            if (string.IsNullOrEmpty(cities.City))
            {
                throw new ArgumentException("El nombre de la ciudad es obligatorio.");
            }

            return await _citiesRepository.CreateCityAsync(cities);
        }

        public async Task<Cities> UpdateCityAsync(Cities cities)
        {
            if (cities.Id <= 0)
            {
                throw new ArgumentException("El ID de la ciudad es inválido.");
            }

            if (string.IsNullOrEmpty(cities.City))
            {
                throw new ArgumentException("El nombre de la ciudad es obligatorio.");
            }

            return await _citiesRepository.UpdateCityAsync(cities);
        }

        public async Task SoftDeleteCityAsync(int id)
        {
            await _citiesRepository.SoftDeleteCityAsync(id);
        }
    }
}