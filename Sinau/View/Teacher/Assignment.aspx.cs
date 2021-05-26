using BusinessFacade;
using Common.Data;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ionic.Zip;

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

            string fileExtension = Path.GetExtension(fuQuestionFile.PostedFile.FileName);
            DateTime today = DateTime.Now;

            string fileName = today.ToString("yyyy") + today.ToString("MM") + today.ToString("dd") + today.ToString("HH") + today.ToString("mm") + today.ToString("ss") + "_" + sessionUserID + "_" + "Assignment" + fileExtension;

            

            fuQuestionFile.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fileName);

            string filePath = "~/Uploads/" + fileName;
            string assignmentPathValue = filePath;
            

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

        protected void btnDownloadQuestion_Click(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int classSubjectAssignmentID = int.Parse((item.FindControl("lblClassSubAssignID") as HiddenField).Value);

            try
            {
                AssignmentData assignment = new AssignmentSystem().GetAssignmentFilePathByClassSubAssignID(classSubjectAssignmentID);

                string assignmentPath = assignment._AssignmentPath;

                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment;filename=" + assignmentPath);
                string fileMap = Server.MapPath(assignmentPath);
                Response.TransmitFile(fileMap);
                Response.End();
            }
            catch (Exception)
            {

            }
            
        }

        protected void btnDownloadAnswer_Click(object sender, EventArgs e)
        {
            string sessionUserID = Session["UserID"].ToString();
            string sessionRole = Session["Role"].ToString();
            string academicYearID = new SettingSystem().GetUserLatestAcademicYearByIdAndRole(sessionUserID, sessionRole)._AcademicYearID;

            //Find the reference of the Repeater Item
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int classSubjectAssignmentID = int.Parse((item.FindControl("lblClassSubAssignID") as HiddenField).Value);

            List<AssignmentData> listAssignmentAnswer = new AssignmentSystem().GetAllAssignmentAnsFileByClassSubAssignID(classSubjectAssignmentID);

            string fileName = academicYearID + "_" + listAssignmentAnswer[0]._ClassID + "_" + listAssignmentAnswer[0]._SubjectID + "_" + listAssignmentAnswer[0]._ClassSubAssignID.ToString();

            ZipFile multipleFiles = new ZipFile();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ".zip");
            Response.ContentType = "application/zip";

            for (int i = 0; i < listAssignmentAnswer.Count; i++)
            {
                if(listAssignmentAnswer[i]._AnswerPath != "")
                {
                    string filePath = Server.MapPath(listAssignmentAnswer[i]._AnswerPath);
                    multipleFiles.AddFile(filePath, string.Empty);
                }
            }

            multipleFiles.Save(Response.OutputStream);
        }

        protected void rptTeacherAssignment_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // hide download button when assignment hasn't reached the due date
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string status = (e.Item.FindControl("lblStatus") as Label).Text;

                if (status == "Done")
                {
                    e.Item.FindControl("btnDownloadAnswer").Visible = true;
                }
            }
        }
    }
}