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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null)
            {
                string sessionRole = Session["Role"].ToString();

                Response.Redirect("~/View/" + sessionRole + "/Dashboard.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session["Email"] = "";
            Session["UserID"] = "";
            Session["Role"] = "";

            AccountData accountData = new AccountData();
            accountData._Email = txtEmail.Text;
            accountData._Password = Encrypt(txtPassword.Text);

            errorServerContainer.Attributes.Add("class", errorServerContainer.Attributes["class"].ToString().Replace("active", ""));

            try
            {
                accountData = new AccountSystem().VerifyAccountByEmailAndPassword(accountData._Email, accountData._Password);

                if (accountData != null)
                {
                    Session["LoggedIn"] = true;
                    Session["Email"] = accountData._Email;
                    Session["UserID"] = accountData._UserID;
                    Session["Role"] = accountData._Role;
                    Response.Redirect("~/View/" + Session["Role"] + "/Dashboard.aspx");
                }
                else
                {
                    lblErrorServer.Text = "Incorrect email or password";
                    errorServerContainer.Attributes["class"] += " active";
                }
            }
            catch (Exception ex)
            {
                lblErrorServer.Text = "Incorrect email or password";
                errorServerContainer.Attributes["class"] += " active";
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