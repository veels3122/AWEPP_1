using AWEPP.Model;
using AWEPP.Modelo;
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
        public async Task CreateCitiesAsync(Cities Cities)
        {
            await _citiesRepository.CreateCitiesAsync(Cities);
        }

        public async Task<IEnumerable<Cities>> GetAllCitiesAsync()
        {
            return await _citiesRepository.GetAllCitiesAsync();
        }

        public async Task<Cities> GetCitiesByIdAsync(int Id)
        {
            return await _citiesRepository.GetCitiesByIdAsync(Id);
        }

        public async Task SoftDeleteCitiesAsync(int Id)
        {
            await _citiesRepository.SoftDeleteCitiesAsync(Id);
        }

        public async Task UpdateCitiesAsync(Cities Cities)
        {
            await _citiesRepository.UpdateCitiesAsync(Cities);
        }
    }
}






  

       

  




