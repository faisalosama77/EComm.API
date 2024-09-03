using EComm.API.Infrastructure.Entities;

namespace EComm.API.View_Models
{
    public class OrderResponseVM : OrderBaseVM
    {
        public Guid Id { get; set; }
        public required List<OrderItemResponseVM> OrderItem { get; set; }
        public required double Amount { get; set; }
        public required float Tax { get; set; } //14%
        public required double TotalAmount { get; set; } //
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }


    }
}
