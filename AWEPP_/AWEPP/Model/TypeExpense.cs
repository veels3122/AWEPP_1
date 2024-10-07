using System.ComponentModel.DataAnnotations;

namespace AWEPP.Model
{
    public class TypeExpense
    {
        [Key]
        public int Id { get; set; }
        public required string TypeExpenses { get; set; }

    }
}