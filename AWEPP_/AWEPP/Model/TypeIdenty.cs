using System.ComponentModel.DataAnnotations;

namespace AWEPP.Model
{
    public class TypeIdenty
    {
        [Key]
        public int Id { get; set; }
        public required string TipoIdenty { get; set; }
    }
}
