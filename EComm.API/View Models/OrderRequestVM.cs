using EComm.API.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace EComm.API.View_Models
{
    public class OrderRequestVM
    {
        [Required]
        public Guid CustomerId { get; set; }
        public required List<OrderItemRequestVM> OrderItem { get; set; }
    }
}
