using AWEPP.Context;
using AWEPP.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
    public interface IExpensesRepository
    {
        Task<IEnumerable<Expenses>> GetAllExpensesAsync();
        Task<Expenses> GetExpenseByIdAsync(int id);
        Task<Expenses> CreateExpenseAsync(Expenses expenses);
        Task<Expenses> UpdateExpenseAsync(Expenses expenses);
        Task SoftDeleteExpenseAsync(int id);
    }
}