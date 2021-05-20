using BusinessFacade;
using Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sinau.View.Teacher
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserData userData = new UserData();
            string sessionRole = Session["Role"].ToString();
            string sessionEmail = Session["Email"].ToString();
            string sessionUserID = Session["UserID"].ToString();

            try
            {
                userData = new UserSystem().GetUserInfoByUserID(sessionUserID, sessionRole);
                string[] splitName = userData._Name.Split(' ');
                lblGreeting.Text += splitName[0] + "!";
            }
            catch (Exception)
            {

            }
        }
    }
}