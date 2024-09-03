using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.BusinessDomain.DTOs
{
    public abstract class OrderBaseDTO
    {
        public Guid CustomerId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
