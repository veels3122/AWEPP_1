using AWEPP.Model;
using AWEPP.Repositories;
using System.Threading.Tasks;

namespace AWEPP.Services
{
    public interface IExpenseServices
    {
        Task<IEnumerable<Expense>> GetAllExpensesAsync();
        Task<Expense> GetExpenseByIdAsync(int id);
        Task<Expense> CreateExpenseAsync(Expense expense);
        Task<Expense> UpdateExpenseAsync(Expense expense);
        Task SoftDeleteExpenseAsync(int id);
    }

    public class ExpenseServices : IExpenseServices
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseServices(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<IEnumerable<Expense>> GetAllExpensesAsync()
        {
            return await _expenseRepository.GetAllExpensesAsync();
        }

        public async Task<Expense> GetExpenseByIdAsync(int id)
        {
            return await _expenseRepository.GetExpenseByIdAsync(id);
        }

        public async Task<Expense> CreateExpenseAsync(Expense expense)
        {
            // Aquí puedes agregar validaciones adicionales si es necesario
            return await _expenseRepository.CreateExpenseAsync(expense);
        }

        public async Task<Expense> UpdateExpenseAsync(Expense expense)
        {
            // Aquí puedes agregar validaciones adicionales si es necesario
            return await _expenseRepository.UpdateExpenseAsync(expense);
        }

        public async Task SoftDeleteExpenseAsync(int id)
        {
            await _expenseRepository.SoftDeleteExpenseAsync(id);
        }
    }
}