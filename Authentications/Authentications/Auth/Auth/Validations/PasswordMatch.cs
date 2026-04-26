using Auth.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Auth.Validations
{
    public class PasswordMatch : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var obj = validationContext.ObjectInstance as RegDTO;
            if (obj != null && obj.Password.Equals(value.ToString())) { 
                return ValidationResult.Success;
            }

            return new ValidationResult("Confirm Password Mismatch");
        }
    }
}
