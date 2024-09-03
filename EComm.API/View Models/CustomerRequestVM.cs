using EComm.API.CustomValidation;
using EComm.API.View_Models;
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
