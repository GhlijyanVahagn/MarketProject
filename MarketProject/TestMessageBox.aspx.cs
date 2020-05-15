using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MarketProject
{
    public partial class TestMessageBox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnInvokeMessageBox_Click(object sender, EventArgs e)
        {
            //MessageBox messageBox = new MessageBox();
            //messageBox.MessageTitle = "Information";
            //messageBox.MessageText = "Hello everyone, I am an Asp.net MessageBox. Please put your message here and click the following button to close me.";
            //Literal1.Text = messageBox.Show(this);
        }

        protected void btnInvokeConfirm_Click(object sender, EventArgs e)
        {
            //string title = "Confirm";
            //string text = @"Hello everyone, I am an Asp.net MessageBox. You can set MessageBox.SuccessEvent and MessageBox.FailedEvent and Click Yes(OK) or No(Cancel) buttons for calling them. The Methods must be a WebMethod because client-side application will call web services.";
            //MessageBox messageBox = new MessageBox(text, title, MessageBox.MessageBoxIcons.Question, MessageBox.MessageBoxButtons.OKCancel, MessageBox.MessageBoxStyle.StyleA);
            //messageBox.SuccessEvent.Add("OkClick");
            //messageBox.SuccessEvent.Add("OkClick");
            //messageBox.FailedEvent.Add("CancalClick");
            //Literal1.Text = messageBox.Show(this);
        }

        [WebMethod]
        public static string OkClick(object sender, EventArgs e)
        {
            return "You have clicked Ok button";
        }

        [WebMethod]
        public static string CancalClick(object sender, EventArgs e)
        {
            return "You have clicked Cancel button.";
        }
    }
}