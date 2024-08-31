using System.ComponentModel.DataAnnotations;

namespace EComm.API.Views
{
    public class CustomerVM
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "The Email Address already exists")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Status { get; set; }
    }
}
