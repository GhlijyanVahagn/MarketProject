using System;

using DbModel;

using MarketManagment;
namespace MarketProject.View.NewUser
{

    public partial class NewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UsersManager.IsUserAutorized)
                Response.Redirect("~/Login.aspx");

        }

     

        private async void AddNewUser()
        {
            
            var user = new User()
            {
                Email = txtEmail.Text,
                Login = txtUserName.Text,
                Password = txtPassword.Text
            };
          

            await UsersManager.CreateNewUser(user);
           
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            AddNewUser();
        }
    }
}