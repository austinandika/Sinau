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
    public partial class Assignment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sessionUserID = Session["UserID"].ToString();
                string sessionRole = Session["Role"].ToString();
                string academicYearID = new SettingSystem().GetUserLatestAcademicYearByIdAndRole(sessionUserID, sessionRole)._AcademicYearID;

                List<AssignmentData> classList = new AssignmentSystem().GetTeacherClassById(sessionUserID, academicYearID);
                ddlClass.DataSource = classList;
                ddlClass.DataTextField = "_Class";
                ddlClass.DataValueField = "_ClassID";
                ddlClass.DataBind();

                List<AssignmentData> subjectList = new AssignmentSystem().GetTeacherSubjectByIdAndClass(sessionUserID, ddlClass.SelectedValue ,academicYearID);
                ddlSubjectFilter.DataSource = subjectList;
                ddlSubjectFilter.DataTextField = "_SubjectID";
                ddlSubjectFilter.DataTextField = "_Subject";
                ddlSubjectFilter.DataBind();
            }
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSubjectFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}