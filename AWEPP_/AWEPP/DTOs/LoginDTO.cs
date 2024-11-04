using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace AWEPP.DTOs
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Passaword { get; set; }
    }
}


