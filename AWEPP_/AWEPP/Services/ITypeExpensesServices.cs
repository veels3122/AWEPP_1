using AWEPP.Model;
using AWEPP.Repositories;
using System.Threading.Tasks;

namespace AWEPP.Services
{
    public interface ITypeExpensesServices
    {
        Task<IEnumerable<TypeExpenses>> GetAllTypeExpensesAsync();
        Task<TypeExpenses> GetTypeExpensesByIdAsync(int id);
        Task<TypeExpenses> CreateTypeExpensesAsync(TypeExpenses typeExpenses);
        Task<TypeExpenses> UpdateTypeExpensesAsync(TypeExpenses typeExpenses);
        Task SoftDeleteTypeExpensesAsync(int id);
    }

}