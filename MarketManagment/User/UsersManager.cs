using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Configuration;
using DbModel;
using UserIdentity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MarketManagment
{
    public static class UsersManager
    {

        public static bool IsUserAutorized { get; set; } = false;

        public static string Currency { get; set; }
        public static async Task<bool> CreateNewUser(User user)
        {
            return await Login.CreateUser(user);
        
        }

        public static IdentityUser IdentifyUser(string login, string password)
        {

            return Login.UserLogin(login, password);
        }

        
    }
}
