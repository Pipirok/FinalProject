using FinalProject.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject.Admin
{
    public partial class Orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            FillListView();
        }

        protected void FillListView()
        {
            LVOrders.DataSource = OrdersDAL.GetAllOrders();
            LVOrders.DataBind();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(((LinkButton)sender).CommandArgument);
            OrdersDAL.DeleteOrder(ID);
            FillListView();
        }

        protected void LVOrders_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (LVOrders.FindControl("LVOrdersDataPager") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            FillListView();
        }
    }
}