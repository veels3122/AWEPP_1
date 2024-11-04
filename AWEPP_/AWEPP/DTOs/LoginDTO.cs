using System.ComponentModel.DataAnnotations;

namespace AWEPP.DTOs
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; } // Cambiado de Passaword a Password
    }
}
