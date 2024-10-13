using AWEPP.Model;
using AWEPP.Repositories;
using System.Threading.Tasks;

namespace AWEPP.Services
{
    

    public class ExpenseServices : IExpensesServices
    {
        private readonly IExpensesRepository _expenseRepository;

        public ExpenseServices(IExpensesRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<IEnumerable<Expenses>> GetAllExpensesAsync()
        {
            return await _expenseRepository.GetAllExpensesAsync();
        }

        public async Task<Expenses> GetExpenseByIdAsync(int id)
        {
            return await _expenseRepository.GetExpenseByIdAsync(id);
        }

        public async Task<Expenses> CreateExpenseAsync(Expenses expense)
        {
            // Aquí puedes agregar validaciones adicionales si es necesario
            return await _expenseRepository.CreateExpenseAsync(expense);
        }

        public async Task<Expenses> UpdateExpenseAsync(Expenses expense)
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