using EComm.API.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.Infrastructure.Interfaces.IRepositories
{
    public interface IUnitOfWork
    {
        public Task<int> SaveChangesAsync();
    }
}
