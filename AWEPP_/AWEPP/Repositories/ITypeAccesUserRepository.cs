using AWEPP.Context;
using AWEPP.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
    public interface ITypeAccesUserRepository
    {
        Task<IEnumerable<TypeAccesUser>> GetAllTypeAccesUsersAsync();
        Task<TypeAccesUser> GetTypeAccesUserByIdAsync(int id);
        Task<TypeAccesUser> CreateTypeAccesUserAsync(TypeAccesUser typeAccesUser);
        Task<TypeAccesUser> UpdateTypeAccesUserAsync(TypeAccesUser typeAccesUser);
        Task SoftDeleteTypeAccesUserAsync(int id);
    }

}