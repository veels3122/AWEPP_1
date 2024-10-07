using AWEPP.Modelo;
using System.ComponentModel.DataAnnotations;

namespace AWEPP.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public virtual required int TypeAccountsId { get; set; }
        public virtual required int TypeProductsId { get; set; }
        public virtual required int BankId { get; set; }
        public required string Account { get; set; }
        public required string NumberAcount { get; set; }
        public required string TotalBalance { get; set; }
        public required string PartialBalance { get; set; }
        public required string Debt { get; set; }
        public required string DatePayment { get; set; }
        public required string Description { get; set; }
        public virtual required int CustomerId { get; set; }

    }
}




 