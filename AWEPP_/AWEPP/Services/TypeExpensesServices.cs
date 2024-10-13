using AWEPP.Model;
using AWEPP.Repositories;
using System.Threading.Tasks;

namespace AWEPP.Services
{
    public class TypeExpensesServices : ITypeExpensesServices
    {
        private readonly ITypeExpensesRepository _typeExpensesRepository;

        public TypeExpensesServices(ITypeExpensesRepository typeExpensesRepository)
        {
            _typeExpensesRepository = typeExpensesRepository;
        }

        public async Task<IEnumerable<TypeExpenses>> GetAllTypeExpensesAsync()
        {
            return await _typeExpensesRepository.GetAllTypeExpensesAsync();
        }

        public async Task<TypeExpenses> GetTypeExpensesByIdAsync(int id)
        {
            return await _typeExpensesRepository.GetTypeExpensesByIdAsync(id);
        }

        public async Task<TypeExpenses> CreateTypeExpensesAsync(TypeExpenses typeExpenses)
        {
            if (string.IsNullOrEmpty(typeExpenses.Expenses))
            {
                throw new ArgumentException("El nombre del tipo de gasto es obligatorio.");
            }

            return await _typeExpensesRepository.CreateTypeExpensesAsync(typeExpenses);
        }

        public async Task<TypeExpenses> UpdateTypeExpensesAsync(TypeExpenses typeExpenses)
        {
            return await _typeExpensesRepository.UpdateTypeExpensesAsync(typeExpenses);
        }

        public async Task SoftDeleteTypeExpensesAsync(int id)
        {
            await _typeExpensesRepository.SoftDeleteTypeExpensesAsync(id);
        }
    }
}