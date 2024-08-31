using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.Infrastructure.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(50)]
        public required string Name { get; set; }
        [MaxLength(150)]
        public string? Description { get; set; }
        public required string Type { get; set; }
        public int Quantity { get; set; }
        [Range(0.01,99999999.99)]
        public required double Amount { get; set; }
        public required string Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
