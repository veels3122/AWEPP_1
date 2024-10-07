using AWEPP.Model;
using AWEPP.Repositories;

namespace AWEPP.Services
{
    public interface ITypeAccesUserServices
    {
        Task<IEnumerable<TypeAccesUserServices>> GetAllTypeAccesUsersAsync();
        Task<TypeAccesUser> GetTypeAccesUserByIdAsync(int id);
        Task<TypeAccesUser> CreateTypeAccesUserAsync(TypeAccesUser typeAccesUser);
        Task<TypeAccesUser> UpdateTypeAccesUserAsync(TypeAccesUser typeAccesUser);
        Task SoftDeleteTypeAccesUserAsync(int id);
    }
    public class TypeAccesUserServices : ITypeAccesUserServices
    {
        public Task<TypeAccesUser> CreateTypeAccesUserAsync(TypeAccesUser typeAccesUser)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TypeAccesUserServices>> GetAllTypeAccesUsersAsync()
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
