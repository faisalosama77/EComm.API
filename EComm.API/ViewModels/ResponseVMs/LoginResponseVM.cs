using EComm.API.ViewModels.BaseVMs;
using EComm.API.Views;

namespace EComm.API.View_Models
{
    public class LoginResponseVM : LoginBaseVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
