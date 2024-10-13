using AWEPP.Model;
using AWEPP.Repositories;
using System.Threading.Tasks;

namespace AWEPP.Services
{
    public interface IUserHistoryServices
    {
        Task<IEnumerable<UserHistory>> GetAllUserHistoriesAsync();
        Task<UserHistory> GetUserHistoryByIdAsync(int id);
        Task<UserHistory> CreateUserHistoryAsync(UserHistory userHistory);
        Task<UserHistory> UpdateUserHistoryAsync(UserHistory userHistory);
        Task SoftDeleteUserHistoryAsync(int id);
    }

}