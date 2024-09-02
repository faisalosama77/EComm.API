using System.ComponentModel.DataAnnotations;

namespace EComm.API.Views
{
    public class LoginRequestVM
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
    }
}
