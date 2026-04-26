using Auth.EF;
using System.ComponentModel.DataAnnotations;

namespace Auth.Validations
{
    public class UniqueUName : ValidationAttribute
    {
       
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var db =(AuthBSp26Context) validationContext.GetService(typeof(AuthBSp26Context));

            var data = (from u in db.Users where u.Username.Equals(value.ToString())
                       select u).SingleOrDefault();
            if (data == null) {
                return ValidationResult.Success;
            }

            return new ValidationResult("Username Exists");
        }
    }
}
