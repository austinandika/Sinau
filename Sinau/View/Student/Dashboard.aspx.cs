using BusinessFacade;
using Common;
using Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sinau.View
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserData userData = new UserData();
            string sessionRole = Session["Role"].ToString();
            string sessionEmail = Session["Email"].ToString();
            string sessionUserID = Session["UserID"].ToString();

            // GREETING
            try
            {
                userData = new UserSystem().GetUserInfoByUserID(sessionUserID, sessionRole);
                string[] splitName = userData._Name.Split(' ');
                lblGreeting.Text = "Hello, " + splitName[0] + "!";
            }
            catch (Exception)
            {

            }

            // TODAY SCHEDULE
            string todayDay = DateTime.Today.DayOfWeek.ToString();
            try
            {
                List<ScheduleData> listSchedule = new ScheduleSystem().GetStudentScheduleDataByID(sessionUserID);
                List<ScheduleData> listScheduleToday = null;
                if (listSchedule != null)
                {
                    listScheduleToday = listSchedule.Where(p => p._DayName == todayDay).ToList();

                    if (listScheduleToday.Count != 0)
                    {
                        rptScheduleToday.DataSource = listScheduleToday;
                        rptScheduleToday.DataBind();
                    }
                    else
                    {
                        noScheduleDay.Attributes["class"] += " active";
                    }
                }
            }
            catch (Exception ex)
            {

            }


            // UPCOMING STUDENT ASSIGNMENT
            //string todayDay = DateTime.Today.DayOfWeek.ToString();
            try
            {
                string academicYearID = new SettingSystem().GetUserLatestAcademicYearByIdAndRole(sessionUserID, sessionRole)._AcademicYearID;
                List<AssignmentData> studentClassList = new AssignmentSystem().GetStudentClassById(sessionUserID, academicYearID);
                string studentClassID = studentClassList[0]._ClassID;

                List<AssignmentData> listStudentAssignment = new AssignmentSystem().GetStudentAssignmentByClassSubject(sessionUserID, studentClassID, "All", academicYearID);

                List<AssignmentData> listTeacherAssignmentAssigned = null;  // due next 7 days

                if (listStudentAssignment != null)
                {
                    listTeacherAssignmentAssigned = listStudentAssignment.Where(p => p._SubmissionStatusID != 1).ToList();  // 1 = submitted

                    if (listTeacherAssignmentAssigned.Count != 0)
                    {
                        //validateAssignmentStatus(listTeacherAssignment);
                        rptUpcomingAssignment.DataSource = listTeacherAssignmentAssigned;
                        rptUpcomingAssignment.DataBind();
                    }
                    else
                    {
                        noAssignment.Attributes["class"] += " active";
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}