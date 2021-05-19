using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        }

        protected void btnValidate_Click(object sender, EventArgs e)
        {
            activationContainer.Style.Add("display", "block");
            btnValidate.Style.Add("display", "none");
            txtUserID.ReadOnly = true;
            txtUserID.CssClass += " read-only";
            txtActivationCode.ReadOnly = true;
            txtActivationCode.CssClass += " read-only";
        }

        protected void btnActivate_Click(object sender, EventArgs e)
        {
            Session["SuccessActivated"] = true;
            Response.Redirect("~/View/SuccessfullyActivated.aspx");
        }
    }
}