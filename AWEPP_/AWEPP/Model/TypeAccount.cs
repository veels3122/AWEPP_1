using AWEPP.Modelo;
using System.ComponentModel.DataAnnotations;

namespace AWEPP.Model
{
    public class TypeAccount
    {
        [Key]
        public int Id { get; set; }
        public required string TypeAccounts { get; set; }
        public virtual required int TypeProductsId { get; set; }
        
    }
}