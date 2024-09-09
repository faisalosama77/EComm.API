using EComm.API.BusinessDomain.Implementation.Services;
using EComm.API.BusinessDomain.Interfaces.IServices;
using EComm.API.Infrastructure.DbContexts;
using EComm.API.Infrastructure.Implementation;
using EComm.API.Infrastructure.Implementation.Repositories;
using EComm.API.Infrastructure.Interfaces;
using EComm.API.Infrastructure.Interfaces.IRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
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

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });



            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy =>
                {
                    policy.RequireRole("Admin");
                });
            }); // [Authorize(Policy = "AdminOnly")]  [Authorize(Roles = "Admin")]

            //services.AddIdentity<Customer, IdentityRole>()
            //         .AddEntityFrameworkStores<AppDbContext>()
            //         .AddDefaultTokenProviders();

            services.Configure<ApiBehaviorOptions>(options =>options.SuppressConsumesConstraintForFormFileParameters = true);
            services.AddScoped<ICustomerRepository, CustomerSqlRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductRepository, ProductSqlRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderRepository, OrderSqlRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IDbSeeder, DbSeeder>();
            services.AddScoped<IPasswordHash, PasswordHash>();






        }
        public static void AppConfig(IApplicationBuilder applicationBuilder)
        {

            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<IDbSeeder>();
                seeder.CheckDB();
                var migrator = scope.ServiceProvider.GetRequiredService<IDbMigrator>();
                migrator.MigrateDatabase();
            }
        }

    }
}
