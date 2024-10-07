using AWEPP.Modelo;
using System.ComponentModel.DataAnnotations;

namespace AWEPP.Model
{
    public class TypeAccounts
    {
        [Key]
        public int Id { get; set; }
        public required string Accounts { get; set; }
        public virtual required TypeProduct Typeproducts { get; set; }
        
    }
}