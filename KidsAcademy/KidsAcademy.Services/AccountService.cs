using KidsAcademy.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsAcademy.Services
{
    public class AccountService : Service
    {
        public void CreateParent(ApplicationUser user)
        {
            Parent parent = new Parent();
            ApplicationUser currentUser = this.Context.Users.Find(user.Id);
            parent.User = currentUser;
            this.Context.Parents.Add(parent);
            this.Context.SaveChanges();
        }
    }
}
