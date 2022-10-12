using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu2Gether.BusinessLogic.ServiceModels.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
            IsFirstLogin = false;
        }

        public string AccessToken { get; set; }
        public string Id { get; set; }
        public bool IsFirstLogin { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Role { get; set; }
    }
}
