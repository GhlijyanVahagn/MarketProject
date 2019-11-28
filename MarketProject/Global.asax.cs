using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace MarketProject
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            System.Web.Routing.RouteTable.Routes.MapPageRoute("ProductRout", "Product", "~/View/AdminPanel/ProductView.aspx");
            System.Web.Routing.RouteTable.Routes.MapPageRoute("ProducerRout", "Producer", "~/View/AdminPanel/ProducerView.aspx");
            System.Web.Routing.RouteTable.Routes.MapPageRoute("UserRout", "User", "~/View/AdminPanel/NewUser.aspx");
            System.Web.Routing.RouteTable.Routes.MapPageRoute("UnitRout", "Unit", "~/View/AdminPanel/UnitView.aspx");

            System.Web.Routing.RouteTable.Routes.MapPageRoute("ProductGroupRout", "ProductGroup", "~/View/AdminPanel/ProductGroup.aspx");




        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}