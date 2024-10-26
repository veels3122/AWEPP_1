using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Repositories;
using AWEPP.Services;

namespace AWEPP.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUserAsync(User Users)
        {
            await _userRepository.CreateUserAsync(Users);
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
        return await _userRepository.GetAllUserAsync();
        }

        public async Task<User> GetUserByIdAsync(int Id)
        {
        return await _userRepository.GetUserByIdAsync(Id);
        }

        public async Task SoftDeleteUserAsync(int Id)
        {
        await _userRepository.SoftDeleteUserAsync(Id);
        }

        public async Task UpdateUserAsync(User Users)
        {
         await _userRepository.UpdateUserAsync(Users);
        }
    }
}


