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

                    if (listTeacherAssignment.Count != 0)
                    {
                        validateAssignmentStatus(listTeacherAssignment);
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

                if (listTeacherAssignment.Count != 0)
                {
                    validateAssignmentStatus(listTeacherAssignment);
                    rptTeacherAssignment.DataSource = listTeacherAssignment;
                    rptTeacherAssignment.DataBind();
                }
                else
                {
                    noScheduleDiv.Visible = true;
                }
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

                if (listTeacherAssignment.Count != 0)
                {
                    validateAssignmentStatus(listTeacherAssignment);
                    rptTeacherAssignment.DataSource = listTeacherAssignment;
                    rptTeacherAssignment.DataBind();
                }
                else
                {
                    noScheduleDiv.Visible = true;
                }
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

            

            bool returnValueInsertAssignment = new AssignmentSystem().InsertAssignmentByIdClassSubject(classValue, subjectValue, academicYearID, assignmentTitleValue, assignDateValue, dueDateValue, assignmentPathValue);

            if (returnValueInsertAssignment)
            {
                Response.Redirect(Request.RawUrl);
            }
        }

        private void validateAssignmentStatus(List<AssignmentData> listAssignmentTemp)
        {
            for (int i = 0; i < listAssignmentTemp.Count; i++)
            {
                if (listAssignmentTemp[i]._StatusID == 0)
                {
                    DateTime assignDate = DateTime.ParseExact(listAssignmentTemp[i]._AssignDate, "MMM dd, yyyy", null);
                    DateTime dueDate = DateTime.ParseExact(listAssignmentTemp[i]._DueDate, "MMM dd, yyyy", null);

                    DateTime todayDate = DateTime.Now;
                    int assignDueCompare = DateTime.Compare(assignDate, dueDate);
                    int assignTodayCompare = DateTime.Compare(assignDate, todayDate);
                    int todayDueCompare = DateTime.Compare(todayDate, dueDate);

                    // DateTime.Compare return:
                    // date1 - date2
                    // < 0 − If date1 is earlier than date2
                    // 0 − If date1 is the same as date2
                    // > 0 − If date1 is later than date2

                    // waiting
                    // assigned
                    // done

                    if (todayDueCompare > 0)
                    {
                        listAssignmentTemp[i]._Status = "Done";
                    }
                    else if (assignTodayCompare <= 0 && todayDueCompare <= 0)
                    {
                        listAssignmentTemp[i]._Status = "Assigned";
                    }
                    else if (assignTodayCompare > 0)
                    {
                        listAssignmentTemp[i]._Status = "Waiting";
                    }
                }
            }
        }
    }
}