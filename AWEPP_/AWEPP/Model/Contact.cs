using System.ComponentModel.DataAnnotations;

namespace AWEPP.Model
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public required string Contacts { get; set; }
    }
}
