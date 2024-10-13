using AWEPP.Model;
using AWEPP.Repositories;
using System.Threading.Tasks;

namespace AWEPP.Services
{
    public interface ITypeAccesUserServices
    {
        Task<IEnumerable<TypeAccesUser>> GetAllTypeAccesUsersAsync();
        Task<TypeAccesUser> GetTypeAccesUserByIdAsync(int id);
        Task<TypeAccesUser> CreateTypeAccesUserAsync(TypeAccesUser typeAccesUser);
        Task<TypeAccesUser> UpdateTypeAccesUserAsync(TypeAccesUser typeAccesUser);
        Task SoftDeleteTypeAccesUserAsync(int id);
    }

}