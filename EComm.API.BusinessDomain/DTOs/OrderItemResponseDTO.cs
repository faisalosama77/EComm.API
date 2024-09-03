using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.BusinessDomain.DTOs
{
    public class OrderItemResponseDTO : OrderItemBaseDTO
    {
        public Guid Id { get; set; }
    }
}
