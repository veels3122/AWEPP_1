using AWEPP.Modelo;

namespace AWEPP.Repositories
{
    public interface ICitiesRepository
    {
        Task<IEnumerable<Cities>> GetAllCitiesAsync();
        Task<Cities> GetCitiesByIdAsync(int Id);
        Task CreateCitiesAsync(Cities Cities);
        Task UpdateCitiesAsync(Cities Cities);
        Task SoftDeleteCitiesAsync(int Id);
    }
}


   

