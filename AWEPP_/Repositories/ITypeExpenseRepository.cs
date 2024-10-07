using AWEPP.Model;

namespace AWEPP.Repositories
{
    public interface ITypeExpenseRepository

    {
        Task<IEnumerable<Expense>> GetAllExpenseAsync();
        Task<Expenses> GetExpenseByIdAsync(int Id);
        Task CreateExpenseAsync(Expense expense);
        Task UpdateExpenseAsync(Expense expense);
        Task SoftDeleteExpenseAsync(int Id);
    }

}
