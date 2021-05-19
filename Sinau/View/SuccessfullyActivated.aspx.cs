using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sinau.View
{
    public partial class SuccessfullyActivated : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["SuccessActivated"] == null)
            {
                Response.Redirect("~/View/Login.aspx");
            }
            else
            {
                Session.Abandon();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Login.aspx");
        }
    }
}