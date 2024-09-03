using System.ComponentModel.DataAnnotations;

namespace EComm.API.ViewModels.BaseVMs
{
    public abstract class LoginBaseVM
    {
        [Required]
        public string Email { get; set; }
    }
}
