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
            string todayDay = GetCurrentTime().DayOfWeek.ToString();
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

                List<AssignmentData> listTeacherAssignmentAssigned = null; 

                if (listStudentAssignment != null)
                {
                    listTeacherAssignmentAssigned = listStudentAssignment.Where(p => p._SubmissionStatusID != 1).ToList();  // 1 = submitted

                    // eliminated waiting status in assignment
                    listTeacherAssignmentAssigned = validateAssignmentStatus(listTeacherAssignmentAssigned);

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
                else
                {
                    noAssignment.Attributes["class"] += " active";
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected DateTime GetCurrentTime()
        {
            DateTime serverTime = DateTime.Now;
            DateTime _localTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(serverTime, TimeZoneInfo.Local.Id, "SE Asia Standard Time");
            return _localTime;
        }

        private List<AssignmentData> validateAssignmentStatus(List<AssignmentData> listAssignmentTemp)
        {
            List<AssignmentData> returnList = new List<AssignmentData>();

            for (int i = 0; i < listAssignmentTemp.Count; i++)
            {
                if (listAssignmentTemp[i]._StatusID == 0 && listAssignmentTemp[i]._SubmissionStatusID == -1)
                {
                    // listAssignmentTemp[i]._SubmissionStatusID == -1 -> haven't submitted the answer
                    listAssignmentTemp[i]._SubmissionDate = "-";

                    DateTime assignDate = DateTime.ParseExact(listAssignmentTemp[i]._AssignDate, "MMM dd, yyyy", null);
                    DateTime dueDate = DateTime.ParseExact(listAssignmentTemp[i]._DueDate, "MMM dd, yyyy", null);

                    DateTime todayDate = GetCurrentTime();
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
                        listAssignmentTemp[i]._Status = "Not-Submit";
                    }
                    else if (assignTodayCompare <= 0 && todayDueCompare <= 0)
                    {
                        listAssignmentTemp[i]._Status = "Assigned";
                        returnList.Add(listAssignmentTemp[i]);
                    }
                    else if (assignTodayCompare > 0)
                    {
                        listAssignmentTemp[i]._Status = "Waiting";
                    }
                }
                else if (listAssignmentTemp[i]._StatusID == 0 && listAssignmentTemp[i]._SubmissionStatusID != -1)
                {
                    listAssignmentTemp[i]._Status = listAssignmentTemp[i]._SubmissionStatus;
                    returnList.Add(listAssignmentTemp[i]);
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
            return returnList;
        }
    }
}