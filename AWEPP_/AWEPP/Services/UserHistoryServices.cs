using AWEPP.Model;
using AWEPP.Repositories;
using System.Threading.Tasks;

namespace AWEPP.Services
{
   
    public class UserHistoryServices : IUserHistoryServices
    {
        private readonly IUserHistoryRepository _userHistoryRepository;

        public UserHistoryServices(IUserHistoryRepository userHistoryRepository)
        {
            _userHistoryRepository = userHistoryRepository;
        }

        public async Task<IEnumerable<UserHistory>> GetAllUserHistoriesAsync()
        {
            return await _userHistoryRepository.GetAllUserHistoriesAsync();
        }

        public async Task<UserHistory> GetUserHistoryByIdAsync(int id)
        {
            return await _userHistoryRepository.GetUserHistoryByIdAsync(id);
        }

        public async Task<UserHistory> CreateUserHistoryAsync(UserHistory userHistory)
        {
            // Aquí puedes agregar validaciones adicionales si es necesario
            return await _userHistoryRepository.CreateUserHistoryAsync(userHistory);
        }

        public async Task<UserHistory> UpdateUserHistoryAsync(UserHistory userHistory)
        {
            // Aquí puedes agregar validaciones adicionales si es necesario
            return await _userHistoryRepository.UpdateUserHistoryAsync(userHistory);
        }

        public async Task SoftDeleteUserHistoryAsync(int id)
        {
            await _userHistoryRepository.SoftDeleteUserHistoryAsync(id);
        }
    }
}