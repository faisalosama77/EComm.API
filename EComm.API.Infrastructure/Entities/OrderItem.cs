using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.Infrastructure.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public required Order Order { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        public required Product Products { get; set; }
        [Required]
        public int Quantity { get; set; }
        public double Cost { get; set; }
    }
}
