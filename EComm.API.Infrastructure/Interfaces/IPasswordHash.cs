using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.Infrastructure.Interfaces
{
    public interface IPasswordHash
    {
        public Task<string> HashPassword(string password);
        public Task<string> SaltPassword(string saltPass);
        public Task<bool> Verify(string incomingPassword , string dbPassword);
    }
}
