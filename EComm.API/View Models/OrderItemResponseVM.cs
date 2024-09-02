namespace EComm.API.View_Models
{
    public class OrderItemResponseVM
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }
    }
}
