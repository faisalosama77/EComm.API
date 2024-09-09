using EComm.API.Infrastructure.DbContexts;
using EComm.API.Infrastructure.Entities;
using EComm.API.Infrastructure.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.Infrastructure.Implementation.Repositories
{
    public class OrderSqlRepository : IOrderRepository
    {
        private readonly DbSet<Order> _orders;
        public OrderSqlRepository(AppDbContext context)
        {
            _orders = context.Orders;

        }
        public async Task CreateOrderAsync(Order order)
        {
            order.CreatedOn = DateTimeOffset.Now;
            _orders.Add(order);
            await Task.CompletedTask;
        }

        public async Task DeleteOrderAsync(Order order)
        {
            order.UpdatedOn = DateTimeOffset.Now;
            _orders.Remove(order);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orders.Where(a => a.IsDeleted == false).ToListAsync();
                //Where(o => o.CustomerId == customerId).Include(i => i.OrderItem).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetCustomerWithOrders(Guid customerId)
        {
            return await _orders.Where(o => o.CustomerId == customerId && o.IsDeleted == false)
                .Include(i => i.OrderItem).ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(Guid id)
        {
            return await _orders.FindAsync(id); // single , findAsync ahsn
        }
        public async Task UpdateOrderAsync(Order order, Guid id)
        {
            var orderById = await GetOrderByIdAsync(id);
            orderById.UpdatedOn = DateTimeOffset.Now;
            _orders.Update(orderById);
            await Task.CompletedTask;
        }
    }
}
