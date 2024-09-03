using System.ComponentModel.DataAnnotations;

namespace EComm.API.View_Models
{
    public abstract class CustomerBaseVM
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
    }
}
