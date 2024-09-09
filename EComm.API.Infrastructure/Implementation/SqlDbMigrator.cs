using EComm.API.Infrastructure.DbContexts;
using EComm.API.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.Infrastructure.Implementation
{
    public class SqlDbMigrator(AppDbContext _context) : IDbMigrator
    {
        public void MigrateDatabase()
        {
            _context.Database.Migrate();
        }
    }
}
