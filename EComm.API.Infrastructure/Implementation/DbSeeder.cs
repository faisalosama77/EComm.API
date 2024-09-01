using EComm.API.Infrastructure.DbContexts;
using EComm.API.Infrastructure.Entities;
using EComm.API.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.Infrastructure.Implementation
{
    public class DbSeeder(AppDbContext context , IPasswordHash passwordhashed) : IDbSeeder
    {
        private readonly DbSet<Customer> customers = context.Customers;
        public async Task CheckDB()
        {
            var intialTable = await customers.AnyAsync();
            if (!intialTable)
            {
                Customer Admin = new Customer() { Phone = "01014213216", Email = "SuperAdmin@ldc.com" ,PasswordHash = await passwordhashed.HashPassword("SuperAdmin@#$"),Status = "Active" };

                Admin.Name = "SuperAdmin";
                Admin.Address = "Maadi";
                Admin.PasswordSalt = await passwordhashed.SaltPassword(Admin.PasswordHash);
                Admin.CreatedOn = DateTime.Now;
                Admin.UpdatedOn = null;
                Admin.IsAdmin = true;
                Admin.IsDeleted = false;
                
            }
        }
    }
}
