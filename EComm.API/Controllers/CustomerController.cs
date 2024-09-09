using Microsoft.AspNetCore.Mvc;
using EComm.API.BusinessDomain.Interfaces.IServices;
using EComm.API.Views;
using Mapster;
using EComm.API.RunTime.Classes;
using EComm.API.View_Models;
using Microsoft.AspNetCore.Authorization;
using EComm.API.Infrastructure.Interfaces;
using EComm.API.BusinessDomain.DTOs.RequestsDTO;
namespace EComm.API.Controllers
{
    [Route("api/Customer")]
    public class CustomerController(ICustomerService _customerService,/*IJwtTokenGenerator _jwtTokenGenerator ,*/ IPasswordHash _passwordHash) : ControllerBase
    {
        [HttpPost]
        public async Task<BaseResponse> Post([FromBody] CustomerRequestVM customerRequestVM)
        {
            if (ModelState.IsValid)
            {
                var customerRequestDTO = customerRequestVM.Adapt<CustomerRequestDTO>();
                string PasswordHash = _passwordHash.HashPassword(customerRequestDTO.PasswordHash);        //BC.HashPassword();
                    customerRequestDTO.PasswordHash = PasswordHash;
                    var isSaved = await _customerService.Register(customerRequestDTO);
                var customerDataDto = await _customerService.GetUserByEmail(customerRequestDTO.Email);
                var customerDataVM = customerDataDto.Adapt<CustomerResponseVM>();
                    if (isSaved == 0)
                        return new ErrorResponse() { StatusCode = 400, Message = "BadRequest", Error = "User Can't Be Saved" };
                return new SuccessResponse<CustomerResponseVM>() { StatusCode = 200, Message = "User Registered Successfully", Data = customerDataVM };   //token
            }
            return new ErrorResponse() {StatusCode=400 , Message= "BadRequest" , Error= "Invalid Data" };
        }
        [HttpPost("Login")]
        public async Task<BaseResponse> LogUser([FromBody] LoginRequestVM loginRequestVM)
        {
            if (ModelState.IsValid)
            {
                var customerRequestDto = await _customerService.GetUserByEmail(loginRequestVM.Email);
                if (customerRequestDto == null)
                    return new ErrorResponse() { StatusCode = 400, Message = "BadRequest", Error = "Email Doesn't Exist" };
                if (_passwordHash.Verify(loginRequestVM.PasswordHash, customerRequestDto.PasswordHash) ==true)
                {
                    //var token = await jwtTokenGenerator.GenerateJwtToken( customerDto.Email , customerDto.IsAdmin ? "Admin" : "User");
                    var customerDataDto = await _customerService.GetUserByEmailandPassword(loginRequestVM.Email, customerRequestDto.PasswordHash);
                    if (customerDataDto == null)
                        return new ErrorResponse() { StatusCode = 400, Message = "BadRequest", Error = "Password Is Wrong" };
                    var customerDataVM = customerDataDto.Adapt<LoginResponseVM>();
                    return new SuccessResponse<LoginResponseVM>() { StatusCode = 200, Message = "User Logged Successfully", Data = customerDataVM };   //  customerVM Token
                }
            }
            return new ErrorResponse() { StatusCode = 400, Message = "BadRequest", Error = "Invalid Data" };
        }

        //BC.Verify()
    }
}
