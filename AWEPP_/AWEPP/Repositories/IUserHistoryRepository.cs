using AWEPP.Context;
using AWEPP.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
    public interface IUserHistoryRepository
    {
        Task<IEnumerable<UserHistory>> GetAllUserHistoriesAsync();
        Task<UserHistory> GetUserHistoryByIdAsync(int id);
        Task<UserHistory> CreateUserHistoryAsync(UserHistory userHistory);
        Task<UserHistory> UpdateUserHistoryAsync(UserHistory userHistory);
        Task SoftDeleteUserHistoryAsync(int id);
    }

}