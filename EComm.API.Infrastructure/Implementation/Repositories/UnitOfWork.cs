using EComm.API.Infrastructure.DbContexts;
using EComm.API.Infrastructure.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.Infrastructure.Implementation.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context; 
        }
        public async Task<int> SaveChangesAsync()
        {
            var save = await _context.SaveChangesAsync();
            return save; 
        }
    }
}
