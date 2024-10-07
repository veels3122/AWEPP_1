using AWEPP.Model;
using System.ComponentModel.DataAnnotations;

namespace AWEPP.Modelo
{
    public class Saving
    {
        [Key]
        public int Id { get; set; }
        public required string dateStar { get; set; }
        public required string dateEnd { get; set; }
        public required string SavingAmount { get; set; }
        public required string paymentAmount { get; set; }
        public required string Description { get; set; }
        public virtual required int TypeProductsId { get; set; }
        public virtual required int TypeAccountsId { get; set; }
        public virtual required int ProductsId { get; set; }
        public virtual required int BankId { get; set; }
        public virtual required int CustomerId { get; set; }

    }
}


