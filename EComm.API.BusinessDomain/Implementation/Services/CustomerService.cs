using EComm.API.BusinessDomain.DTOs;
using EComm.API.BusinessDomain.Interfaces.IServices;
using EComm.API.Infrastructure.Entities;
using EComm.API.Infrastructure.Implementation.Repositories;
using EComm.API.Infrastructure.Interfaces.IRepositories;
using Mapster;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EComm.API.BusinessDomain.Implementation.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(ICustomerRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public  async Task Register(CustomerDTO customerDTO)
        {
                var user = customerDTO.Adapt<Customer>();
                
            await _userRepository.CreateUserAsync(user);
                await _unitOfWork.SaveChangesAsync();
            //kkloj
        }


        public async Task<CustomerDTO> GetUserByEmail(string email)
        {
           var user = await _userRepository.GetUserByEmail(email);
            await _unitOfWork.SaveChangesAsync();
            if (user != null)
                return user.Adapt<CustomerDTO>();

            return null;
        }

        public async Task<CustomerDTO> GetUserByEmailandPassword(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailandPassword(email, password);
            await _unitOfWork.SaveChangesAsync();
            if (user != null)
                return user.Adapt<CustomerDTO>();
            return null;
        }
        public async Task<bool> EmailValidationAsync(string email)
        {
            Regex regexEmail = new Regex
                ("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", RegexOptions.IgnoreCase);
            await Task.CompletedTask;
            return regexEmail.IsMatch(email);
            
        }

    }
}
