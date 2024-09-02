using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EComm.API.CustomValidation
{
    public class PasswordRules : ValidationAttribute
    {
        public PasswordRules()
        {
            ErrorMessage = "Password must be at least 8 characters long, " +
                          "contain at least one uppercase letter, " +
                          "one lowercase letter, one digit, and one special character.";
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var password = value as string;

            if (string.IsNullOrEmpty(password))
            {
                return new ValidationResult("Password is required.");
            }
            bool validates = Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$]");
            if (validates)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}
