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
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public ICollection<OrderItem> OrderItem { get; set; } // ICollection
        public double Amount { get; set; }
        public float Tax { get; set; } //14%
        public double TotalAmount { get; set; } 
        public DateTimeOffset CreatedOn { get; set; } 
        public DateTimeOffset UpdatedOn { get; set; } 
        public bool IsDeleted { get; set; }
    }
}
