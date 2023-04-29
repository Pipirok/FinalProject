using FinalProject.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject.Admin
{
    public partial class Profiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            FillListView();
        }

        protected void LVUsers_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {

            (LVUsers.FindControl("LVUsersDataPager") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            FillListView();
        }

        protected void FillListView()
        {
            LVUsers.DataSource = UsersDAL.GetAllUsers();
            LVUsers.DataBind();
        }
    }
}