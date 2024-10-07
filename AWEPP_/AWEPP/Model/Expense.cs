using AWEPP.Modelo;
using System.ComponentModel.DataAnnotations;

namespace AWEPP.Model
{
    public class Expense
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
        public virtual required int TypeExpensesId { get; set; }
        public virtual required int TypeAccountsId { get; set; }
        public virtual required int TypeProductsId { get; set; }
        public virtual required int CustomerId { get; set; }

    }
}
