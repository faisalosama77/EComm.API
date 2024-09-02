using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.Infrastructure.Interfaces
{
    public interface IPasswordHash
    {
        public string HashPassword(string password);
        public string SaltPassword(string saltPass);
        public bool Verify(string incomingPassword , string dbPassword);
    }
}
