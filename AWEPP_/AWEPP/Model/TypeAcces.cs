using System.ComponentModel.DataAnnotations;

namespace AWEPP.Model
{
    public class TypeAcces
    {
        
        [Key]
        public int Id { get; set; }
        public required string Typeaccesses { get; set; }

    }
}
