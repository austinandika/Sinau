using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sinau.View.Teacher
{
    public partial class Grade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            btnSubmit.CssClass = btnSubmit.CssClass.Replace("hide-button", "");
            btnEdit.CssClass += " hide-button";

            TxtScore.ReadOnly = false;
            TxtScore.CssClass += " edit-mode";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            btnSubmit.CssClass += " hide-button";
            btnEdit.CssClass = btnEdit.CssClass.Replace("hide-button", "");
            TxtScore.CssClass = TxtScore.CssClass.Replace("edit-mode", "");
        }
    }
}