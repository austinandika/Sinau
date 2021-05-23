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
                ddlClass.Items.Insert(0, new ListItem("All", "All"));

                ddlClassPopup.DataSource = classList;
                ddlClassPopup.DataTextField = "_Class";
                ddlClassPopup.DataValueField = "_ClassID";
                ddlClassPopup.DataBind();

                List<AssignmentData> subjectList = new AssignmentSystem().GetTeacherSubjectByIdAndClass(sessionUserID, ddlClass.SelectedValue ,academicYearID);
                ddlSubjectFilter.DataSource = subjectList;
                ddlSubjectFilter.DataTextField = "_Subject";
                ddlSubjectFilter.DataValueField = "_SubjectID";
                ddlSubjectFilter.DataBind();
                ddlSubjectFilter.Items.Insert(0, new ListItem("All", "All"));

                ddlSubjectPopup.DataSource = subjectList;
                ddlSubjectPopup.DataTextField = "_Subject";
                ddlSubjectPopup.DataValueField = "_SubjectID";
                ddlSubjectPopup.DataBind();

                string ddlClassValue = ddlClass.SelectedValue;
                string ddlSubjectValue = ddlSubjectFilter.SelectedValue;
                try
                {
                    List<AssignmentData> listTeacherAssignment = new AssignmentSystem().GetTeacherAssignmentByIdClassSubject(sessionUserID, ddlClassValue, ddlSubjectValue, academicYearID);

                    if(listTeacherAssignment.Count != 0)
                    {
                        rptTeacherAssignment.DataSource = listTeacherAssignment;
                        rptTeacherAssignment.DataBind();
                    }
                    else
                    {
                        noScheduleDiv.Visible = true ;
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sessionUserID = Session["UserID"].ToString();
            string sessionRole = Session["Role"].ToString();
            string academicYearID = new SettingSystem().GetUserLatestAcademicYearByIdAndRole(sessionUserID, sessionRole)._AcademicYearID;

            List<AssignmentData> subjectList = new AssignmentSystem().GetTeacherSubjectByIdAndClass(sessionUserID, ddlClass.SelectedValue, academicYearID);
            ddlSubjectFilter.DataSource = subjectList;
            ddlSubjectFilter.DataTextField = "_Subject";
            ddlSubjectFilter.DataValueField = "_SubjectID";
            ddlSubjectFilter.DataBind();
            ddlSubjectFilter.Items.Insert(0, new ListItem("All", "All"));

            string ddlClassValue = ddlClass.SelectedValue;
            string ddlSubjectValue = ddlSubjectFilter.SelectedValue;
            try
            {
                List<AssignmentData> listTeacherAssignment = new AssignmentSystem().GetTeacherAssignmentByIdClassSubject(sessionUserID, ddlClassValue, ddlSubjectValue, academicYearID);

                rptTeacherAssignment.DataSource = listTeacherAssignment;
                rptTeacherAssignment.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void ddlSubjectFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sessionUserID = Session["UserID"].ToString();
            string sessionRole = Session["Role"].ToString();
            string academicYearID = new SettingSystem().GetUserLatestAcademicYearByIdAndRole(sessionUserID, sessionRole)._AcademicYearID;

            string ddlClassValue = ddlClass.SelectedValue;
            string ddlSubjectValue = ddlSubjectFilter.SelectedValue;

            try
            {
                List<AssignmentData> listTeacherAssignment = new AssignmentSystem().GetTeacherAssignmentByIdClassSubject(sessionUserID, ddlClassValue, ddlSubjectValue, academicYearID);

                rptTeacherAssignment.DataSource = listTeacherAssignment;
                rptTeacherAssignment.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void ddlClassPopup_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sessionUserID = Session["UserID"].ToString();
            string sessionRole = Session["Role"].ToString();
            string academicYearID = new SettingSystem().GetUserLatestAcademicYearByIdAndRole(sessionUserID, sessionRole)._AcademicYearID;

            List<AssignmentData> subjectList = new AssignmentSystem().GetTeacherSubjectByIdAndClass(sessionUserID, ddlClass.SelectedValue, academicYearID);
            ddlSubjectPopup.DataSource = subjectList;
            ddlSubjectPopup.DataTextField = "_Subject";
            ddlSubjectPopup.DataValueField = "_SubjectID";
            ddlSubjectPopup.DataBind();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string sessionUserID = Session["UserID"].ToString();
            string sessionRole = Session["Role"].ToString();
            string academicYearID = new SettingSystem().GetUserLatestAcademicYearByIdAndRole(sessionUserID, sessionRole)._AcademicYearID;
            string classValue = ddlClassPopup.SelectedValue;
            string subjectValue = ddlSubjectPopup.SelectedValue;
            string assignmentTitleValue = txtAssignmentTitle.Text;
            DateTime assignDate = DateTime.ParseExact(txtAssignDate.Text, "dd/MM/yyyy", null);
            string assignDateValue = assignDate.ToString("yyyy-MM-dd");
            DateTime dueDate = DateTime.ParseExact(txtDueDate.Text, "dd/MM/yyyy", null);
            string dueDateValue = dueDate.ToString("yyyy-MM-dd");
            string assignmentPathValue = "test";

            int statusID = -1;
            int assignDueCompare = DateTime.Compare(assignDate, DateTime.Today);

            // DateTime.Compare return:
            // < 0 − If date1 is earlier than date2
            // 0 − If date1 is the same as date2
            // > 0 − If date1 is later than date2

            if (assignDueCompare > 0)
            {
                statusID = 1;   // Waiting
            }
            else if(assignDueCompare == 0)
            {
                statusID = 2;   // Assigned
            }

            bool returnValueInsertAssignment = new AssignmentSystem().InsertAssignmentByIdClassSubject(classValue, subjectValue, academicYearID, assignmentTitleValue, assignDateValue, dueDateValue, assignmentPathValue, statusID);

            if (returnValueInsertAssignment)
            {
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}