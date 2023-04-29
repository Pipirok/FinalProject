using FinalProject.DB;
using FinalProject.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = TxtUsername.Text;
            string password = TxtPassword.Text;
            if (username.Trim() != "")
            {
                User user = UsersDAL.Login(username, password);
                if (user != null)
                {
                    Session["username"] = user.UserName;
                    Session["userID"] = user.UserID;
                    HttpContext.Current.Response.Redirect("/Admin/Index.aspx");
                }
                LblFlavourText.Text = "Invalid credentials!";
                TxtUsername.Text = "";
                TxtPassword.Text = "";
            }
        }
    }
}