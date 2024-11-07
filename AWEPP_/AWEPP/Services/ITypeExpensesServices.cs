using AWEPP.Model;

namespace AWEPP.Services
{
    public interface ITypeExpensesServices
    {
        Task<IEnumerable<TypeExpenses>> GetAllTypeExpensesAsync();
        Task<TypeExpenses> GetTypeExpensesByIdAsync(int Id);
        Task CreateTypeExpensesAsync(TypeExpenses TypeExpenses);
        Task UpdateTypeExpensesAsync(TypeExpenses TypeExpenses);
        Task SoftDeleteTypeExpensesAsync(int Id);
    }
}
