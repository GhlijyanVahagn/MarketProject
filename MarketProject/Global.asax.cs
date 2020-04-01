using DbModel;
using DbModel.ViewModel;
using MarketManagment;
using MarketManagment.User;
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
        public List<ProductViewModel> ProductsViewList
        {
            get
            {
                return (List<ProductViewModel>)Session["productsView"];
            }
            set
            {
                Session["productsView"] = value;
            }
        }
        protected void Application_Start(object sender, EventArgs e)
        {
            System.Web.Routing.RouteTable.Routes.MapPageRoute("ProductRout", "Product", "~/View/AdminPanel/ProductView.aspx");
            System.Web.Routing.RouteTable.Routes.MapPageRoute("ProducerRout", "Producer", "~/View/AdminPanel/ProducerView.aspx");
            System.Web.Routing.RouteTable.Routes.MapPageRoute("UserRout", "User", "~/View/AdminPanel/NewUser.aspx");
            System.Web.Routing.RouteTable.Routes.MapPageRoute("UnitRout", "Unit", "~/View/AdminPanel/UnitView.aspx");

            System.Web.Routing.RouteTable.Routes.MapPageRoute("ProductGroupRout", "ProductGroup", "~/View/AdminPanel/ProductGroup.aspx");

            MarketMapper.RegisterAutoMapper();

#if DEBUG
            UsersManager.IsUserAutorized = true;
#endif
            if (!UsersManager.IsUserAutorized)
                Response.Redirect("~/login.aspx");
            var ip = MarketHelpers.Helpers.GetUserRealIp();
            var info = MarketHelpers.Helpers.GetUserGloabInfo(ip);
            UsersManager.Currency = info.GeopluginCurrencyCode;


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
            //string str="";
            //foreach(Exception exception in this.Context.AllErrors)
            //{
            //    str += exception.InnerException.Message + ":" + exception.Message;
            //}

            //string errorMessage = str.Replace('\n', ',');
            //Response.Redirect($"~/Error.aspx?error={errorMessage}");

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}