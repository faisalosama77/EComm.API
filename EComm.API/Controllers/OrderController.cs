using EComm.API.BusinessDomain.DTOs;
using EComm.API.BusinessDomain.Implementation.Services;
using EComm.API.BusinessDomain.Interfaces.IServices;
using EComm.API.Infrastructure.Entities;
using EComm.API.View_Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        [HttpPost("AddOrder")]
        public async Task<ActionResult> PostOrder([FromBody] OrderVM orderVM)
        {
            if (ModelState.IsValid)
            {
                var orderDTO = orderVM.Adapt<OrderDTO>();
                await orderService.AddOrderAsync(orderDTO);
                return Ok("Order Added Successfully");
            }
            return BadRequest("InValid Data");
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
        public async Task<ActionResult<OrderDTO>> GetCustomerWtihOrders(Guid customerId)
        {
            if (ModelState.IsValid)
            {
                var customerWithOrders = await orderService.GetCustomerWithOrdersAsync(customerId);
                if (customerWithOrders == null)
                    return NotFound("Customer Doesnt Exist");
                return Ok($"{customerWithOrders} Orders Retrieved Successfully");
            }
            return BadRequest("InValidCustomerId");
        }
        [HttpDelete("DeleteOrder{id}")]
        public async Task<ActionResult> DeleteOrder(Guid id)
        {
            if (ModelState.IsValid)
            {
                await orderService.DeleteOrderAsync(id);
                return Ok("Order Deleted Successfully");
            }
            return BadRequest("InValid Order Id");
        }
    }
}
