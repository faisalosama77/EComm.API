using EComm.API.BusinessDomain.DTOs;
using EComm.API.BusinessDomain.Implementation.Services;
using EComm.API.BusinessDomain.Interfaces.IServices;
using EComm.API.Infrastructure.Entities;
using EComm.API.RunTime.Classes;
using EComm.API.View_Models;
using EComm.API.Views;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EComm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        [HttpPost("AddOrder")]
        public async Task<BaseResponse> PostOrder([FromBody] OrderRequestVM orderVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var orderDTO = orderVM.Adapt<OrderDTO>();
                    var OrderDetails = await orderService.AddOrderAsync(orderDTO);
                    return new SuccessResponse<OrderResponseDTO>() { StatusCode = 200, Message = "Order Added Successfully", Data = OrderDetails };   //token
                }
                catch (ArgumentException argumentException)
                {
                    return new ErrorResponse() { StatusCode = 400, Message = "Bad Request", Error = argumentException.Message };
                }
            }
            return new ErrorResponse() { StatusCode = 400, Message = "BadRequest", Error = "Invalid Data" };
        }

        //[HttpGet("GetAllOrders")]
        //public async Task<ActionResult<OrderDTO>> GetAllOrders()
        //{
        //    var AllOrders = await orderService.ListAllOrdersAsync();
        //    if (AllOrders == null)
        //        return NotFound("No Order yet");
        //    return Ok(AllOrders);
        //}
        [HttpGet("GetAllOrders{customerId}")]
        public async Task<BaseResponse> GetCustomerWtihOrders(Guid customerId)
        {
            if (ModelState.IsValid)
            {
                var customerWithOrders = await orderService.GetCustomerWithOrdersAsync(customerId);
                if (customerWithOrders == null)
                    return new ErrorResponse() { StatusCode = 404, Message = "Not Found", Error = "Customer Doesn't Exist" };
                var customerWithOrdersVM = customerWithOrders.Adapt<IEnumerable<OrderResponseVM>>();
                return new SuccessResponse<IEnumerable<OrderResponseVM>>() { StatusCode = 200, Message = "Products Retrieved Successfully", Data = customerWithOrdersVM }; //Ok($"{AllProducts} 
            }
            return new ErrorResponse() { StatusCode = 400, Message = "BadRequest", Error = "Invalid Data" };
        }
        [HttpDelete("DeleteOrder{id}")]
        public async Task<BaseResponse> DeleteOrder(Guid id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await orderService.DeleteOrderAsync(id);
                    return new BaseResponse() { StatusCode = 200, Message = "Order Deleted Succeessfully" };
                }
                catch (ArgumentException argumentException)
                {
                    return new ErrorResponse() { StatusCode = 400, Message = "Bad Request", Error = argumentException.Message };
                }
                catch (NullReferenceException nullReferenceException)
                {
                    return new ErrorResponse() { StatusCode = 400, Message = "Bad Request", Error = nullReferenceException.Message };
                }
            }
            return new ErrorResponse() { StatusCode = 400, Message = "BadRequest", Error = "Invalid Data" };
        }
    }
}
