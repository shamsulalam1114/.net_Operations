using Auth.Validations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Auth.DTOs
{
    public class RegDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(10, MinimumLength =4)]
        [UniqueUName]
        public string Username { get; set; }
        [Required]
        [StringLength(8)]
        public string Password { get; set; }
        [Required]
        [StringLength(8)]
        [PasswordMatch]
        public string ConfPassword { get; set; }
        public int Type { get; set; }

    }
}
