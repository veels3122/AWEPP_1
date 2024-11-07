using System.ComponentModel.DataAnnotations;

namespace AWEPP.Modelo
{
    public class Cities
    {
        [Key]
        public int Id { get; set; }
        public required string City { get; set; }
        public required bool IsDeleted { get; set; }
    }
}