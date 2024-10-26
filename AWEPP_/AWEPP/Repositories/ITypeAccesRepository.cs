using AWEPP.Model;
using AWEPP.Modelo;

namespace AWEPP.Repositories
{
    public interface ITypeAccesRepository
    {
        Task<IEnumerable<TypeAcces>> GetAllTypeAccesAsync();
        Task<TypeAcces> GetTypeAccesByIdAsync(int Id);
        Task CreateTypeAccesAsync(TypeAcces TypeAccesses);
        Task UpdateTypeAccesAsync(TypeAcces TypeAccesses);
        Task SoftDeleteTypeAccesAsync(int Id);
    }
}
