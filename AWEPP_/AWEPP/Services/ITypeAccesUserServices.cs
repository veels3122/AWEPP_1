using AWEPP.Model;
using AWEPP.Modelo;

namespace AWEPP.Services
{
    public interface ITypeAccesUserServices
    {
        Task<IEnumerable<TypeAccesUser>> GetAllTypeAccesUserAsync();
        Task<TypeAccesUser> GetTypeAccesUserByIdAsync(int Id);
        Task CreateTypeAccesUserAsync(TypeAccesUser TypeAccessUsers);
        Task UpdateTypeAccesUserAsync(TypeAccesUser TypeAccessUsers);
        Task SoftDeleteTypeAccesUserAsync(int Id);
    }
}
