using AWEPP.Model;
using AWEPP.Repositories;

namespace AWEPP.Services
{
    public class ExpensesService : IExpensesService
    {
        private readonly IExpenseRepository _expensesRepository;

        public ExpensesService(IExpenseRepository expensesRepository)
        {
            _expensesRepository = expensesRepository;
        }

        public async Task CreateExpensesAsync(Expense expenses)
        {
            await _expensesRepository.CreateExpensesAsync(expenses);
        }

        public async Task<IEnumerable<Expense>> GetAllExpensesAsync()
        {
            return await _expensesRepository.GetAllExpensesAsync();
        }

        public async Task<Expense> GetExpensesByIdAsync(int Id)
        {
            return await _expensesRepository.GetExpensesByIdAsync(Id);
        }

        public async Task SoftDeleteExpensesAsync(int Id)
        {
            await _expensesRepository.SoftDeleteExpensesAsync(Id);
        }

        public async Task UpdateExpensesAsync(Expense expenses)
        {
            await _expensesRepository.UpdateExpensesAsync(expenses);
        }
    }
}
