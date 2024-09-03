﻿using EComm.API.BusinessDomain.DTOs.RequestsDTO;
using EComm.API.BusinessDomain.DTOs.ResponsesDTOs;
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
        public async Task<OrderResponseDTO> AddOrderAsync(OrderRequestDTO orderDTO)
        {
            var amount = await AmountCalcAsync(orderDTO.OrderItem);
            var AddedOrder = orderDTO.Adapt<Order>();
            AddedOrder.Amount = amount;
            AddedOrder.Tax = 0.14f;
            AddedOrder.TotalAmount = TotalPrice(AddedOrder.Amount , AddedOrder.Tax);// Round
            await orderRepository.CreateOrderAsync(AddedOrder);
            var OrderDetails = AddedOrder.Adapt<OrderResponseDTO>();
            var result = await unitOfWork.SaveChangesAsync();
            if (result == 0)
                throw new ArgumentException("Can't Add Order");
            return OrderDetails;
        }

        public async Task DeleteOrderAsync(Guid id)
        {
            var deletedOrder = await orderRepository.GetOrderByIdAsync(id);
            if (deletedOrder == null) 
                throw new NullReferenceException("Order Doesn't Exist");
            deletedOrder.IsDeleted = true;
             await orderRepository.DeleteOrderAsync(deletedOrder);
             var isSaved = await unitOfWork.SaveChangesAsync();
             if (isSaved == 0)
                 throw new ArgumentException("Can't Delete Order");
        }

        public async Task<IEnumerable<OrderResponseDTO?>> GetCustomerWithOrdersAsync(Guid customerId)
        {
            var customerOrders = await orderRepository.GetCustomerWithOrders(customerId);
            if (customerOrders == null)
                return null;
            var customerOrdersDto = customerOrders.Adapt<List<OrderResponseDTO>>();
            
            return customerOrdersDto;
        }

        public async Task<OrderResponseDTO?> GetOrderByIdAsync(Guid id)
        {
            var order = await orderRepository.GetOrderByIdAsync(id);
            if (order != null)
                return order.Adapt<OrderResponseDTO>(); 
            return null;
        }

        public async Task<IEnumerable<OrderResponseDTO?>> ListAllOrdersAsync()
        {
            var orders = await orderRepository.GetAllOrdersAsync();
            if (orders is null)
                return null;
            var orderDto = orders.Adapt<List<OrderResponseDTO>>();
            
            return orderDto.Where(a => a.IsDeleted == false);
        }
        public async Task<double> AmountCalcAsync(List<OrderItemRequestDTO> orderItems)
        {
            double totalCost = 0.0;
            var cost = 0.0;
            foreach (var item in orderItems)
            {
                var productResponse = await productService.GetProductByIdAsync(item.ProductId);
                var product = productResponse.Adapt<ProductRequestDTO>();
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
            return Math.Round(amount * (1+tax),2);
        }


    }

}

