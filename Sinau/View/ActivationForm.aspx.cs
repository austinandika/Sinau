using BusinessFacade;
using Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Sinau.View
{
    public partial class ActivationForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null)
            {
                string sessionRole = Session["Role"].ToString();

                Response.Redirect("~/View/" + sessionRole + "/Dashboard.aspx");
            }

            if (IsPostBack)
            {
            }
            
        }

        protected void btnValidate_Click(object sender, EventArgs e)
        {
            AccountData accountData = new AccountData();
            accountData._UserID = txtUserID.Text;
            accountData._ActivationCode = txtActivationCode.Text;

            errorServerContainer.Attributes.Add("class", errorServerContainer.Attributes["class"].ToString().Replace("active", ""));

            try
            {
                accountData = new AccountSystem().GetUserByIdAndActivationCode(accountData._UserID, accountData._ActivationCode);

                if (accountData != null)
                {
                    if(accountData._AccountStatusID == 1)
                    {
                        errorServerContainer.Attributes["Class"] += " active";
                        lblErrorServer.Text = "Your account has been registered, please login to your account.";
                    }
                    else if (accountData._AccountStatusID == 2)
                    {
                        txtFullName.Text = accountData._Name;
                        activationContainer.Style.Add("display", "block");
                        btnValidate.Style.Add("display", "none");
                        txtUserID.ReadOnly = true;
                        txtUserID.CssClass += " read-only";
                        txtActivationCode.ReadOnly = true;
                        txtActivationCode.CssClass += " read-only";
                    }
                }
                else
                {
                    errorServerContainer.Attributes["class"] += " active";
                    lblErrorServer.Text = "Incorrect NISN/NIGN or activation code. Please make sure you have entered the NISN/NIGN or activation code correctly.";
                }
            }
            catch (Exception ex)
            {
                errorServerContainer.Attributes["Class"] += " active";
                lblErrorServer.Text = "Incorrect NISN/NIGN or activation code. Please make sure you have entered the NISN/NIGN or activation code correctly.";
            }
        }

        protected void btnActivate_Click(object sender, EventArgs e)
        {
            bool returnValue = false;

            AccountData accountData = new AccountData();
            accountData._UserID = txtUserID.Text;
            accountData._Email = txtEmail.Text;
            accountData._Password = Encrypt(txtPassword.Text);

            errorServerContainer.Attributes.Add("class", errorServerContainer.Attributes["class"].ToString().Replace("active", ""));

            returnValue = new AccountSystem().InsertUserEmailAndPasswordById(accountData._UserID, accountData._Email, accountData._Password);

            if (returnValue)
            {
                Session["SuccessActivated"] = true;
                Response.Redirect("~/View/SuccessfullyActivated.aspx");
            }
            else
            {
                lblErrorServer.Text = "Email has been registered in the server. Please use the other email.";
            }
        }

        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
    }
}