using AWEPP.Model;
using AWEPP.Modelo;

namespace AWEPP.Services
{
    public interface IUserServices
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserByIdAsync(int Id);
        Task CreateUserAsync(User Users);
        Task UpdateUserAsync(User Users);
        Task SoftDeleteUserAsync(int Id);
        Task<User> LoginAsync(string email, string password);


    }
}
