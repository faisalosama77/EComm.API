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
        public  void CheckDB()
        {
            var intialTable = customers.Any();
            if (!intialTable) 
            {
                Customer Admin = new()
                {
                    Phone = "01014213216",
                    Email = "SuperAdmin@ldc.com",
                    PasswordHash =  passwordhashed.HashPassword("SuperAdmin@#$"),
                    Status = "Active",
                    Name = "SuperAdmin",
                    Address = "Maadi"
                };
                Admin.PasswordSalt =  passwordhashed.SaltPassword(Admin.PasswordHash);
                Admin.CreatedOn = DateTime.Now;
                Admin.UpdatedOn = null;
                Admin.IsAdmin = true;
                Admin.IsDeleted = false;
                customers.Add(Admin);
                context.SaveChanges();
            }
            
        }
    }
}
