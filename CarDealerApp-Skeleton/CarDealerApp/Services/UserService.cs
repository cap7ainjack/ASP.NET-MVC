using CarDealer.Data;
using CarDealer.Models;
using CarDealer.Models.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarDealer.Models.ViewModels;
using AutoMapper;

namespace CarDealerApp.Services
{
    public class UserService
    {
        private CarDealerContext context = new CarDealerContext();

        public void LoginUser(LoginUserBM userBM, string sessionSessionID)
        {
            if (!this.context.Logins.Any(log => log.SessionId == sessionSessionID))
            {
                this.context.Logins.Add(new Login() { SessionId = sessionSessionID });
                this.context.SaveChanges();
            }

            Login mylogin = this.context.Logins.FirstOrDefault(login => login.SessionId == sessionSessionID);
            mylogin.IsActive = true;

            User user = this.context.Users.FirstOrDefault(u => u.Username == userBM.Username && u.Password == userBM.Password);

            mylogin.User = user;
            this.context.SaveChanges();
        }

        internal void RegisterUser(RegisterUserBm userBM)
        {
            User model = Mapper.Map<RegisterUserBm, User>(userBM);
            this.context.Users.Add(model);
            this.context.SaveChanges();
        }
    }
}