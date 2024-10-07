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
        public virtual required int UserId { get; set; }
        public virtual required int TypeIdentyId { get; set; }
        public virtual required int ContactsId { get; set; }
        public virtual required int CitiesId { get; set; }
    }
}