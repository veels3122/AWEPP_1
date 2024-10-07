using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Repositories;
using System.Threading.Tasks;

namespace AWEPP.Services
{
    public interface IUserServices
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task SoftDeleteUserAsync(int id);
    }

    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            // Aquí puedes agregar validaciones adicionales si es necesario
            return await _userRepository.CreateUserAsync(user);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            // Aquí puedes agregar validaciones adicionales si es necesario
            return await _userRepository.UpdateUserAsync(user);
        }

        public async Task SoftDeleteUserAsync(int id)
        {
            await _userRepository.SoftDeleteUserAsync(id);
        }
    }
}