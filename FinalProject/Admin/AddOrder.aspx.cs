using FinalProject.lib;
using System;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject.Admin
{
    public partial class AddOrder : System.Web.UI.Page
    {

        protected bool IsDateCorrect = false;
        protected bool IsFirstNameCorrect = false;
        protected bool IsLastNameCorrect = false;
        protected bool IsLaundryWeightCorrect = false;

        protected bool IsSubmitEnabled = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            CBLServices.DataTextField = "DisplayName";
            CBLServices.DataSource = ServicesDAL.GetAllServices();
            CBLServices.DataBind();
        }

        protected void CalculateSubmit()
        {
            CalculateFirstName();
            CalculateLastName();
            CalculateLaundryWeight();
            CalculateOrderDate();
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

        protected void CalculateOrderDate()
        {
            try
            {

                DateTime orderDate = DateTime.Parse(TxtOrderDate.Text);
                if (orderDate < DateTime.Now)
                {
                    LblDateFlavourText.Text = "Can't choose a past date!";
                    IsDateCorrect = false;
                }
                else
                {
                    LblDateFlavourText.Text = "";
                    IsDateCorrect = true;
                }
            }
            catch
            {
                LblDateFlavourText.Text = "Can't choose a past date!";
                IsDateCorrect = false;
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
            List<DB.Service> SelectedServices = new List<DB.Service>();
            foreach (ListItem cb in CBLServices.Items)
            {
                if (cb.Selected)
                {
                    SelectedServices.Add(ServicesDAL.GetServiceByDisplayName(cb.Value));
                }
            }

            OrdersDAL.AddOrder(firstName, lastName, laundryWeight, orderDate, SelectedServices);
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