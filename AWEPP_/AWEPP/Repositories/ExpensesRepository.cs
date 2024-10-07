using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AWEPP.Repositories
{
    public class ExpensesRepository : IExpensesRepository
    {
        public Task CreateExpensesAsync(Expense expenses)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Expense>> GetAllExpensesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Expense> GetExpensesByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteExpensesAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateExpensesAsync(Expense expenses)
        {
            throw new NotImplementedException();
        }
    }
}
