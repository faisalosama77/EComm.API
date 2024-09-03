using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.BusinessDomain.DTOs
{
    public abstract class LoginBaseDTO
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
