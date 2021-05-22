using BusinessFacade;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sinau.View.Teacher
{
    public partial class Schedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sessionUserID = Session["UserID"].ToString();

            try
            {
                List<ScheduleData> listSchedule = new ScheduleSystem().GetTeacherScheduleDataByID(sessionUserID);

                if (listSchedule != null)
                {
                    List<ScheduleData> listScheduleMonday = listSchedule.Where(p => p._DayID == "Day1").ToList();
                    if (listScheduleMonday.Count != 0)
                    {
                        rptScheduleMonday.DataSource = listScheduleMonday;
                        rptScheduleMonday.DataBind();
                    }
                    else
                    {
                        noScheduleDay1.Attributes["class"] += " active";
                    }

                    List<ScheduleData> listScheduleTuesday = listSchedule.Where(p => p._DayID == "Day2").ToList();
                    if (listScheduleTuesday.Count != 0)
                    {
                        rptScheduleTuesday.DataSource = listScheduleTuesday;
                        rptScheduleTuesday.DataBind();
                    }
                    else
                    {
                        noScheduleDay2.Attributes["class"] += " active";
                    }

                    List<ScheduleData> listScheduleWednesday = listSchedule.Where(p => p._DayID == "Day3").ToList();
                    if (listScheduleWednesday.Count != 0)
                    {
                        rptScheduleWednesday.DataSource = listScheduleWednesday;
                        rptScheduleWednesday.DataBind();
                    }
                    else
                    {
                        noScheduleDay3.Attributes["class"] += " active";
                    }

                    List<ScheduleData> listScheduleThursday = listSchedule.Where(p => p._DayID == "Day4").ToList();
                    if (listScheduleThursday.Count != 0)
                    {
                        rptScheduleThursday.DataSource = listScheduleThursday;
                        rptScheduleThursday.DataBind();
                    }
                    else
                    {
                        noScheduleDay4.Attributes["class"] += " active";
                    }

                    List<ScheduleData> listScheduleFriday = listSchedule.Where(p => p._DayID == "Day5").ToList();
                    if (listScheduleFriday.Count != 0)
                    {
                        rptScheduleFriday.DataSource = listScheduleFriday;
                        rptScheduleFriday.DataBind();
                    }
                    else
                    {
                        noScheduleDay5.Attributes["class"] += " active";
                    }

                    List<ScheduleData> listScheduleSaturday = listSchedule.Where(p => p._DayID == "Day6").ToList();
                    if (listScheduleSaturday.Count != 0)
                    {
                        rptScheduleSaturday.DataSource = listScheduleSaturday;
                        rptScheduleSaturday.DataBind();
                    }
                    else
                    {
                        noScheduleDay6.Attributes["class"] += " active";
                    }
                }


            }
            catch (Exception ex)
            {

            }
        }
    }
}