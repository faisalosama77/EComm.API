using EComm.API.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.Infrastructure.Interfaces.IRepositories
{
    public interface IOrderRepository
    {
        public Task CreateOrderAsync(Order order);
        public Task<IEnumerable<Order>> GetCustomerWithOrders(Guid customerId);
        public Task DeleteOrderAsync(Order order);
        public Task<Order?> GetOrderByIdAsync(Guid id);
        public Task<IEnumerable<Order>> GetAllOrdersAsync();
        public Task UpdateOrderAsync(Order order, Guid id);
    }
}
