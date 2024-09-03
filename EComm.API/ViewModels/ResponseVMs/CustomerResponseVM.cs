using EComm.API.CustomValidation;
using EComm.API.ViewModels.BaseVMs;
using System.ComponentModel.DataAnnotations;

namespace EComm.API.View_Models
{
    public class CustomerResponseVM : CustomerBaseVM
    {
        public Guid Id { get; set; }
        public bool IsAdmin { get; set; } 
        public DateTime? CreatedOn { get; set; } = DateTime.Now;    
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
