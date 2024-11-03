using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Api.Models
{
    public class LoginVM
    {
        [EmailAddress]
        public required string Email { get; set; }
        [StringLength(255, MinimumLength = 8)]
        public required string Password { get; set; }
    }
}
