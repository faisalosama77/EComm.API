using EComm.API.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.BusinessDomain.DTOs
{
    public class OrderDTO
    {
        [Required]
        public Guid CustomerId { get; set; }
        public required List<OrderItemDTO> OrderItem { get; set; }
        public required double TotalAmount { get; set; } //
        public bool IsDeleted { get; set; }

    }
}
