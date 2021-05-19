﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sinau.View
{
    public partial class Master : System.Web.UI.MasterPage
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
                if (sessionRole != "Student")
                {
                    Response.Redirect("~/View/" + sessionRole + "/Dashboard.aspx");
                }
            }
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("../Login.aspx");
        }
    }
}