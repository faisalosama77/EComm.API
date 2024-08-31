using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.BusinessDomain.DTOs
{
    public class OrderItemDTO
    {
        [Required]
        public Guid ProductId { get; set; }
        public required int Quantity { get; set; }
        public double Cost { get; set; }

    }
}
