using EComm.API.BusinessDomain.DTOs.RequestsDTO;
using EComm.API.BusinessDomain.DTOs.ResponsesDTOs;
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
        public Task<OrderResponseDTO> AddOrderAsync(OrderRequestDTO orderDTO);
        public Task DeleteOrderAsync(Guid id);
        public Task<IEnumerable<OrderResponseDTO?>> ListAllOrdersAsync();
        public Task<IEnumerable<OrderResponseDTO?>> GetCustomerWithOrdersAsync(Guid customerId);
        public Task<OrderResponseDTO?> GetOrderByIdAsync(Guid id);
        public Task<double> AmountCalcAsync(List<OrderItemRequestDTO> orderItems);
        public double TotalPriceCalc(double amount, float tax);



        // public Task AddOrderItemsAsync(Order_Items orderItem);
        //public Task DeleteOrderItemsAsync(Guid id);

    }
}
