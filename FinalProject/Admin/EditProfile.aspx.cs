using FinalProject.DB;
using FinalProject.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject.Admin
{
    public partial class EditProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string UserID = Session["userID"].ToString();
                if (UserID == null) HttpContext.Current.Response.Redirect("/Admin/Index.aspx");

                User currentUser = UsersDAL.GetUserByUserID(int.Parse(UserID));
                TxtFullName.Text = currentUser.FullName;
                TxtUserID.Text = currentUser.UserID.ToString();
            }
            TxtPassword.Attributes["type"] = "password";
            TxtPasswordConfirm.Attributes["type"] = "password";
        }

        
        protected bool IsPasswordCorrect = false;
        protected bool DoPasswordsMatch = false;
        protected bool IsFullNameCorrect = false;

        protected bool IsPasswordUpdated = false;
        protected bool IsSubmitEnabled = false;

        protected void CalculateIsSubmitEnabled()
        {
            CheckFullname();
            CheckPasswords();
            CheckIfPasswordsAreEmpty();
            
            if (((IsPasswordCorrect && DoPasswordsMatch) || !IsPasswordUpdated) && IsFullNameCorrect)
            {
                IsSubmitEnabled = true;
                return;
            }
            IsSubmitEnabled = false;
        }


        protected void CheckIfPasswordsAreEmpty()
        {
            if(TxtPassword.Text == "" && TxtPasswordConfirm.Text == "")
            {
                IsPasswordUpdated = false;
                return;
            }
            IsPasswordUpdated = true;
        }
        protected void CalculateDoPasswordsMatch()
        {
            if (TxtPassword.Text == TxtPasswordConfirm.Text)
            {
                DoPasswordsMatch = true;
                LblPasswordConfirmFlavourText.Text = "";
            }
            else
            {
                DoPasswordsMatch = false;
                LblPasswordConfirmFlavourText.Text = "Passwords do not match!";
            }

        }


        protected void CheckPasswords()
        {
            string password = TxtPassword.Text;
            bool hasPasswordUppercase = Regex.IsMatch(password, @"[A-Z]");
            bool hasPasswordNumber = Regex.IsMatch(password, @"[0-9]");
            bool hasSpecialCharacter = Regex.IsMatch(password, @"[^0-9A-Za-z]");
            bool isPasswordLegalLength = password.Length > 6 && password.Length < 64;

            if (!hasPasswordNumber || !hasSpecialCharacter || !isPasswordLegalLength || !hasPasswordUppercase)
            {
                LblPasswordFlavourText.Text = "Password must be 7-63 characters, and must contain at least 1 number, capital letter and a special symbol";
                IsPasswordCorrect = false;
            }
            else
            {
                LblPasswordFlavourText.Text = "";
                IsPasswordCorrect = true;
            }

            CalculateDoPasswordsMatch();
        }

        protected void CheckFullname()
        {
            string FullName = TxtFullName.Text;

            if (FullName.Length > 50 || FullName.Length < 4)
            {
                LblFullNameFlavourText.Text = "Full name must be 4-50 characters long";
                IsFullNameCorrect = false;
            }
            else
            {
                LblFullNameFlavourText.Text = "";
                IsFullNameCorrect = true;
            }

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            CalculateIsSubmitEnabled();
            if (!IsSubmitEnabled) return;

            int UserID = int.Parse(TxtUserID.Text);
            if (IsPasswordUpdated)
            {
                UsersDAL.UpdateUser(UserID, TxtFullName.Text, TxtPassword.Text);
            }
            else
            {
                UsersDAL.UpdateUser(UserID, TxtFullName.Text);
            }
            HttpContext.Current.Response.Redirect("/Admin/Index.aspx");
        }

        protected void TxtFullName_TextChanged(object sender, EventArgs e)
        {
            CalculateIsSubmitEnabled();

        }

        protected void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            CalculateIsSubmitEnabled();

        }

        protected void TxtPasswordConfirm_TextChanged(object sender, EventArgs e)
        {
            CalculateIsSubmitEnabled();

        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}