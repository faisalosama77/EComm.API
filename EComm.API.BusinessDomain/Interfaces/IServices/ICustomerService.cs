using EComm.API.BusinessDomain.DTOs;
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
        public Task Register(CustomerDTO userDTO);
        public Task<CustomerDTO> GetUserByEmail(string email);
        public Task<CustomerDTO> GetUserByEmailandPassword(string email, string password);
        public Task<bool> EmailValidationAsync(string email);


    }
}
