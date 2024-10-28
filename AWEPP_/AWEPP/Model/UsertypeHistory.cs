using AWEPP.Modelo;
using System.ComponentModel.DataAnnotations;

namespace AWEPP.Model
{
    public class UsertypeHistory
    {
        [Key]
        public int Id { get; set; }
        public virtual required Usertype Usertype { get; set; }
        public required string Datecreate { get; set; }
        public required string Modifed { get; set; }
        public required string ModifedBy { get; set; }
        public required string datemodified { get; set; }
        public required bool IsDeleted { get; set; }
    }
}
