using System.ComponentModel.DataAnnotations;

namespace AWEPP.Model
{
    public class Type_expenses
    {
        [Key]
        public int Id { get; set; }
        public required string Gasto { get; set; }

    }
}