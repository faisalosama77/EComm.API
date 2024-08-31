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
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly DbSet<OrderItems> _orderItems;
        public OrderItemRepository(AppDbContext context)
        {
            _orderItems = context.OrderItems;

        }
        public async Task CreateOrderItemAsync(OrderItems orderItem)
        {
            _orderItems.Add(orderItem);
            await Task.CompletedTask;
        }

        public async Task DeleteOrderItemAsync(OrderItems orderItem)
        {
            _orderItems.Update(orderItem);
            await Task.CompletedTask;
        }
        public async Task<OrderItems?> GetOrderItemByIdAsync(Guid id)
        {
            return await _orderItems.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
