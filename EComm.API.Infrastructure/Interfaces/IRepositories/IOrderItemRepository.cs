using EComm.API.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.Infrastructure.Interfaces.IRepositories
{
    public interface IOrderItemRepository
    {
        public Task CreateOrderItemAsync(OrderItems orderItem);
        //public Task UpdateOrderItemAsync(OrderItem orderItem);
        public Task DeleteOrderItemAsync(OrderItems orderItem);
        public Task<OrderItems?> GetOrderItemByIdAsync(Guid id);
        //public Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync();
    }
}
