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
        public virtual required TypeProducts TypeProducts { get; set; }
        
        public virtual required Bank Bank { get; set; }
        public virtual required Customer Customer { get; set; }
        public required bool IsDeleted { get; set; }

    }
}


