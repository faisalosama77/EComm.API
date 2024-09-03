using EComm.API.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.BusinessDomain.DTOs
{
    public class OrderRequestDTO : OrderBaseDTO
    {
        public List<OrderItemRequestDTO> OrderItem { get; set; }
    }
}
