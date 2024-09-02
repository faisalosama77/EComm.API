using EComm.API.CustomValidation;
using EComm.API.View_Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EComm.API.Views
{
    public class CustomerRequestVM
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [MaxLength(14)]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$")]
        public string Email { get; set; }
        public string Status { get; set; }
        [PasswordRules]
        public string PasswordHash { get; set; }

    }
}
