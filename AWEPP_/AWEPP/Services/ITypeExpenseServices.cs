using AWEPP.Model;
using AWEPP.Repositories;
using System.Threading.Tasks;

namespace AWEPP.Services
{
    public interface ITypeExpenseServices
    {
        Task<IEnumerable<TypeExpense>> GetAllTypeExpensesAsync();
        Task<TypeExpense> GetTypeExpensesByIdAsync(int id);
        Task<TypeExpense> CreateTypeExpensesAsync(TypeExpense typeExpenses);
        Task<TypeExpense> UpdateTypeExpensesAsync(TypeExpense typeExpenses);
        Task SoftDeleteTypeExpensesAsync(int id);
    }

    public class TypeExpensesServices : ITypeExpenseServices
    {
        private readonly ITypeExpenseRepository _typeExpensesRepository;

        public TypeExpensesServices(ITypeExpenseRepository typeExpensesRepository)
        {
            _typeExpensesRepository = typeExpensesRepository;
        }

        public async Task<IEnumerable<TypeExpense>> GetAllTypeExpensesAsync()
        {
            return await _typeExpensesRepository.GetAllTypeExpensesAsync();
        }

        public async Task<TypeExpense> GetTypeExpensesByIdAsync(int id)
        {
            return await _typeExpensesRepository.GetTypeExpensesByIdAsync(id);
        }

        public async Task<TypeExpense> CreateTypeExpensesAsync(TypeExpense typeExpenses)
        {
            if (string.IsNullOrEmpty(typeExpenses.TypeExpenses))
            {
                throw new ArgumentException("El nombre del tipo de gasto es obligatorio.");
            }

            return await _typeExpensesRepository.CreateTypeExpensesAsync(typeExpenses);
        }

        public async Task<TypeExpense> UpdateTypeExpensesAsync(TypeExpense typeExpenses)
        {
            return await _typeExpensesRepository.UpdateTypeExpensesAsync(typeExpenses);
        }

        public async Task SoftDeleteTypeExpensesAsync(int id)
        {
            await _typeExpensesRepository.SoftDeleteTypeExpensesAsync(id);
        }
    }
}