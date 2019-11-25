using MarketManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MarketProject
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
#if DEBUG
            UsersManager.IsUserAutorized = true;
#endif
            if (!UsersManager.IsUserAutorized)
                Response.Redirect("~/login.aspx");




            var ip = MarketHelpers.Helpers.GetUserRealIp();
            var info = MarketHelpers.Helpers.GetUserGloabInfo(ip);
            UsersManager.Currency = info.GeopluginCurrencyCode;

        }

        private void Logout()
        {
            Session["LoginName"] = null;
            TreeView1.Visible = false;
            lblLogout.Visible = false;


        }

    
    }
}