using FinalProject.lib;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject.Admin
{
    public partial class Services : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            FillListView();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(((LinkButton)sender).CommandArgument);
            ServicesDAL.DeleteService(ID);
            FillListView();
        }

        protected void LVServices_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (LVServices.FindControl("LVServicesDataPager") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            FillListView();
        }

        protected void FillListView()
        {
            LVServices.DataSource = ServicesDAL.GetAllServices();
            LVServices.DataBind();
        }
    }
}