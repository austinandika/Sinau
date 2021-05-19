using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sinau
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] == null)
            {
                Response.Redirect("~/View/Login.aspx");
            }
            else if (Session["LoggedIn"] != null)
            {
                string sessionRole = Session["Role"].ToString();
               
                Response.Redirect("~/View/" + sessionRole + "/Dashboard.aspx");
            }
        }
    }
}