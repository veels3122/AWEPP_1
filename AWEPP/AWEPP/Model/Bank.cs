using System.ComponentModel.DataAnnotations;

namespace AWEPP.Modelo
{
    public class Bank
    {
        [Key]
        public int Id { get; set; }
        public required string Banks { get; set; } // hi

    }
}
