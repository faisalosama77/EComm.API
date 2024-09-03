using EComm.API.ViewModels.BaseVMs;
using System.ComponentModel.DataAnnotations;

namespace EComm.API.Views
{
    public class LoginRequestVM : LoginBaseVM
    {
        [Required]
        public string PasswordHash { get; set; }
    }
}
