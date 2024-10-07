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
        public virtual required int TypeProducts { get; set; }
        public virtual required int TypeAccounts { get; set; }
        public virtual required int Products { get; set; }
        public virtual required int Bank { get; set; }
        public virtual required int Customer { get; set; }

    }
}


