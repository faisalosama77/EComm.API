using System.ComponentModel.DataAnnotations;

namespace EComm.API.Views
{
    public class LoginVM
    {
        public string Email { get; set; }
        public string PasswordSalt { get; set; }
    }
}
