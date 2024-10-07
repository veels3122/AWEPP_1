using System.ComponentModel.DataAnnotations;

namespace AWEPP.Model
{
    public class TypeProduct
    {
        [Key]
        public int Id { get; set; }
        public required int TypeProducts { get; set; }
        public required string Description { get; set; }

    }
}
