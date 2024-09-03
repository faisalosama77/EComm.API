using EComm.API.BusinessDomain.DTOs.RequestsDTO;
using EComm.API.BusinessDomain.DTOs.ResponsesDTOs;
using EComm.API.BusinessDomain.Interfaces.IServices;
using EComm.API.Infrastructure.Entities;
using EComm.API.Infrastructure.Implementation.Repositories;
using EComm.API.Infrastructure.Interfaces;
using EComm.API.Infrastructure.Interfaces.IRepositories;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EComm.API.BusinessDomain.Implementation.Services
{
    public class CustomerService(ICustomerRepository userRepository, IUnitOfWork unitOfWork , IPasswordHash passwordHash ) : ICustomerService
    {
        public async Task<int> Register(CustomerRequestDTO customerRequestDTO)
        {
            var customer = customerRequestDTO.Adapt<Customer>();
            customer.PasswordSalt = passwordHash.SaltPassword(customer.PasswordHash);
            await userRepository.CreateUserAsync(customer);
            var isSaved = await unitOfWork.SaveChangesAsync();
            return isSaved;
        }


        public async Task<CustomerRequestDTO> GetUserByEmail(string email)
        {
           var customer = await userRepository.GetUserByEmail(email);
            if (customer != null)
                return customer.Adapt<CustomerRequestDTO>();

            return null;
        }

        public async Task<CustomerResponseDTO> GetUserByEmailandPassword(string email, string password)
        {
            var customer = await userRepository.GetUserByEmailandPassword(email, password);
            if (customer != null)
                return customer.Adapt<CustomerResponseDTO>();
            return null;
        }
        public async Task<Customer> GetUserById(Guid id)
        {
            var customer = await userRepository.GetUserById(id);

            if (customer == null)
                return null;
            return customer;
        }
        //public async Task<bool> EmailValidationAsync(string email)
        //{
        //    Regex regexEmail = new Regex
        //        ("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", RegexOptions.IgnoreCase);
        //    await Task.CompletedTask;
        //    return regexEmail.IsMatch(email);

        //}

    }
}
