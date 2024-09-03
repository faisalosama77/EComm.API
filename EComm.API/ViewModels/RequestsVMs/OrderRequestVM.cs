using EComm.API.Infrastructure.Entities;
using EComm.API.ViewModels.BaseVMs;
using System.ComponentModel.DataAnnotations;

namespace EComm.API.View_Models
{
    public class OrderRequestVM : OrderBaseVM
    {
        public required List<OrderItemRequestVM> OrderItem { get; set; }
    }
}
