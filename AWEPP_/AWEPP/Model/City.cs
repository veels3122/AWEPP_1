using System.ComponentModel.DataAnnotations;

namespace AWEPP.Modelo
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public required string Cities { get; set; }
    }
}