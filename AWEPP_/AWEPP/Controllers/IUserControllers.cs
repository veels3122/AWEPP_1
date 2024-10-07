using AWEPP.Modelo;
using AWEPP.Services;
using AWEPP.Repositories;

namespace AWEPP.Controllers
{
    public interface IUserControllers
    {
        Task<IEnumerable<Usertype>> GetAllUserAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(Usertype User);
        Task<User> UpdateUserAsync(Usertype User);
        Task SoftDeleteUserAsync(int id);
    }
    public class UserControllers : IUserControllers
    {
        public Task<User> CreateUserAsync(Usertype User)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usertype>> GetAllUserAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUserAsync(Usertype User)
        {
            throw new NotImplementedException();
        }
    }
}
