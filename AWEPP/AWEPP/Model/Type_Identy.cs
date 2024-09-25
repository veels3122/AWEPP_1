using System.ComponentModel.DataAnnotations;

namespace AWEPP.Model
{
    public class Type_Identy
    {
        [Key]
        public int Id { get; set; }
        public required string Tipo_identy { get; set; }
    }
}
