using EComm.API.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace EComm.API.View_Models
{
    public class CustomerResponseVM 
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public Guid Id { get; set; }
        public bool IsAdmin { get; set; } 
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
