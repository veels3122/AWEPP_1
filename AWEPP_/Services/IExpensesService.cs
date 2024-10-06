using AWEPP.Model;

namespace AWEPP.Services
{
    public interface IExpensesService

    {
        Task<IEnumerable<Expenses>> GetAllExpensesAsync();
        Task<Expenses> GetExpensesByIdAsync(int Id);
        Task CreateExpensesAsync(Expenses expenses);
        Task UpdateExpensesAsync(Expenses expenses);
        Task SoftDeleteExpensesAsync(int Id);
    }
}
