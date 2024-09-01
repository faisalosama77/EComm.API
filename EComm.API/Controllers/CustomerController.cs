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
using EComm.API.RunTime.Classes;
using BC = BCrypt.Net.BCrypt;
using Microsoft.AspNetCore.Authorization;
using EComm.API.Infrastructure.Interfaces;
namespace EComm.API.Controllers
{
    [Route("api/Customer")]
    public class CustomerController(ICustomerService customerService , IJwtTokenGenerator jwtTokenGenerator ,IPasswordHash passwordHash) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<BaseResponse> PostUser([FromBody] CustomerVM CustomerVM)
        {
            //if (await customerService.EmailValidationAsync(CustomerVM.Email)==true)
            //{
            if (ModelState.IsValid)
            {
                //CustomerVM.PasswordHash
                    string PasswordHash = await passwordHash.HashPassword(CustomerVM.PasswordHash);
                    var customerDTO = CustomerVM.Adapt<CustomerDTO>();
                    customerDTO.PasswordHash = PasswordHash;
                    var isSaved = await customerService.Register(customerDTO);
                    if (isSaved == 0)
                        return new ErrorResponse() { StatusCode = 400, Message = "BadRequest", Error = "Customer Can't Be Saved" };
                    return new BaseResponse() { StatusCode = 200, Message = "Customer Added Succeessfully" };
            }
            return new ErrorResponse() {StatusCode=400 , Message= "BadRequest" , Error= "Invalid Data" };
        }
        [HttpPost("Login")]
        public async Task<BaseResponse> LogUser([FromBody] LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var customerDto = await customerService.GetUserByEmail(loginVM.Email);
                
                if (customerDto == null)
                    return new ErrorResponse() { StatusCode = 400, Message = "BadRequest", Error = "Email Doesn't Exist" };
                if (await passwordHash.Verify(loginVM.PasswordSalt, customerDto.PasswordHash)==true)
                {
                    var token = await jwtTokenGenerator.GenerateJwtToken( customerDto.Email , customerDto.IsAdmin ? "Admin" : "User");
                    var customerDto2 = await customerService.GetUserByEmailandPassword(loginVM.Email, customerDto.PasswordHash);
                    if (customerDto2 == null)
                        return new ErrorResponse() { StatusCode = 400, Message = "BadRequest", Error = "Password Is Wrong" };
                    var customerDB = customerDto2.Adapt<Customer>();
                    return new SuccessResponse<string>() { StatusCode = 200, Message = "User Logged Successfully", Data = token }; //Ok($"{AllProducts} 
                }
            }
            return new ErrorResponse() { StatusCode = 400, Message = "BadRequest", Error = "Invalid Data" };
        }
    }
}
