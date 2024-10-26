using System.ComponentModel.DataAnnotations;

namespace AWEPP.Model
{
    public class TypeAcces
    {
        
        [Key]
        public int Id { get; set; }
        public required string Typeacces { get; set; }
        public required bool IsDeleted { get; set; }

    }
}
