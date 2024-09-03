using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.BusinessDomain.DTOs
{
    public abstract class OrderItemBaseDTO
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }
    }
}
