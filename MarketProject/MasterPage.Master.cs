using MarketManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbModel;
namespace MarketProject
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        private void Logout()
        {
            Session["LoginName"] = null;
            TreeView1.Visible = false;
            lblLogout.Visible = false;


        }

    
    }
}