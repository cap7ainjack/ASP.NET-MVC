using CarDealer.Data;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealerApp.Security
{
    public class AuthenticationManager
    {
        private static CarDealerContext context = new CarDealerContext();
        public static bool IsAuthenticated(string sessionId)
        {
            if (context.Logins.Any(login => login.SessionId == sessionId && login.IsActive))
            {
                return true;
            }

            return false;
        }

        public static void Logout(string sessioId)
        {
            Login login = context.Logins.FirstOrDefault(login1 => login1.SessionId == sessioId);
            login.IsActive = false;
            context.SaveChanges();
        }

    }
}