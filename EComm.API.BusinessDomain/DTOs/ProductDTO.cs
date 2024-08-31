using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.BusinessDomain.DTOs
{
    public class ProductDTO
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
        public required string Type { get; set; }
        public int Quantity { get; set; }
        [Range(0.01, 99999999.99)]
        public required double Amount { get; set; }
        public bool IsDeleted { get; set; }
        public required string Status { get; set; }


    }
}
