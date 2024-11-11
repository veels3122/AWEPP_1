using AWEPP.Modelo;
using System.ComponentModel.DataAnnotations;

namespace AWEPP.Model
{
    public class Expenses
    {
        [Key]
        public int Id { get; set; }
        public required string Description { get; set; }
        public required string TotalExpense { get; set; }
        public required string NumberFee { get; set; }
        public required string DateExpense { get; set; }
        public required string DateStart { get; set; }
        public required string DateEnd { get; set; }
        public required string BalanceFee { get; set; }
        public virtual required TypeExpenses TypeExpenses { get; set; }
        public virtual required TypeAccounts TypeAccounts { get; set; }
        
        public virtual required Customer Customer { get; set; }
        public required bool IsDeleted { get; set; }

    }
}
