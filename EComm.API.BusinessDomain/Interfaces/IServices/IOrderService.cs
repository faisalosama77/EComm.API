﻿using EComm.API.BusinessDomain.DTOs;
using EComm.API.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.BusinessDomain.Interfaces.IServices
{
    public interface IOrderService
    {
        public Task<int> AddOrderAsync(OrderDTO orderDTO);
        public Task DeleteOrderAsync(Guid id);
        public Task<IEnumerable<OrderDTO?>> ListAllOrdersAsync();
        public Task<IEnumerable<OrderDTO?>> GetCustomerWithOrdersAsync(Guid customerId);
        public Task<OrderDTO?> GetOrderByIdAsync(Guid id);
        public Task<double> AmountCalcAsync(List<OrderItemDTO> orderItems);
        public double TotalPrice(double amount, float tax);



        // public Task AddOrderItemsAsync(Order_Items orderItem);
        //public Task DeleteOrderItemsAsync(Guid id);

    }
}
