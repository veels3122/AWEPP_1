using AWEPP.Modelo;
using System.ComponentModel.DataAnnotations;

namespace AWEPP.Model
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        
        public virtual required TypeProducts TypeProducts { get; set; }
        public virtual required Bank Bank { get; set; }
        public required string Account { get; set; }
        public required string NumberAccount { get; set; }
        public required string TotalBalance { get; set; }
        public required string PartialBalance { get; set; }
        public required string Debt { get; set; }
        public required string DatePayment { get; set; }
        public required string Description { get; set; }
        public virtual required Customer Customer { get; set; }
        public required bool IsDeleted { get; set; }

    }
}




 