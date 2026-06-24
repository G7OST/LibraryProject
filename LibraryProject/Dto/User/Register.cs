using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Dto.User
{
    public class Register
    {
        [Required]
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
        [Required]
        public string Role { get; set; }
    }
}
