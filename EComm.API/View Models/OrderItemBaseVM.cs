using System.ComponentModel.DataAnnotations;

namespace EComm.API.View_Models
{
    public abstract class OrderItemBaseVM
    {
        [Required]
        public Guid ProductId { get; set; }
        public required int Quantity { get; set; }

    }
}
