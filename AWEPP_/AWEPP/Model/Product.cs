using AWEPP.Modelo;
using System.ComponentModel.DataAnnotations;

namespace AWEPP.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public virtual required int TypeAccounts { get; set; }
        public virtual required int TypeProducts { get; set; }
        public virtual required int Bank { get; set; }
        public required string Account { get; set; }
        public required string NumberAcount { get; set; }
        public required string TotalBalance { get; set; }
        public required string PartialBalance { get; set; }
        public required string Debt { get; set; }
        public required string DatePayment { get; set; }
        public required string Description { get; set; }
        public virtual required int Customer { get; set; }

    }
}




 