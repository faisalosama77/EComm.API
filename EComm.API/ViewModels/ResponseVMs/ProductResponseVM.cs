using System.ComponentModel.DataAnnotations;
using EComm.API.ViewModels.BaseVMs;

namespace EComm.API.View_Models
{
    public class ProductResponseVM : ProductBaseVM
    {
        public Guid Id { get; set; }
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
