using DbModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;


namespace UserIdentity
{
    public static class Login
    {
        //public static async Task<bool> CreateUser(User user)
        //{

        //    var userStore = new UserStore<IdentityUser>();
        //    var manager = new UserManager<IdentityUser>(userStore);

        //    var IdentityUser = new IdentityUser() { UserName = user.Login, Email = user.Email };
        //    IdentityResult result = await manager.CreateAsync(IdentityUser, user.Password);
        //    if (result != null && result.Succeeded)
        //        return result.Succeeded;
        //    return false;



        //}

        public static IdentityUser UserLogin(string Login, string Password)
        {
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);
            var IdentityUser = manager.Find(Login, Password);
            if (IdentityUser != null && !string.IsNullOrWhiteSpace(IdentityUser.UserName))
            {
                return IdentityUser;
            }
            return null;

        }
    }
}
