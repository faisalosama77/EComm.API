using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EComm.API.BusinessDomain.DTOs.BaseDTOs;

namespace EComm.API.BusinessDomain.DTOs.ResponsesDTOs
{
    public class ProductResponseDTO : ProductBaseDTO
    {
        public Guid Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
