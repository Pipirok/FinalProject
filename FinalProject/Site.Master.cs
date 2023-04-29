using FinalProject.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                HttpContext.Current.Response.Redirect("~/Login.aspx");
            }
            LblUsername.Text = UsersDAL.GetUserByUsername(Session["username"].ToString()).FullName;
            LblUsername2.Text = "Logged as " + Session["username"].ToString();
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            HttpContext.Current.Response.Redirect("~/Login.aspx");
        }
    }
}