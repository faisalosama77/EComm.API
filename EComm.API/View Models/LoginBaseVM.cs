using System.ComponentModel.DataAnnotations;

namespace EComm.API.View_Models
{
    public abstract class LoginBaseVM
    {
        [Required]
        public string Email { get; set; }
    }
}
