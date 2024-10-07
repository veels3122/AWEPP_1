using AWEPP.Modelo;
using System.Threading.Tasks;
using AWEPP.Repositories;

namespace AWEPP.Services
{
    public interface ICityServices
    {
        Task<IEnumerable<City>> GetAllCitiesAsync();
        Task<City> GetCityByIdAsync(int id);
        Task<City> CreateCityAsync(City cities);
        Task<City> UpdateCityAsync(City cities);
        Task SoftDeleteCityAsync(int id);
    }
    public class CitiesServices : ICityServices
    {
        private readonly ICityRepository _cityRepository;

        public CitiesServices(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<IEnumerable<City>> GetAllCitiesAsync()
        {
            return await _cityRepository.GetAllCitiesAsync();
        }

        public async Task<City> GetCityByIdAsync(int id)
        {
            return await _cityRepository.GetCityByIdAsync(id);
        }

        public async Task<City> CreateCityAsync(City cities)
        {
            if (string.IsNullOrEmpty(cities.Cities))
            {
                throw new ArgumentException("El nombre de la ciudad es obligatorio.");
            }

            return await _cityRepository.CreateCityAsync(cities);
        }

        public async Task<City> UpdateCityAsync(City cities)
        {
            if (cities.Id <= 0)
            {
                throw new ArgumentException("El ID de la ciudad es inválido.");
            }

            if (string.IsNullOrEmpty(cities.Cities))
            {
                throw new ArgumentException("El nombre de la ciudad es obligatorio.");
            }

            return await _cityRepository.UpdateCityAsync(cities);
        }

        public async Task SoftDeleteCityAsync(int id)
        {
            await _cityRepository.SoftDeleteCityAsync(id);
        }
    }
}