using System.ComponentModel.DataAnnotations;

namespace EComm.API.View_Models
{
    public abstract class OrderBaseVM
    {
        [Required]
        public Guid CustomerId { get; set; }
    }
}
