using System.ComponentModel.DataAnnotations;

namespace AWEPP.Model
{
    public class TypeProducts
    {
        [Key]
        public int Id { get; set; }
        public required int Producd { get; set; }
        public required string Description { get; set; }
        public required bool IsDeleted { get; set; }

    }
}
