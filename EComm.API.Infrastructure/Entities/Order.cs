using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.Infrastructure.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public required List<OrderItems> OrderItem { get; set; }
        public required double Amount { get; set; }
        public required float Tax { get; set; } //14%
        public required double TotalAmount { get; set; } //
        public DateTime CreatedOn { get; set; } 
        public DateTime UpdatedOn { get; set; } 
        public bool IsDeleted { get; set; }
    }
}
