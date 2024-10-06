using AWEPP.Model;
using AWEPP.Repositories;

namespace AWEPP.Services
{
    public class ExpensesService : IExpensesService
    {
        private readonly IExpensesRepository _expensesRepository;

        public ExpensesService(IExpensesRepository expensesRepository)
        {
            _expensesRepository = expensesRepository;
        }

        public async Task CreateExpensesAsync(Expenses expenses)
        {
            await _expensesRepository.CreateExpensesAsync(expenses);
        }

        public async Task<IEnumerable<Expenses>> GetAllExpensesAsync()
        {
            return await _expensesRepository.GetAllExpensesAsync();
        }

        public async Task<Expenses> GetExpensesByIdAsync(int Id)
        {
            return await _expensesRepository.GetExpensesByIdAsync(Id);
        }

        public async Task SoftDeleteExpensesAsync(int Id)
        {
            await _expensesRepository.SoftDeleteExpensesAsync(Id);
        }

        public async Task UpdateExpensesAsync(Expenses expenses)
        {
            await _expensesRepository.UpdateExpensesAsync(expenses);
        }
    }
}
