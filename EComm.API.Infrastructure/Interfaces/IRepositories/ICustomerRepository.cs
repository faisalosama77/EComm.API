using EComm.API.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.Infrastructure.Interfaces.IRepositories
{
    public interface ICustomerRepository
    {
        public Task CreateUserAsync(Customer user);
        public Task<Customer?> GetUserByEmail(string email);
        public Task<Customer> GetUserByEmailandPassword(string email , string password);
        public Task<Customer> GetUserById(Guid id);
    }
}
