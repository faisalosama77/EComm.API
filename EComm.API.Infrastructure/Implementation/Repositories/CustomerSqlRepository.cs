using EComm.API.Infrastructure.DbContexts;
using EComm.API.Infrastructure.Entities;
using EComm.API.Infrastructure.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.Infrastructure.Implementation.Repositories
{
    public class CustomerSqlRepository(AppDbContext context) : ICustomerRepository
    {
        private readonly DbSet<Customer> _customer = context.Customers;

        public async Task CreateUserAsync(Customer customer)
        {
            customer.CreatedOn = DateTime.Now;
            _customer.Add(customer);
            await Task.CompletedTask;
        }

        public async Task<Customer?> GetUserByEmail(string email)
        {
             return await _customer.SingleOrDefaultAsync(a => a.Email == email);
        }

        public async Task<Customer> GetUserByEmailandPassword(string email, string password)
            => await _customer.FirstOrDefaultAsync(a => a.Email == email && a.PasswordHash == password);
        public async Task<Customer> GetUserById(Guid id)
        {
            return await _customer.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
