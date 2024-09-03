namespace EComm.API.View_Models
{
    public class OrderItemResponseVM : OrderItemBaseVM
    {
        public Guid Id { get; set; }
        public double Cost { get; set; }
    }
}
