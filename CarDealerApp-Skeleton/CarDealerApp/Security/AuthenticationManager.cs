using CarDealer.Data;
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

    }
}