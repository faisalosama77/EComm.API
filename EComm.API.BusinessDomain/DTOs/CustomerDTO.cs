using EComm.API.BusinessDomain.Implementation.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.BusinessDomain.DTOs
{
    public class CustomerDTO
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
        [PasswordRuless]
        public string PasswordHash { get; set; }
        public string Status { get; set; }
        public bool IsAdmin { get; set; }


    }
}
