using AWEPP.Model;

namespace AWEPP.Repositories
{
    public interface IUserHistoryRepository
    {

        Task<IEnumerable<UserHistory>> GetAllUsersHistoryAsync();
        Task<UserHistory> GetUserHistoryByIdAsync(int id);
        Task<UserHistory> CreateUserHistoryAsync(UserHistory userHistory);
        Task<UserHistory> UpdateUserHistoryAsync(UserHistory userHistory);
        Task SoftDeleteUserHistoryAsync(int id);
    }
    public class UserHistoryRepository : IUserHistoryRepository
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
