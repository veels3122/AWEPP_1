using AWEPP.Modelo;
using System.ComponentModel.DataAnnotations;

namespace AWEPP.Model
{
    public class TypeAccesUser
    {
        
    [Key]
        public int Id { get; set; }
        public virtual required string TypeAccesUserss {  get; set; }
        public required bool IsDeleted { get; set; }
    }
}
