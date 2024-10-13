using AWEPP.Model;
using AWEPP.Repositories;
using System.Threading.Tasks;

namespace AWEPP.Services
{
    public interface IExpensesServices
    {
        Task<IEnumerable<Expenses>> GetAllExpensesAsync();
        Task<Expenses> GetExpenseByIdAsync(int id);
        Task<Expenses> CreateExpenseAsync(Expenses expense);
        Task<Expenses> UpdateExpenseAsync(Expenses expense);
        Task SoftDeleteExpenseAsync(int id);
    }

}