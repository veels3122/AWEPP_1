using AWEPP.Modelo;
using System.ComponentModel.DataAnnotations;

namespace AWEPP.Model
{
    public class Type_accounts
    {
        [Key]
        public int Id_cta { get; set; }
        public required string Cuenta { get; set; }
        public virtual required Type_products Type_products { get; set; }
        
    }
}