using AWEPP.Context;
using AWEPP.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
   
    public class UserHistoryRepository : IUserHistoryRepository
    {
        private readonly Aweppcontext _context;

        public UserHistoryRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserHistory>> GetAllUserHistoriesAsync()
        {
            return await _context.UserHistories
                .ToListAsync();
        }

        public async Task<UserHistory> GetUserHistoryByIdAsync(int id)
        {
#pragma warning disable CS8603
            return await _context.UserHistories
                .FirstOrDefaultAsync(c => c.Id == id);
#pragma warning disable CS8603
        }

        public async Task<UserHistory> CreateUserHistoryAsync(UserHistory userHistory)
        {
            _context.UserHistories.Add(userHistory);
            await _context.SaveChangesAsync();
            return userHistory;
        }

        public async Task<UserHistory> UpdateUserHistoryAsync(UserHistory userHistory)
        {
            var existingUserHistory = await _context.UserHistories.FindAsync(userHistory.Id);

            if (existingUserHistory == null)
            {
                throw new NotFoundException("UserHistory not found");
            }

            // Actualiza las propiedades según sea necesario
            existingUserHistory.Datecreate = userHistory.Datecreate;
            existingUserHistory.Modifed = userHistory.Modifed;
            existingUserHistory.ModifedBy = userHistory.ModifedBy;
            existingUserHistory.datemodified = userHistory.datemodified;

            _context.Entry(existingUserHistory).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return existingUserHistory;
        }

        public async Task SoftDeleteUserHistoryAsync(int id)
        {
            var userHistory = await _context.UserHistories.FindAsync(id);
            if (userHistory != null)
            {
                _context.UserHistories.Remove(userHistory);
                await _context.SaveChangesAsync();
            }
        }
    }
}