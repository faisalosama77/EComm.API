using EComm.API.View_Models;
using System.ComponentModel.DataAnnotations;

namespace EComm.API.Views
{
    public class LoginRequestVM : LoginBaseVM
    {
        [Required]
        public string PasswordHash { get; set; }
    }
}
