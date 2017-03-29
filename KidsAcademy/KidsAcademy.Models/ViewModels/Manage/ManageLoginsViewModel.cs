using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using Microsoft.Owin.Security;
using System.Text;
using System.Threading.Tasks;

namespace KidsAcademy.Models.ViewModels.Manage
{
    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }
}
