
using System.Threading.Tasks;


using System.Configuration;
using UserIdentity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace MarketManagment.User
{
    
    public static  class UsersManager
    {
        public static bool IsUserAutorized { get; set; } = false;

        public static string Currency { get; set; }
        public static async Task<bool> CreateNewUser(DbModel.User user)
        {
            //return await Login.CreateUser(user);
            return false;
        }

        public static IdentityUser IdentifyUser(string login, string password)
        {

            return Login.UserLogin(login, password);
        }

        
    }
}
