using EComm.API.Infrastructure.Entities;

namespace EComm.API.View_Models
{
    public class OrderVM
    {
        public Guid CustomerId { get; set; }
        public List<OrderItemVM> OrderItem { get; set; }
    }
}
