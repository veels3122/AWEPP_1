using System.ComponentModel.DataAnnotations;

namespace AWEPP.Model
{
    public class TypeExpenses
    {
        [Key]
        public int Id { get; set; }
        public required string Expenses { get; set; }
        public required bool IsDeleted { get; set; }

    }
}