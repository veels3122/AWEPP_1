using AWEPP.Modelo;

namespace AWEPP.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserByIdAsync(int Id);
        Task CreateUserAsync(User Users);
        Task UpdateUserAsync(User Users);
        Task SoftDeleteUserAsync(int Id);
        Task<User> GetUserByEmailAsync(string email);
    }
}
