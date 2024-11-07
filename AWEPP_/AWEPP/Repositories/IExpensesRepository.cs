using AWEPP.Model;

namespace AWEPP.Repositories
{
    public interface IExpensesRepository

    {
        Task<IEnumerable<Expenses>> GetAllExpensesAsync();
        Task<Expenses> GetExpensesByIdAsync(int Id);
        Task CreateExpensesAsync(Expenses expenses);
        Task UpdateExpensesAsync(Expenses expenses);
        Task SoftDeleteExpensesAsync(int Id);
    }
    
}
