using FinalProject.DB;
using FinalProject.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TxtPassword.Attributes["type"] = "password";
            TxtPasswordConfirm.Attributes["type"] = "password";
        }

        protected bool IsUsernameCorrect = false;
        protected bool IsPasswordCorrect = false;
        protected bool DoPasswordsMatch = false;
        protected bool IsFullNameCorrect = false;

        protected bool IsSubmitEnabled = false;

        protected void CalculateIsSubmitEnabled()
        {
            CheckFullname();
            CheckPasswords();
            CheckUsername();
            if (IsUsernameCorrect && IsPasswordCorrect && DoPasswordsMatch && IsFullNameCorrect)
            {
                IsSubmitEnabled = true;
                return;
            }
            IsSubmitEnabled = false;
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

        protected void CheckUsername()
        {
            string username = TxtUsername.Text;
            if (UsersDAL.GetUserByUsername(username) != null)
            {
                LblUsernameFlavourText.Text = "Username already taken!";
                IsUsernameCorrect = false;
            }
            else if (Regex.IsMatch(username, @"[^A-Za-z0-9_-]") || username.Length > 20 || username.Length < 4)
            {
                LblUsernameFlavourText.Text = "Username must be 4-20 alphanumeric letters, '_' or '-'";
                IsUsernameCorrect = false;
            }
            else
            {
                LblUsernameFlavourText.Text = "";
                IsUsernameCorrect = true;
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

            if (FullName.Length > 100 || FullName.Length < 4)
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
            User addedUser = UsersDAL.AddUser(TxtUsername.Text, TxtFullName.Text, TxtPassword.Text);
            Session["username"] = addedUser.UserName;
            Session["userID"] = addedUser.UserID;
            HttpContext.Current.Response.Redirect("/Admin/Index.aspx");
        }

        protected void TxtUsername_TextChanged(object sender, EventArgs e)
        {
            CalculateIsSubmitEnabled();
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
    }
}