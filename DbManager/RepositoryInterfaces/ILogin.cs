using DbModel;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.RepositoryInterfaces
{
    interface ILogin
    {
        Task<bool> CreateUser(User user);
        IdentityUser Authenticate(string Login, string Password);
        bool IsUserAutorized { get; set; }

    }
}
