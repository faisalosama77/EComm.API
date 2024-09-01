using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.BusinessDomain.Interfaces.IServices
{
    public interface IJwtTokenGenerator
    {
        public Task<string> GenerateJwtToken(string email, string role);
    }
}
