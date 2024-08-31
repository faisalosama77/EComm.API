using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.Infrastructure.Entities
{
    public class Customer  //IdentityUser
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Phone]
        [MaxLength(14)]
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public string? PasswordSalt { get; set; }
        public required string PasswordHash { get; set; }
        public required string Status { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAdmin { get; set; } = false;

    }
}
