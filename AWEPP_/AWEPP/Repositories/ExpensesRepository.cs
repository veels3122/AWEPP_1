using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AWEPP.Repositories
{
    public class ExpensesRepository : IExpensesRepository
    {
        public Task CreateExpensesAsync(Expenses expenses)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Expenses>> GetAllExpensesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Expenses> GetExpensesByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteExpensesAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateExpensesAsync(Expenses expenses)
        {
            throw new NotImplementedException();
        }
    }
}
