using FinalProject.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject.Admin
{
    public partial class AddService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string displayName = TxtDisplayName.Text;
            string fee = TxtFee.Text;
            string duration = TxtDuration.Text;

            if(displayName == "" || fee == "" || duration == "")
            {
                LblSubmitFlavourtext.Text = "Please fill in all the fields!";
                return;
            }

            if(ServicesDAL.DoesServiceExist(displayName))
            {
                LblDisplayNameFlavourText.Text = "Service already exists!";
                return;
            }

            ServicesDAL.AddService(displayName, int.Parse(fee), int.Parse(duration));
            HttpContext.Current.Response.Redirect("/Admin/Services.aspx");
        }
    }
}