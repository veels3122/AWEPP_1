using AWEPP.Model;
using AWEPP.Services;

namespace AWEPP.Controllers
{
    public interface IUserHistoryControllers
    {
        Task<IEnumerable<UserHistory>> GetAllUsersHistoryAsync();
        Task<UserHistory> GetUserHistoryByIdAsync(int id);
        Task<UserHistory> CreateUserHistoryAsync(UserHistory userHistory);
        Task<UserHistory> UpdateUserHistoryAsync(UserHistory userHistory);
        Task SoftDeleteUserHistoryAsync(int id);
    }
    public class UserHistoryControllers : IUserHistoryControllers
    {
        public Task<UserHistory> CreateUserHistoryAsync(UserHistory userHistory)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserHistory>> GetAllUsersHistoryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserHistory> GetUserHistoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteUserHistoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserHistory> UpdateUserHistoryAsync(UserHistory userHistory)
        {
            throw new NotImplementedException();
        }
    }
}

