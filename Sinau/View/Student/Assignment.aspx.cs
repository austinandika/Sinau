using BusinessFacade;
using Common.Data;
using System;
using System.IO;
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
            if (!IsPostBack)
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
                ddlSubjectFilter.Items.Insert(0, new ListItem("All", "All"));

                string ddlClassValue = ddlClass.SelectedValue;
                string ddlSubjectValue = ddlSubjectFilter.SelectedValue;
                viewStudentAssignment(sessionUserID, ddlClassValue, ddlSubjectValue, academicYearID);
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
            ddlSubjectFilter.Items.Insert(0, new ListItem("All", "All"));

            string ddlClassValue = ddlClass.SelectedValue;
            string ddlSubjectValue = ddlSubjectFilter.SelectedValue;

            viewStudentAssignment(sessionUserID, ddlClassValue, ddlSubjectValue, academicYearID);
        }

        protected void ddlSubjectFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sessionUserID = Session["UserID"].ToString();
            string sessionRole = Session["Role"].ToString();
            string academicYearID = new SettingSystem().GetUserLatestAcademicYearByIdAndRole(sessionUserID, sessionRole)._AcademicYearID;

            string ddlClassValue = ddlClass.SelectedValue;
            string ddlSubjectValue = ddlSubjectFilter.SelectedValue;

            viewStudentAssignment(sessionUserID, ddlClassValue, ddlSubjectValue, academicYearID);
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
                        listAssignmentTemp[i]._Status = "Not-Submit";
                        returnList.Add(listAssignmentTemp[i]);
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
                else if(listAssignmentTemp[i]._StatusID == 0 && listAssignmentTemp[i]._SubmissionStatusID != -1)
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
        
        protected void viewStudentAssignment(string sessionUserID, string ddlClassValue, string ddlSubjectValue, string academicYearID)
        {
            try
            {
                List<AssignmentData> listStudentAssignment = new AssignmentSystem().GetStudentAssignmentByClassSubject(sessionUserID, ddlClassValue, ddlSubjectValue, academicYearID);

                if (listStudentAssignment.Count != 0)
                {
                    listStudentAssignment = validateAssignmentStatus(listStudentAssignment);
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

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            bool isValidFile = true;

            //Find the reference of the Repeater Item
            RepeaterItem item = (sender as Button).Parent.Parent as RepeaterItem;
            int classSubjectAssignmentID = int.Parse((item.FindControl("lblClassSubAssignID") as HiddenField).Value);
            FileUpload fuAnswerFile = item.FindControl("fuAnswerFile") as FileUpload;
            Label lblErrorAnswerFile = item.FindControl("lblErrorAnswerFile") as Label;


            var supportedTypes = new[] { "txt", "pdf", "ppt", "xls", "doc", "pptx", "xlsx", "docx", "rar", "zip", "jpg", "jpeg", "png", "wav", "mp3", "mp4", "avi", "3gp", "mkv", "mov", "flv", "csv" };
            string fileExt;
            try
            {
                fileExt = System.IO.Path.GetExtension(fuAnswerFile.PostedFile.FileName).Substring(1);
            }
            catch (Exception ex)
            {
                fileExt = "";
            }
            
            int maxFileSize = 20000;    // 20.000 kb = 20mb

            if(fuAnswerFile.HasFile == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ERROR: File is required')", true);
                isValidFile = false;
            }
            else if (!supportedTypes.Contains(fileExt))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ERROR: File type is not allowed')", true);
                isValidFile = false;
            }
            else if (fuAnswerFile.FileBytes.Length > (maxFileSize * 1024))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ERROR: File size is too big, maximum file size is 20mb')", true);
                isValidFile = false;
            }

            if (isValidFile)
            {
                string sessionUserID = Session["UserID"].ToString();
                string submissionDate = DateTime.Now.ToString("yyyy-MM-dd").ToString();

                string fileExtension = Path.GetExtension(fuAnswerFile.PostedFile.FileName);

                DateTime today = DateTime.Now;
                string fileName = today.ToString("yyyy") + today.ToString("MM") + today.ToString("dd") + today.ToString("HH") + today.ToString("mm") + today.ToString("ss") + "_" + sessionUserID + "_" + "Answer" + fileExtension;

                fuAnswerFile.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fileName);

                string filePath = "~/Uploads/" + fileName;
                string answerPathValue = filePath;

                try
                {
                    // delete last answer file
                    AssignmentData lastAnswer = new AssignmentSystem().GetAssignmentAnsFileByClassSubAssignIDAndUserID(classSubjectAssignmentID, sessionUserID);

                    string lastAnswerPath = lastAnswer._AnswerPath;
                    string lastAnswerMapPath = Server.MapPath(lastAnswerPath);
                    FileInfo file = new FileInfo(lastAnswerMapPath);
                    if(lastAnswerPath != "" && file.Exists)
                    {
                        file.Delete();
                    }

                    // insert
                    bool isInserted = new AssignmentSystem().InsertStudentAsgAnswerByClSubAsgIDAndUserID(classSubjectAssignmentID, sessionUserID, submissionDate, answerPathValue);

                    if (isInserted)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('SUCCESS: Your answer have been submitted'); window.location ='Assignment.aspx';", true);
                        //Response.Redirect(Request.RawUrl);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //lblErrorAnswerFile.Text = "Your answer failed to upload";
                }
            }
        }

        protected void btnDownloadAnswer_Click(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int classSubjectAssignmentID = int.Parse((item.FindControl("lblClassSubAssignID") as HiddenField).Value);
            string sessionUserID = Session["UserID"].ToString();

            try
            {
                AssignmentData answer = new AssignmentSystem().GetAssignmentAnsFileByClassSubAssignIDAndUserID(classSubjectAssignmentID, sessionUserID);

                string answerPath = answer._AnswerPath;

                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment;filename=" + answerPath);
                string fileMap = Server.MapPath(answerPath);
                Response.TransmitFile(fileMap);
                Response.End();
            }
            catch (Exception)
            {

            }
        }

        protected void rptStudentAssignment_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // hide download button when user haven't submitted assignment answer
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string submissionDate = (e.Item.FindControl("lblSubmissionDate") as Label).Text;
                string status = (e.Item.FindControl("lblStatus") as Label).Text;

                if (submissionDate != "-")
                {
                    e.Item.FindControl("btnDownloadAnswer").Visible = true;
                }

                string dueDateText = (e.Item.FindControl("lblDueDate") as Label).Text;
                DateTime dueDate = DateTime.ParseExact(dueDateText, "MMM dd, yyyy", null);
                DateTime todayDate = DateTime.Now;
                int todayDueCompare = DateTime.Compare(todayDate, dueDate);
                if (todayDueCompare <= 0)
                {
                    e.Item.FindControl("btnUploadAnswer").Visible = true;
                }
            }


            // hide download button when user haven't submitted assignment answer
            //if (submissionDate == "-")
            //{
            //    e.Item.FindControl("btnDownloadAnswer").Visible = false;
            //}
        }
    }
}