using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EComm.API.Infrastructure.DbContexts;
using EComm.API.Infrastructure.Entities;
using EComm.API.Infrastructure.Interfaces.IRepositories;
using EComm.API.Infrastructure.Implementation.Repositories;
using EComm.API.BusinessDomain.Interfaces.IServices;
using EComm.API.Views;
using EComm.API.BusinessDomain.DTOs;
using Mapster;

namespace EComm.API.Controllers
{
    [Route("api/Customer")]
    public class CustomerController(ICustomerService customerService) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<ActionResult> PostUser([FromBody] CustomerVM CustomerVM)
        {
            //if (await customerService.EmailValidationAsync(CustomerVM.Email)==true)
            //{
            if (ModelState.IsValid)
            {
                var customerDTO = CustomerVM.Adapt<CustomerDTO>();
                await customerService.Register(customerDTO);
                return Ok("Customer Added Succeessfully");
            }
         return BadRequest("Invalid Data");
        }
        [HttpPost("Login")]
        public async Task<ActionResult> LogUser([FromBody] LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var customerDto = await customerService.GetUserByEmail(loginVM.Email);
                if (customerDto == null)
                    return BadRequest("Email Doesn't Exist");
                var customerDto2 = await customerService.GetUserByEmailandPassword(loginVM.Email, loginVM.PasswordSalt);
                if (customerDto2 == null)
                    return BadRequest("Password Is Wrong");
                return Ok(customerDto);
            }
            return BadRequest("Invalid Data");
        }
    }
}
