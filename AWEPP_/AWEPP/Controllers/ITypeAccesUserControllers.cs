using AWEPP.Model;
using AWEPP.Services;

namespace AWEPP.Controllers
{
    public interface ITypeAccesUserControllers
    {
        Task<IEnumerable<TypeAccesUserControllers>> GetAllTypeAccesUsersAsync();
        Task<TypeAccesUser> GetTypeAccesUserByIdAsync(int id);
        Task<TypeAccesUser> CreateTypeAccesUserAsync(TypeAccesUser typeAccesUser);
        Task<TypeAccesUser> UpdateTypeAccesUserAsync(TypeAccesUser typeAccesUser);
        Task SoftDeleteTypeAccesUserAsync(int id);
    }
    public class TypeAccesUserControllers : ITypeAccesUserControllers
    {
        public Task<TypeAccesUser> CreateTypeAccesUserAsync(TypeAccesUser typeAccesUser)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TypeAccesUserControllers>> GetAllTypeAccesUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TypeAccesUser> GetTypeAccesUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteTypeAccesUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TypeAccesUser> UpdateTypeAccesUserAsync(TypeAccesUser typeAccesUser)
        {
            throw new NotImplementedException();
        }
    }
}
