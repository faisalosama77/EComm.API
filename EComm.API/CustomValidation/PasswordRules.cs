using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EComm.API.CustomValidation
{
    internal class PasswordRules : ValidationAttribute
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
            bool hasUpperCase = Regex.IsMatch(password, @"[A-Z]");
            bool hasLowerCase = Regex.IsMatch(password, @"[a-z]");
            bool hasDigit = Regex.IsMatch(password, @"\d");
            bool hasSpecialChar = Regex.IsMatch(password, @"[\W_]");
            bool isValidLength = password.Length >= 8;

            if (hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar && isValidLength)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}
