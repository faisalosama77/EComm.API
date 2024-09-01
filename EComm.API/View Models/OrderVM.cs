using EComm.API.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace EComm.API.View_Models
{
    public class OrderVM
    {
        [Required]
        public Guid CustomerId { get; set; }
        public required List<OrderItemVM> OrderItem { get; set; }
    }
}
