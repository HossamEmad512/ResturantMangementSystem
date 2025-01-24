using System.ComponentModel.DataAnnotations;

namespace Resturant.Management.System.APIs.DTOs
{
    public class RegistarDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]

        public string DisplayName { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [MinLength(8 , ErrorMessage ="Password must greater than 8 character")]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
