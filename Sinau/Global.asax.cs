using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Sinau
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 45;   // Session timeout = 45 minutes
            if(Session["LoggedIn"] == null)
            {
                Response.Redirect("~/View/Login.aspx");
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            
        }

        protected void Application_AcquireRequestState(Object sender, EventArgs e)
        {
            string absolutePath = HttpContext.Current.Request.Url.AbsolutePath;

            if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                var loginSession = HttpContext.Current.Session["LoggedIn"];
                if (loginSession == null)
                {
                    if( absolutePath != "/View/Login.aspx" &&
                        absolutePath != "/View/ActivationForm.aspx" &&
                        absolutePath != "/View/SuccessfullyActivated.aspx")
                    {
                        Response.Redirect("~/View/Login.aspx");
                    }
                }
                else
                {
                    string[] pathSplit = absolutePath.Split('/');
                    if(pathSplit.Length > 3)
                    {
                        string currentRole = pathSplit[2];
                        string sessionRole = Session["Role"].ToString();

                        // check if user authenticate to visit the role or no
                        if (!sessionRole.Equals(currentRole, StringComparison.OrdinalIgnoreCase))
                        {
                            Response.Redirect("~/View/" + sessionRole + "/Dashboard.aspx");
                        }
                    }
                }
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}