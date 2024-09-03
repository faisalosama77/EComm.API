using EComm.API.BusinessDomain.DTOs.BaseDTOs;
using EComm.API.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.BusinessDomain.DTOs.ResponsesDTOs
{
    public class OrderResponseDTO : OrderBaseDTO
    {
        public Guid Id { get; set; }
        public required List<OrderItemResponseDTO> OrderItem { get; set; }
        public required double Amount { get; set; }
        public required float Tax { get; set; } //14%
        public required double TotalAmount { get; set; } //
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
