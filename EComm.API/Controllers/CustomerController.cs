using Microsoft.AspNetCore.Mvc;
using EComm.API.BusinessDomain.Interfaces.IServices;
using EComm.API.Views;
using EComm.API.BusinessDomain.DTOs;
using Mapster;
using EComm.API.RunTime.Classes;
using BC = BCrypt.Net.BCrypt;
using EComm.API.View_Models;
namespace EComm.API.Controllers
{
    [Route("api/Customer")]
    public class CustomerController(ICustomerService customerService /*IJwtTokenGenerator jwtTokenGenerator*/) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<BaseResponse> PostUser([FromBody] CustomerRequestVM CustomerVM)
        {
            //if (await customerService.EmailValidationAsync(CustomerVM.Email)==true)
            //{
            if (ModelState.IsValid)
            {
                //CustomerVM.PasswordHash
                var customerDTO = CustomerVM.Adapt<CustomerDTO>();
                    string PasswordHash = BC.HashPassword(customerDTO.PasswordHash);
                    customerDTO.PasswordHash = PasswordHash;
                    var isSaved = await customerService.Register(customerDTO);
                var customerDataDto = await customerService.GetUserByEmail(customerDTO.Email);
                var customerDataVM = customerDataDto.Adapt<CustomerResponseVM>();
                    if (isSaved == 0)
                        return new ErrorResponse() { StatusCode = 400, Message = "BadRequest", Error = "Customer Can't Be Saved" };
                return new SuccessResponse<CustomerResponseVM>() { StatusCode = 200, Message = "User Registered Successfully", Data = customerDataVM };   //token
            }
            return new ErrorResponse() {StatusCode=400 , Message= "BadRequest" , Error= "Invalid Data" };
        }
        [HttpPost("Login")]
        public async Task<BaseResponse> LogUser([FromBody] LoginRequestVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var customerDto = await customerService.GetUserByEmail(loginVM.Email);
                if (customerDto == null)
                    return new ErrorResponse() { StatusCode = 400, Message = "BadRequest", Error = "Email Doesn't Exist" };
                if (BC.Verify(loginVM.PasswordHash, customerDto.PasswordHash)==true)
                {
                   // var token = await jwtTokenGenerator.GenerateJwtToken( customerDto.Email , customerDto.IsAdmin ? "Admin" : "User");
                    var customerDto2 = await customerService.GetUserByEmailandPassword(loginVM.Email, customerDto.PasswordHash);
                    if (customerDto2 == null)
                        return new ErrorResponse() { StatusCode = 400, Message = "BadRequest", Error = "Password Is Wrong" };
                    var customerVM = customerDto2.Adapt<LoginResponseVM>();
                    return new SuccessResponse<LoginResponseVM>() { StatusCode = 200, Message = "User Logged Successfully", Data = customerVM };   //token
                }
            }
            return new ErrorResponse() { StatusCode = 400, Message = "BadRequest", Error = "Invalid Data" };
        }
    }
}
