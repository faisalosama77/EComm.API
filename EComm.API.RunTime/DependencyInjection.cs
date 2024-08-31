using EComm.API.BusinessDomain.Implementation.Services;
using EComm.API.BusinessDomain.Interfaces.IServices;
using EComm.API.Infrastructure.DbContexts;
using EComm.API.Infrastructure.Entities;
using EComm.API.Infrastructure.Implementation.Repositories;
using EComm.API.Infrastructure.Interfaces.IRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace EComm.API.RunTime
{

    public static class DependencyInjection
    {
        public static void AddMyServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

            //services.AddIdentity<Customer, IdentityRole>()
            //         .AddEntityFrameworkStores<AppDbContext>()
            //         .AddDefaultTokenProviders();

            services.Configure<ApiBehaviorOptions>(options =>options.SuppressConsumesConstraintForFormFileParameters = true);
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();




        }
    }
}
