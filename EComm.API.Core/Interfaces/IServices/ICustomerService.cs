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
    public interface ICustomerService
    {
        public Task<int> Register(CustomerRequestDTO userDTO);
        public Task<CustomerRequestDTO> GetUserByEmail(string email);
        public Task<CustomerResponseDTO> GetUserByEmailandPassword(string email, string password);
        public Task<Customer> GetUserById(Guid id);
       // public Task<bool> EmailValidationAsync(string email);


    }
}
