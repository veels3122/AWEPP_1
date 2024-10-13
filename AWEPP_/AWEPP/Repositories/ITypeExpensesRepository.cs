using AWEPP.Context;
using AWEPP.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
    public interface ITypeExpensesRepository
    {
        Task<IEnumerable<TypeExpenses>> GetAllTypeExpensesAsync();
        Task<TypeExpenses> GetTypeExpensesByIdAsync(int id);
        Task<TypeExpenses> CreateTypeExpensesAsync(TypeExpenses typeExpenses);
        Task<TypeExpenses> UpdateTypeExpensesAsync(TypeExpenses typeExpenses);
        Task SoftDeleteTypeExpensesAsync(int id); 
    }

}