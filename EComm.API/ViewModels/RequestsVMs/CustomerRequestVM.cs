using EComm.API.CustomValidation;
using EComm.API.ViewModels.BaseVMs;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EComm.API.Views
{
    public class CustomerRequestVM : CustomerBaseVM
    {
        [PasswordRules]
        public string PasswordHash { get; set; }

    }
}
