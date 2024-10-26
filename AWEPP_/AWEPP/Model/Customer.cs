using AWEPP.Modelo;
using System.ComponentModel.DataAnnotations;

namespace AWEPP.Model
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public required int NumIdenty { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Adress { get; set; }
        public required string Contact { get; set; }
        public virtual required User User { get; set; }
        public virtual required TypeIdenty TypeIdenty { get; set; }
        public virtual required Contacts Contacts { get; set; }
        public virtual required Cities Cities { get; set; }
        public required bool IsDeleted { get; set; }

    }
}