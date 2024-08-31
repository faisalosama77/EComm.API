using EComm.API.BusinessDomain.DTOs;
using EComm.API.BusinessDomain.Interfaces.IServices;
using EComm.API.Infrastructure.Entities;
using EComm.API.Infrastructure.Implementation.Repositories;
using EComm.API.Infrastructure.Interfaces.IRepositories;
using Mapster;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.BusinessDomain.Implementation.Services
{
    public class OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork  , IProductService productService) : IOrderService
    {
        public async Task AddOrderAsync(OrderDTO orderDTO)
        {
            var amountt = await AmountCalcAsync(orderDTO.OrderItem);
            var AddedOrder = orderDTO.Adapt<Order>();
            AddedOrder.Amount = amountt;
            AddedOrder.Tax = 0.14f;
            AddedOrder.TotalAmount = TotalPrice(AddedOrder.Amount , AddedOrder.Tax);// Round
            await orderRepository.CreateOrderAsync(AddedOrder);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(Guid id)
        {
            var deletedOrder = await orderRepository.GetOrderByIdAsync(id);
            deletedOrder.IsDeleted = true;
             await orderRepository.DeleteOrderAsync(deletedOrder);
             await unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderDTO?>> GetCustomerWithOrdersAsync(Guid customerId)
        {
            var customerOrders = await orderRepository.GetCustomerWithOrders(customerId);
            var customerOrdersDto = customerOrders.Adapt<List<OrderDTO>>();
            if (customerOrdersDto == null)
                return null;
            return customerOrdersDto;
        }

        public async Task<OrderDTO?> GetOrderByIdAsync(Guid id)
        {
            var order = await orderRepository.GetOrderByIdAsync(id);
            if (order != null)
                return order.Adapt<OrderDTO>(); 
            return null;
        }

        public async Task<IEnumerable<OrderDTO?>> ListAllOrdersAsync()
        {
            var orders = await orderRepository.GetAllOrdersAsync();
            await unitOfWork.SaveChangesAsync();
            if (orders is null)
                return null;
            var orderDto = orders.Adapt<List<OrderDTO>>();
            
            return orderDto.Where(a => a.IsDeleted == false);
        }
        public async Task<double> AmountCalcAsync(List<OrderItemDTO> orderItems)
        {
            double totalCost = 0.0;
            var cost = 0.0;
            foreach (var item in orderItems)
            {
                var product = await productService.GetProductByIdAsync(item.ProductId);
                product.Quantity = product.Quantity - item.Quantity;
                await productService.EditProductAsync(product, item.ProductId);
                cost = product.Amount * item.Quantity;
                item.Cost = cost;
                totalCost = totalCost + cost;
            }
            return totalCost;
        }
        public double TotalPrice(double amount, float tax)
        {
            return amount * (1+tax);
        }


    }

}

