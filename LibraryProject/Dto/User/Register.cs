using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Dto.User
{
    public class Register
    {
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(50)]
        public string Password { get; set; }
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        public string Role { get; set; }
    }
}
