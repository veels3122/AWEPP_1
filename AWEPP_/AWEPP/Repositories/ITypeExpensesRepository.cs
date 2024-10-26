using AWEPP.Model;

namespace AWEPP.Repositories
{
    public interface ITypeExpensesRepository
    {
        Task<IEnumerable<TypeExpenses>> GetAllTypeExpensesAsync();
        Task<TypeExpenses> GetTypeExpensesByIdAsync(int Id);
        Task CreateTypeExpensesAsync(TypeExpenses TypeExpenses);
        Task UpdateTypeExpensesAsync(TypeExpenses TypeExpenses);
        Task SoftDeleteTypeExpensesAsync(int Id);
    }
}

