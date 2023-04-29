using FinalProject.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject.Admin
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DLRecentOrders.DataSource = OrdersDAL.GetRecentOrdersAndStatus();
            DLRecentOrders.DataBind();

            LblTotalOrders.Text = OrdersDAL.GetTotalOrders();
            LblCancelledOrders.Text = OrdersDAL.GetCancelledOrders();
            LblCompletedOrders.Text = OrdersDAL.GetCompletedOrders();
            LblPendingOrders.Text = OrdersDAL.GetPendingOrders();
        }
    }
}