using AWEPP.Modelo;
using System.ComponentModel.DataAnnotations;
using AWEPP.Model;
using AWEPP.Models;

namespace AWEPP.Model
{
    public class TypeAccounts
    {
        [Key]
        public int Id { get; set; }
        public required string Accounts { get; set; }
        public virtual required TypeProducts Typeproducts { get; set; }
        public required bool IsDeleted { get; set; }

    }
}