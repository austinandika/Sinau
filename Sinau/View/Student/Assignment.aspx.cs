using BusinessFacade;
using Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sinau.View.Student
{
    public partial class Assignmennt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sessionUserID = Session["UserID"].ToString();
            string sessionRole = Session["Role"].ToString();
            string academicYearID = new SettingSystem().GetUserLatestAcademicYearByIdAndRole(sessionUserID, sessionRole)._AcademicYearID;

            List<AssignmentData> classList = new AssignmentSystem().GetStudentClassById(sessionUserID, academicYearID);
            ddlClass.DataSource = classList;
            ddlClass.DataTextField = "_Class";
            ddlClass.DataValueField = "_ClassID";
            ddlClass.DataBind();

            List<AssignmentData> subjectList = new AssignmentSystem().GetStudentSubjectByClass(ddlClass.SelectedValue, academicYearID);
            ddlSubjectFilter.DataSource = subjectList;
            ddlSubjectFilter.DataTextField = "_Subject";
            ddlSubjectFilter.DataValueField = "_SubjectID";
            ddlSubjectFilter.DataBind();

            string ddlClassValue = ddlClass.SelectedValue;
            string ddlSubjectValue = ddlSubjectFilter.SelectedValue;
            try
            {
                List<AssignmentData> listStudentAssignment = new AssignmentSystem().GetStudentAssignmentByClassSubject(sessionUserID, ddlClassValue, ddlSubjectValue, academicYearID);

                if (listStudentAssignment.Count != 0)
                {
                    validateAssignmentStatus(listStudentAssignment);
                    rptStudentAssignment.DataSource = listStudentAssignment;
                    rptStudentAssignment.DataBind();
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

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sessionUserID = Session["UserID"].ToString();
            string sessionRole = Session["Role"].ToString();
            string academicYearID = new SettingSystem().GetUserLatestAcademicYearByIdAndRole(sessionUserID, sessionRole)._AcademicYearID;

            List<AssignmentData> subjectList = new AssignmentSystem().GetStudentSubjectByClass(ddlClass.SelectedValue, academicYearID);
            ddlSubjectFilter.DataSource = subjectList;
            ddlSubjectFilter.DataTextField = "_Subject";
            ddlSubjectFilter.DataValueField = "_SubjectID";
            ddlSubjectFilter.DataBind();

            string ddlClassValue = ddlClass.SelectedValue;
            string ddlSubjectValue = ddlSubjectFilter.SelectedValue;

            try
            {
                List<AssignmentData> listStudentAssignment = new AssignmentSystem().GetStudentAssignmentByClassSubject(sessionUserID, ddlClassValue, ddlSubjectValue, academicYearID);

                if (listStudentAssignment.Count != 0)
                {
                    validateAssignmentStatus(listStudentAssignment);
                    rptStudentAssignment.DataSource = listStudentAssignment;
                    rptStudentAssignment.DataBind();
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
                List<AssignmentData> listStudentAssignment = new AssignmentSystem().GetStudentAssignmentByClassSubject(sessionUserID, ddlClassValue, ddlSubjectValue, academicYearID);

                if (listStudentAssignment.Count != 0)
                {
                    validateAssignmentStatus(listStudentAssignment);
                    rptStudentAssignment.DataSource = listStudentAssignment;
                    rptStudentAssignment.DataBind();
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

        private void validateAssignmentStatus(List<AssignmentData> listAssignmentTemp)
        {
            for (int i = 0; i < listAssignmentTemp.Count; i++)
            {
                if (listAssignmentTemp[i]._StatusID == 0 && listAssignmentTemp[i]._SubmissionStatusID == -1)
                {
                    // listAssignmentTemp[i]._SubmissionStatusID == -1 -> haven't subitted the answer
                    listAssignmentTemp[i]._SubmissionDate = "-";

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
                        listAssignmentTemp[i]._Status = "Not-Sumbit";
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
                else if(listAssignmentTemp[i]._StatusID == 0 && listAssignmentTemp[i]._SubmissionStatusID != -1)
                {
                    listAssignmentTemp[i]._Status = listAssignmentTemp[i]._SubmissionStatus;
                }

                //if (listAssignmentTemp[i]._SubmissionStatusID == -1) // haven't submitted the answer
                //{
                //    listAssignmentTemp[i]._SubmissionDate = "-";

                //    if(listAssignmentTemp[i]._Status == "Done")
                //    {
                //        listAssignmentTemp[i]._Status = "Not-Sumbit";
                //    }
                //}
            }
        }
    }
}