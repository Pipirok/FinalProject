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
    public partial class Order : System.Web.UI.Page
    {
        protected bool IsDateCorrect = true;
        protected bool IsFirstNameCorrect = false;
        protected bool IsLastNameCorrect = false;
        protected bool IsLaundryWeightCorrect = false;

        protected bool IsSubmitEnabled = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            try
            {
                int OrderID = int.Parse(HttpContext.Current.Request.Params["id"]);
                DB.Order order = OrdersDAL.GetOrderByID(OrderID);
                if (order == null) throw new Exception();
                TxtFirstName.Text = order.CustomerName;
                TxtLastName.Text = order.CustomerSurname;
                TxtLaundryWeight.Text = order.LaundryWeight.ToString();
                TxtOrderDate.Text = order.OrderDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                TxtOrderID.Text = order.OrderID.ToString();

                List<OrderService> orderServices = ServicesDAL.GetOrderServices(OrderID);

                RBLOrderStatus.Items[order.OrderStatus.Value - 1].Selected = true;

                List<string> SelectedServices = new List<string>();
                foreach(OrderService service in orderServices)
                {
                    SelectedServices.Add(service.DisplayName.ToString());
                }

                CBLServices.DataTextField = "DisplayName";
                CBLServices.DataSource = ServicesDAL.GetAllServices();
                CBLServices.DataBind();

                foreach(ListItem item in CBLServices.Items)
                {
                    if (SelectedServices.Contains(item.Value)) item.Selected = true;
                }
            }
            catch
            {
                HttpContext.Current.Response.Redirect("/Admin/Services.aspx");
            }
        }

        protected void CalculateSubmit()
        {
            CalculateFirstName();
            CalculateLastName();
            CalculateLaundryWeight();
            if (!IsFirstNameCorrect || !IsLastNameCorrect || !IsDateCorrect || !IsLaundryWeightCorrect)
            {
                IsSubmitEnabled = false;
                return;
            }
            IsSubmitEnabled = true;
        }

        protected void CalculateFirstName()
        {
            string firstName = TxtFirstName.Text;
            if (firstName.Length > 50 || firstName.Length < 3)
            {
                LblFirstNameFlavourText.Text = "First name must be longer than 3 and less than 50 characters long!";
                IsFirstNameCorrect = false;
            }
            else
            {
                LblFirstNameFlavourText.Text = "";
                IsFirstNameCorrect = true;
            }
        }

        protected void CalculateLastName()
        {
            string lastName = TxtLastName.Text;
            if (lastName.Length > 50 || lastName.Length < 3)
            {
                LblLastNameFlavourText.Text = "Last name must be longer than 3 and less than 50 characters long!";
                IsLastNameCorrect = false;
            }
            else
            {
                LblLastNameFlavourText.Text = "";
                IsLastNameCorrect = true;
            }
        }


        protected void CalculateLaundryWeight()
        {
            try
            {

                int laundryWeight = int.Parse(TxtLaundryWeight.Text);
                if (laundryWeight < 1)
                {
                    LblLaundryWeightFlavourText.Text = "Weight must be at least 1 kg!";
                    IsLaundryWeightCorrect = false;
                }
                else
                {
                    LblLaundryWeightFlavourText.Text = "";
                    IsLaundryWeightCorrect = true;
                }
            }
            catch
            {
                LblLaundryWeightFlavourText.Text = "Weight must be at least 1 kg!";
                IsLaundryWeightCorrect = false;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            CalculateSubmit();
            if (!IsSubmitEnabled) return;
            string firstName = TxtFirstName.Text;
            string lastName = TxtLastName.Text;
            DateTime orderDate = DateTime.Parse(TxtOrderDate.Text);
            int laundryWeight = int.Parse(TxtLaundryWeight.Text);
            int OrderID = int.Parse(TxtOrderID.Text);
            int orderStatus = int.Parse(RBLOrderStatus.SelectedValue);
            List<DB.Service> SelectedServices = new List<DB.Service>();
            foreach (ListItem cb in CBLServices.Items)
            {
                if (cb.Selected)
                {
                    SelectedServices.Add(ServicesDAL.GetServiceByDisplayName(cb.Value));
                }
            }

            OrdersDAL.UpdateOrder(OrderID, firstName, lastName, orderStatus, laundryWeight, orderDate, SelectedServices);
            HttpContext.Current.Response.Redirect("/Admin/Orders.aspx");

        }

        protected void TxtFirstName_TextChanged(object sender, EventArgs e)
        {
            CalculateSubmit();
        }

        protected void TxtLastName_TextChanged(object sender, EventArgs e)
        {
            CalculateSubmit();
        }

        protected void TxtLaundryWeight_TextChanged(object sender, EventArgs e)
        {
            CalculateSubmit();
        }

        protected void TxtOrderDate_TextChanged(object sender, EventArgs e)
        {
            CalculateSubmit();
        }
    }
}