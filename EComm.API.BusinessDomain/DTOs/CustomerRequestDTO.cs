using EComm.API.BusinessDomain.Implementation.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.BusinessDomain.DTOs
{
    public class CustomerRequestDTO : CustomerBaseDTO
    {
        public string PasswordHash { get; set; }
    }
}
