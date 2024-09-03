using System.ComponentModel.DataAnnotations;

namespace EComm.API.ViewModels.BaseVMs
{
    public abstract class OrderBaseVM
    {
        [Required]
        public Guid CustomerId { get; set; }
    }
}
