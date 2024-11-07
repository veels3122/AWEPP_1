using AWEPP.Model;
using AWEPP.Repositories;
using AWEPP.Services;

namespace AWEPP.Services
{
    public class TypeExpensesServices : ITypeExpensesServices
    {
        private readonly ITypeExpensesRepository _typeExpensesRepository;
        public TypeExpensesServices(ITypeExpensesRepository typeExpensesRepository)
        {
            _typeExpensesRepository = typeExpensesRepository;
        }

        public async Task CreateTypeExpensesAsync(TypeExpenses TypeExpenses)
        {
            await _typeExpensesRepository.CreateTypeExpensesAsync(TypeExpenses);
        }

        public async Task<IEnumerable<TypeExpenses>> GetAllTypeExpensesAsync()
        {
            return await _typeExpensesRepository.GetAllTypeExpensesAsync();
        }

        public async Task<TypeExpenses> GetTypeExpensesByIdAsync(int Id)
        {
            return await _typeExpensesRepository.GetTypeExpensesByIdAsync(Id);
        }

        public async Task SoftDeleteTypeExpensesAsync(int Id)
        {
            await _typeExpensesRepository.SoftDeleteTypeExpensesAsync(Id);
        }

        public async Task UpdateTypeExpensesAsync(TypeExpenses TypeExpenses)
        {
            await _typeExpensesRepository.UpdateTypeExpensesAsync(TypeExpenses);
        }
    }
}


