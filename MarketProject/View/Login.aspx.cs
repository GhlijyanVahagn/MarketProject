using MarketHelpers;
using MarketManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MarketProject
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UsersManager.IsUserAutorized)
                Response.Redirect("~/Default.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var logedIn=  UsersManager.IdentifyUser(txtLogin.Text, txtPassword.Text);
        
            if (string.IsNullOrWhiteSpace(logedIn.UserName))
            {
                lblMessage.Text = "* Login or Password incorrect";
                UsersManager.IsUserAutorized = false;
                return;
            }
            else
            {
                Session[Sessions.LogedInUserName] = logedIn;

                UsersManager.IsUserAutorized = true;
                Response.Redirect("~/Default.aspx");
                Panel1.Visible = false;
            }
        }
    }
}