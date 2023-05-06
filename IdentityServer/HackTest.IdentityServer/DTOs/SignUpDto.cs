using System.ComponentModel.DataAnnotations;

namespace HackTest.IdentityServer.DTOs
{
    public class SignUpDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required, Compare("Password", ErrorMessage = "Passwords are not matching")]
        public string CheckPassword { get; set; }
    }
}
