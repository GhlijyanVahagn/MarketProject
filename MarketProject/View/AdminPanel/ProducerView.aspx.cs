using MarketHelpers;
using MarketManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MarketProject.View.AdminPanel
{
    public partial class ProducerView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UsersManager.IsUserAutorized)
                Response.Redirect("~/Login.aspx");

            if (!IsPostBack)
                FillGrid();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
                return;
            ProductManager.CreateProducerAsync(
                new DbModel.Producer()
                {
                    Name = txtName.Text,
                    Country = txtCountry.Text
                });
            clearFields();
            FillGrid();
        }

        private void FillGrid()
        {
            SqlDataSource1= new SqlDataSource(Helpers.ConnectionString, "SELECT Id,Name,Country FROM Producers");
            gridProducer.DataSource = SqlDataSource1;
            gridProducer.DataBind();
        }

        private void clearFields()
        {
            txtName.Text=txtCountry.Text = "";

        }

        protected async void gridProducer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _producer;
            int.TryParse(gridProducer.Rows[e.RowIndex].Cells[1].Text, out _producer);
            var isRemoved=await ProductManager.RemoveProducerById(_producer);
            //gridProducer.DataSource = null;
            FillGrid();


            //TODO MEssage POPUP


            //string title = "Confirm";
            //string text = @"Hello everyone, I am an Asp.net MessageBox. You can set MessageBox.SuccessEvent and MessageBox.FailedEvent and Click Yes(OK) or No(Cancel) buttons for calling them. The Methods must be a WebMethod because client-side application will call web services.";
            //MessageBox messageBox = new MessageBox(text, title, MessageBox.MessageBoxIcons.Question, MessageBox.MessageBoxButtons.OKCancel, MessageBox.MessageBoxStyle.StyleB);
            //messageBox.SuccessEvent.Add("OkClick");

            //messageBox.FailedEvent.Add("CancalClick");
            //Literal1.Text = messageBox.Show(this);




        }

    protected void gridProducer_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {

         



        //    MessageBox messageBox = new MessageBox();
        //messageBox.MessageTitle = "Information";
        //messageBox.MessageText = "Hello everyone, I am an Asp.net MessageBox. Please put your message here and click the following button to close me.";
        //Literal1.Text = messageBox.Show(this);
    }

    //[WebMethod]
    //public static string OkClick(object sender, EventArgs e)
    //{
    //    return "You have clicked Ok button";
    //}

    //[WebMethod]
    //public static string CancalClick(object sender, EventArgs e)
    //{
    //    return "You have clicked Cancel button.";
    //}
    }
}