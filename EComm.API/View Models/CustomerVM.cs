using EComm.API.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace EComm.API.Views
{
    public class CustomerVM
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Phone]
        [MaxLength(14)]
        public string Phone { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "The Email Address already exists")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
        [PasswordRules]
        public string PasswordHash { get; set; }
        public string Status { get; set; }
    }
}
