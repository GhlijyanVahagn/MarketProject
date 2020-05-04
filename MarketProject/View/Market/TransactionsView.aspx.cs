using DbModel.ViewModel;
using MarketManagment.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MarketProject.View.Market
{
    public partial class Transactions : System.Web.UI.Page
    {
        TransactionManager manager;

        private DateTime DateStart1;
        //private DateTime DateEnd1;

            

        protected void Page_Load(object sender, EventArgs e)
        {
            if (manager==null)
            {
                manager = new TransactionManager();
            }
            
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            int id= Int32.Parse(e.Item.Value);
            MultiView1.ActiveViewIndex = id;

            //int i;
            //for (i = 0; i < Menu1.Items.Count - 1; i++)
            //{
            //    if (i == int.Parse(e.Item.Value))
            //    {
            //        Menu1.Items[id].Selected = true;

            //    }
            //    else
            //    {
            //        Menu1.Items[id].Selected = false;
            //    }

            //}

        }

        public IEnumerable<TransactionVieweModel> GetSaleTransactions(DateTime dateStart,DateTime dateEnd)
        {
            if (manager == null)
            {
                manager = new TransactionManager();
            }
            return manager.GetSaleTransactions(dateStart, dateEnd);
        }

        public IEnumerable<TransactionVieweModel> GetBuyTransactions(DateTime dateStart, DateTime dateEnd)
        {
            if (manager == null)
            {
                manager = new TransactionManager();
            }
            return manager.GetBuyTransactions(dateStart,dateEnd);
        }

        public IEnumerable<TransactionDetailView> GetTransactionDetails(int transactionId)
        {
            if (transactionId == -1)
                return default(IEnumerable<TransactionDetailView>);
            return manager.GetTransactionDetailViews(transactionId);
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            if (MultiView1.ActiveViewIndex == 0)
            {
                GetBuyTransactions(DateStart.SelectedDate, DateEnd.SelectedDate);
            }

            if (MultiView1.ActiveViewIndex == 1)
            {
                GetSaleTransactions(DateStart.SelectedDate, DateEnd.SelectedDate);
                GridViewSaleTransactions.DataBind();
            }
        }


        protected void GridViewBuyTransactions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var grid = sender as GridView;
            string transactionId = grid.Rows[grid.SelectedRow.RowIndex].Cells[0].Text;
        }



        protected void GridViewBuyTransactions_SelectedIndexChanged1(object sender, EventArgs e)
        {
            var grid = sender as GridView;
            string transactionIdString = grid.Rows[grid.SelectedRow.RowIndex].Cells[0].Text;
            int transactionId; 
            int.TryParse(transactionIdString, out transactionId);
            var detailViews = GetTransactionDetails(transactionId);


            GridViewDetailes.DataSource = detailViews;
            GridViewDetailes.DataBind();
        }
    }
}