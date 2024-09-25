using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Model
{
    public class User
    {
        [Key]// jasdfikaji
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Username { get; set;}
    }
}
