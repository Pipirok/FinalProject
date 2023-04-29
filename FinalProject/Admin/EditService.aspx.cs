using FinalProject.DB;
using FinalProject.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject.Admin
{
    public partial class EditService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            try
            {
                int ServiceID = int.Parse(HttpContext.Current.Request.Params["id"]);
                DB.Service service = ServicesDAL.GetServiceByID(ServiceID);
                if (service == null) throw new Exception();
                TxtDisplayName.Text = service.DisplayName;
                TxtOriginalName.Text = service.DisplayName;
                TxtServiceID.Text = service.ServiceID.ToString();
                TxtFee.Text = service.Fee.ToString();
                TxtDuration.Text = service.Duration.ToString();
            }
            catch
            {
                HttpContext.Current.Response.Redirect("/Admin/Services.aspx");
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string displayName = TxtDisplayName.Text;
            string fee = TxtFee.Text;
            string duration = TxtDuration.Text;
            string originalName = TxtOriginalName.Text;
            int serviceID = int.Parse(TxtServiceID.Text);

            if (displayName == "" || fee == "" || duration == "")
            {
                LblSubmitFlavourtext.Text = "Please fill in all the fields!";
                return;
            }

            if (displayName != originalName && ServicesDAL.DoesServiceExist(displayName))
            {
                LblDisplayNameFlavourText.Text = "Service already exists!";
                return;
            }

            ServicesDAL.UpdateService(serviceID, displayName, int.Parse(fee), int.Parse(duration));
            HttpContext.Current.Response.Redirect("/Admin/Services.aspx");
        }
    }
}