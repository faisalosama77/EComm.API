using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EComm.API.BusinessDomain.Implementation.Services
{
    internal class PasswordRuless : ValidationAttribute
    {
        public PasswordRuless()
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
