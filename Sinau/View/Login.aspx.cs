using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sinau.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.RemoveAll();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session["Email"] = "";
            Session["Role"] = "";

            // TEMPORARY FOR DEVELOPMENT
            if(txtEmail.Text == "student@gmail.com" && txtPassword.Text == "student1234"){
                Session["LoggedIn"] = true;
                Session["Email"] = txtEmail.Text;
                Session["Role"] = "Student";
                Response.Redirect("~/View/Student/Dashboard.aspx");
            }
            else if (txtEmail.Text == "teacher@gmail.com" && txtPassword.Text == "teacher1234")
            {
                Session["LoggedIn"] = true;
                Session["Email"] = txtEmail.Text;
                Session["Role"] = "Teacher";
                Response.Redirect("~/View/Teacher/Dashboard.aspx");
            }
            else
            {
                lblErrorServer.Text = "Incorrect email or password. Please make sure you have entered the email or password correctly.";
                errorServerContainer.Attributes["class"] += " active";
            }

            
        }
    }
}