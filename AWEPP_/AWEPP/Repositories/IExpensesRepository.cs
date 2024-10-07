﻿using AWEPP.Model;

namespace AWEPP.Repositories
{
    public interface IExpensesRepository

    {
        Task<IEnumerable<Expense>> GetAllExpensesAsync();
        Task<Expense> GetExpensesByIdAsync(int Id);
        Task CreateExpensesAsync(Expense expenses);
        Task UpdateExpensesAsync(Expense expenses);
        Task SoftDeleteExpensesAsync(int Id);
    }
    
}
