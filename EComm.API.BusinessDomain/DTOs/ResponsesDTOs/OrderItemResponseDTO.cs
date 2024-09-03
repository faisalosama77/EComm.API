using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EComm.API.BusinessDomain.DTOs.BaseDTOs;

namespace EComm.API.BusinessDomain.DTOs.ResponsesDTOs
{
    public class OrderItemResponseDTO : OrderItemBaseDTO
    {
        public Guid Id { get; set; }
    }
}
