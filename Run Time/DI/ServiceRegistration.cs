using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Run_Time.DI
{
    public static class ServiceRegistration
    {
        public static void AddMyServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure settings
            services.Configure<DBSettings>(configuration.GetSection("ConnectionStrings"));

            // Register DbContext with the connection string from configuration
            services.AddDbContext<AppDbContext>((serviceProvider, options) =>
            {
                var dbSettings = serviceProvider.GetRequiredService<IOptions<DatabaseSettings>>().Value;
                options.UseSqlServer(dbSettings.ConnectionString);
            });

            // Register other services
            services.AddTransient<IMyService, MyService>();
        }
    }
}
