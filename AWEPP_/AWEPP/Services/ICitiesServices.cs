using AWEPP.Modelo;

namespace AWEPP.Services
{
    public interface ICitiesServices
    {
        Task<IEnumerable<Cities>> GetAllCitiesAsync();
        Task<Cities> GetCitiesByIdAsync(int Id);
        Task CreateCitiesAsync(Cities Cities);
        Task UpdateCitiesAsync(Cities Cities);
        Task SoftDeleteCitiesAsync(int Id);
    }
}
