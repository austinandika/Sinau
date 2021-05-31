using BusinessFacade;
using Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreLinq;

namespace Sinau.View.Teacher
{
    public partial class Grade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sessionUserID = Session["UserID"].ToString();
            string sessionRole = Session["Role"].ToString();
            if (!IsPostBack)
            {
                List<SettingData> academicYearList = new SettingSystem().GetUserAllAcademicYearByIdAndRole(sessionUserID, sessionRole);
                ddlAcademicYear.DataSource = academicYearList;
                ddlAcademicYear.DataTextField = "_AcademicYearName";
                ddlAcademicYear.DataValueField = "_AcademicYearID";
                ddlAcademicYear.DataBind();

                string ddlAcademicYearValue = ddlAcademicYear.SelectedValue;

                List<GradeData> classList = new GradeSystem().GetTeacherClassById(sessionUserID, ddlAcademicYearValue);
                ddlClass.DataSource = classList;
                ddlClass.DataTextField = "_Class";
                ddlClass.DataValueField = "_ClassID";
                ddlClass.DataBind();

                string ddlClassValue = ddlClass.SelectedValue;

                List<GradeData> subjectList = new GradeSystem().GetTeacherSubjectByIdAndClass(sessionUserID, ddlClassValue, ddlAcademicYearValue);
                ddlSubject.DataSource = subjectList;
                ddlSubject.DataTextField = "_Subject";
                ddlSubject.DataValueField = "_SubjectID";
                ddlSubject.DataBind();

                string ddlSubjectValue = ddlSubject.SelectedValue;


                viewAllStudentGrade(ddlAcademicYearValue, ddlClassValue, ddlSubjectValue);

                // Add grade component
                string academicYearID = new SettingSystem().GetUserLatestAcademicYearByIdAndRole(sessionUserID, sessionRole)._AcademicYearID;

                List<GradeData> classListPopup = new GradeSystem().GetTeacherClassById(sessionUserID, academicYearID);
                ddlClassPopup.DataSource = classListPopup;
                ddlClassPopup.DataTextField = "_Class";
                ddlClassPopup.DataValueField = "_ClassID";
                ddlClassPopup.DataBind();

                string ddlClassValuePopup = ddlClassPopup.SelectedValue;

                List<GradeData> subjectListPopup = new GradeSystem().GetTeacherSubjectByIdAndClass(sessionUserID, ddlClassValue, academicYearID);
                ddlSubjectPopup.DataSource = subjectListPopup;
                ddlSubjectPopup.DataTextField = "_Subject";
                ddlSubjectPopup.DataValueField = "_SubjectID";
                ddlSubjectPopup.DataBind();

                string ddlSubjectValuePopup = ddlSubjectPopup.SelectedValue;

                List<GradeData> categoryListPopup = new GradeSystem().GetCategoryScorePercentage();
                ddlComponentCategory.DataSource = categoryListPopup;
                ddlComponentCategory.DataTextField = "_Category";
                ddlComponentCategory.DataValueField = "_CategoryID";
                ddlComponentCategory.DataBind();

                string ddlCategoryValuePopup = ddlComponentCategory.SelectedValue;
            }

            // if selected academic year is not the current academic year
            string ddlAcademicYearValue2 = ddlAcademicYear.SelectedValue;
            string academicYearIDLatest = new SettingSystem().GetUserLatestAcademicYearByIdAndRole(sessionUserID, sessionRole)._AcademicYearID;

            if (ddlAcademicYearValue2 != academicYearIDLatest)
            {
                btnAddComponent.Visible = false;
                btnEdit.Visible = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Control headerItem = rptGradeMain.Controls[0].Controls[0];
            bool isValidAll = true;

            //iterate inner repeater from header
            foreach (RepeaterItem categoryItem in ((Repeater)(headerItem.FindControl("rptIsActiveCategory"))).Items)
            {
                HiddenField hfComponentID = (HiddenField)categoryItem.FindControl("hfComponentID");
                CheckBox cbIsActive = (CheckBox)categoryItem.FindControl("cbIsActive");

                // extract values  
                int hfComponentIDValue = Convert.ToInt32(hfComponentID.Value);
                int isActiveComponent = -1;

                if (cbIsActive.Checked)
                {
                    isActiveComponent = 1;
                }
                else
                {
                    isActiveComponent = 0;
                }

                bool isUpdated = new GradeSystem().UpdateComponentStatus(hfComponentIDValue, isActiveComponent);

                if (isUpdated == false)
                {
                    isValidAll = false;
                }
            }

            // iterate outer repeater   
            foreach (RepeaterItem mainItem in rptGradeMain.Items)
            {

                // iterate inner repeater   
                foreach (RepeaterItem scoreItem in ((Repeater)(mainItem.FindControl("rptComponentScoreItem"))).Items)
                {
                    // get reference to controls  
                    HiddenField hfScoreID = (HiddenField)scoreItem.FindControl("hfScoreID");
                    TextBox txtScore = (TextBox)scoreItem.FindControl("txtScore");


                    // extract values  
                    int hfScoreIDValue = Convert.ToInt32(hfScoreID.Value);
                    int txtScoreValue = Convert.ToInt32(txtScore.Text.Trim());

                    bool isInserted = new GradeSystem().UpdateNewScoreInput(hfScoreIDValue, txtScoreValue);

                    if (isInserted == false)
                    {
                        isValidAll = false;
                    }
                }
            }

            if (isValidAll == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ERROR: Error to update the score. Please try again'); window.location ='Grade.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('SUCESS: Successfully update the score'); window.location ='Grade.aspx';", true);
            }

            //Response.Redirect(Request.RawUrl);
        }

        protected void ddlAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sessionUserID = Session["UserID"].ToString();
            string ddlAcademicYearValue = ddlAcademicYear.SelectedValue;

            List<GradeData> classList = new GradeSystem().GetTeacherClassById(sessionUserID, ddlAcademicYearValue);
            ddlClass.DataSource = classList;
            ddlClass.DataTextField = "_Class";
            ddlClass.DataValueField = "_ClassID";
            ddlClass.DataBind();

            string ddlClassValue = ddlClass.SelectedValue;

            List<GradeData> subjectList = new GradeSystem().GetTeacherSubjectByIdAndClass(sessionUserID, ddlClassValue, ddlAcademicYearValue);
            ddlSubject.DataSource = subjectList;
            ddlSubject.DataTextField = "_Subject";
            ddlSubject.DataValueField = "_SubjectID";
            ddlSubject.DataBind();

            string ddlSubjectValue = ddlSubject.SelectedValue;


            viewAllStudentGrade(ddlAcademicYearValue, ddlClassValue, ddlSubjectValue);
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sessionUserID = Session["UserID"].ToString();
            string ddlAcademicYearValue = ddlAcademicYear.SelectedValue;

            string ddlClassValue = ddlClass.SelectedValue;

            List<GradeData> subjectList = new GradeSystem().GetTeacherSubjectByIdAndClass(sessionUserID, ddlClassValue, ddlAcademicYearValue);
            ddlSubject.DataSource = subjectList;
            ddlSubject.DataTextField = "_Subject";
            ddlSubject.DataValueField = "_SubjectID";
            ddlSubject.DataBind();

            string ddlSubjectValue = ddlSubject.SelectedValue;


            viewAllStudentGrade(ddlAcademicYearValue, ddlClassValue, ddlSubjectValue);
        }

        protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sessionUserID = Session["UserID"].ToString();
            string ddlAcademicYearValue = ddlAcademicYear.SelectedValue;
            string ddlClassValue = ddlClass.SelectedValue;
            string ddlSubjectValue = ddlSubject.SelectedValue;
            viewAllStudentGrade(ddlAcademicYearValue, ddlClassValue, ddlSubjectValue);
        }

        protected void rptGradeMain_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            string ddlAcademicYearValue = ddlAcademicYear.SelectedValue;
            string ddlClassValue = ddlClass.SelectedValue;
            string ddlSubjectValue = ddlSubject.SelectedValue;

            List<GradeData> listGrade = new GradeSystem().GetAllStudentScoreByAcademicYearSubjectClass(ddlAcademicYearValue, ddlClassValue, ddlSubjectValue);

            if (e.Item.ItemType == ListItemType.Header)
            {
                Repeater rptComponentHeader = e.Item.FindControl("rptComponentHeader") as Repeater;

                List<GradeData> listComponentCategory = listGrade.Select(x => new GradeData { _ComponentID = x._ComponentID, _Component = x._Component, _CategoryID = x._CategoryID, _isActiveComponent = x._isActiveComponent } ).DistinctBy(x => x._Component).ToList();

                rptComponentHeader.DataSource = listComponentCategory;
                rptComponentHeader.DataBind();


                Repeater rptCategoryHeader = e.Item.FindControl("rptCategoryHeader") as Repeater;

                rptCategoryHeader.DataSource = listComponentCategory;
                rptCategoryHeader.DataBind();


                Repeater rptIsActiveCategory = e.Item.FindControl("rptIsActiveCategory") as Repeater;

                rptIsActiveCategory.DataSource = listComponentCategory;
                rptIsActiveCategory.DataBind();
            }

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptComponentScoreItem = e.Item.FindControl("rptComponentScoreItem") as Repeater;
                RepeaterItem rptGradeMain = e.Item;

                string tempNISN = (rptGradeMain.FindControl("lblNISN") as Label).Text;

                List<GradeData> listScore = listGrade.Where(x => x._NISN == tempNISN).Select(x => new GradeData {_CategoryID = x._CategoryID , _ComponentID = x._ComponentID , _ScoreID = x._ScoreID ,_Score = x._Score, _isActiveComponent = x._isActiveComponent } ).ToList();

                rptComponentScoreItem.DataSource = listScore;
                rptComponentScoreItem.DataBind();

                // average the score
                int avgAssignmentScore;
                int avgQuizScore;
                int avgMidScore;
                int avgFinalScore;

                try
                {
                    avgAssignmentScore = Convert.ToInt32(Math.Round(listScore.Where(x => x._CategoryID == "ASG" && x._isActiveComponent == 1).Select(x => x._Score).Average()));
                }
                catch(Exception ex)
                {
                    avgAssignmentScore = 0;
                }

                try
                {
                    avgQuizScore = Convert.ToInt32(Math.Round(listScore.Where(x => x._CategoryID == "QUZ" && x._isActiveComponent == 1).Select(x => x._Score).Average()));
                }
                catch (Exception ex)
                {
                    avgQuizScore = 0;
                }

                try
                {
                    avgMidScore = Convert.ToInt32(Math.Round(listScore.Where(x => x._CategoryID == "MID" && x._isActiveComponent == 1).Select(x => x._Score).Average()));
                }
                catch (Exception ex)
                {
                    avgMidScore = 0;
                }

                try
                {
                    avgFinalScore = Convert.ToInt32(Math.Round(listScore.Where(x => x._CategoryID == "FIN" && x._isActiveComponent == 1).Select(x => x._Score).Average()));
                }
                catch (Exception ex)
                {
                    avgFinalScore = 0;
                }

                Label lblTotalAssignment = (rptGradeMain.FindControl("lblTotalAssignment") as Label);
                Label lblTotalQuiz = (rptGradeMain.FindControl("lblTotalQuiz") as Label);
                Label lblTotalMidExam = (rptGradeMain.FindControl("lblTotalMidExam") as Label);
                Label lblTotalFinalExam = (rptGradeMain.FindControl("lblTotalFinalExam") as Label);

                lblTotalAssignment.Text = avgAssignmentScore.ToString();
                lblTotalQuiz.Text = avgQuizScore.ToString();
                lblTotalMidExam.Text = avgMidScore.ToString();
                lblTotalFinalExam.Text = avgFinalScore.ToString();

                // count total score
                List<GradeData> categoryPercentageList = new GradeSystem().GetCategoryScorePercentage();
                int percentageASG = categoryPercentageList.Where(x => x._CategoryID == "ASG").Select(x => x._CategoryPercentage).FirstOrDefault();
                int percentageQuiz = categoryPercentageList.Where(x => x._CategoryID == "QUZ").Select(x => x._CategoryPercentage).FirstOrDefault();
                int percentageMid = categoryPercentageList.Where(x => x._CategoryID == "MID").Select(x => x._CategoryPercentage).FirstOrDefault();
                int percentageFinal = categoryPercentageList.Where(x => x._CategoryID == "FIN").Select(x => x._CategoryPercentage).FirstOrDefault();

                int totalAssignment = Convert.ToInt32(Math.Round(avgAssignmentScore * ((float)percentageASG / 100)));
                int totalQuiz = Convert.ToInt32(Math.Round(avgQuizScore * ((float)percentageQuiz / 100)));
                int totalMid = Convert.ToInt32(Math.Round(avgMidScore * ((float)percentageMid / 100)));
                int totalFinal = Convert.ToInt32(Math.Round(avgFinalScore * ((float)percentageFinal / 100)));

                int totalScore = totalAssignment + totalQuiz + totalMid + totalFinal;

                Label lblTotalScore = (rptGradeMain.FindControl("lblTotalScore") as Label);
                Label lblMinScore = (rptGradeMain.FindControl("lblMinScore") as Label);
                int minScore = Convert.ToInt32(lblMinScore.Text);

                lblTotalScore.Text = totalScore.ToString();

                if(totalScore < minScore)
                {
                    lblTotalScore.CssClass += " not-pass";
                }
            }
        }

        protected void viewAllStudentGrade(string academicYearID, string classID, string subjectID)
        {
            List<GradeData> listGrade = new GradeSystem().GetAllStudentScoreByAcademicYearSubjectClass(academicYearID, classID, subjectID);

            List<GradeData> listStudentData = listGrade.Select(x => new GradeData { _NISN = x._NISN, _StudentName = x._StudentName, _MinScore = x._MinScore }).DistinctBy(x => x._NISN).ToList();

            rptGradeMain.DataSource = listStudentData;
            rptGradeMain.DataBind();
        }

        // Add grade component
        protected void ddlClassPopup_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sessionUserID = Session["UserID"].ToString();
            string sessionRole = Session["Role"].ToString();
            string academicYearID = new SettingSystem().GetUserLatestAcademicYearByIdAndRole(sessionUserID, sessionRole)._AcademicYearID;

            string ddlClassValue = ddlClassPopup.SelectedValue;

            List<GradeData> subjectList = new GradeSystem().GetTeacherSubjectByIdAndClass(sessionUserID, ddlClassValue, academicYearID);
            ddlSubjectPopup.DataSource = subjectList;
            ddlSubjectPopup.DataTextField = "_Subject";
            ddlSubjectPopup.DataValueField = "_SubjectID";
            ddlSubjectPopup.DataBind();

            string ddlSubjectValue = ddlSubjectPopup.SelectedValue;

            List<GradeData> categoryList = new GradeSystem().GetCategoryScorePercentage();
            ddlComponentCategory.DataSource = categoryList;
            ddlComponentCategory.DataTextField = "_Category";
            ddlComponentCategory.DataValueField = "_CategoryID";
            ddlComponentCategory.DataBind();

            string ddlCategoryValue = ddlComponentCategory.SelectedValue;
        }

        protected void ddlSubjectPopup_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sessionUserID = Session["UserID"].ToString();
            string sessionRole = Session["Role"].ToString();
            string academicYearID = new SettingSystem().GetUserLatestAcademicYearByIdAndRole(sessionUserID, sessionRole)._AcademicYearID;

            string ddlClassValue = ddlClassPopup.SelectedValue;

            string ddlSubjectValue = ddlSubjectPopup.SelectedValue;

            List<GradeData> categoryList = new GradeSystem().GetCategoryScorePercentage();
            ddlComponentCategory.DataSource = categoryList;
            ddlComponentCategory.DataTextField = "_Category";
            ddlComponentCategory.DataValueField = "_CategoryID";
            ddlComponentCategory.DataBind();

            string ddlCategoryValue = ddlComponentCategory.SelectedValue;
        }

        protected void ddlComponentCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnCreateComponent_Click(object sender, EventArgs e)
        {
            string sessionUserID = Session["UserID"].ToString();
            string sessionRole = Session["Role"].ToString();
            string academicYearID = new SettingSystem().GetUserLatestAcademicYearByIdAndRole(sessionUserID, sessionRole)._AcademicYearID;

            string ddlClassValue = ddlClassPopup.SelectedValue;
            string ddlSubjectValue = ddlSubjectPopup.SelectedValue;
            string ddlCategoryValue = ddlComponentCategory.SelectedValue;
            string txtComponentNameValue = txtComponentName.Text;

            bool isInserted = new GradeSystem().InsertGradeComponent(ddlClassValue, ddlSubjectValue, ddlCategoryValue, txtComponentNameValue);

            if (isInserted)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('SUCCESS: Success to insert new grade component'); window.location ='Grade.aspx';", true);
                //Response.Redirect(Request.RawUrl);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ERROR: Failed to add grade component. Please try again'); window.location ='Grade.aspx';", true);
                //Response.Redirect(Request.RawUrl);
            }
        }

        protected void rptIsActiveCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem rptIsActiveCategory = e.Item;
            CheckBox cbIsActive = (rptIsActiveCategory.FindControl("cbIsActive") as CheckBox);
            cbIsActive.InputAttributes["class"] = "cb-is-active";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Control headerItem = rptGradeMain.Controls[0].Controls[0];

            //iterate inner repeater from header
            foreach (RepeaterItem categoryItem in ((Repeater)(headerItem.FindControl("rptIsActiveCategory"))).Items)
            {
                CheckBox cbIsActive = (CheckBox)categoryItem.FindControl("cbIsActive");
                cbIsActive.Enabled = true;
            }

            // iterate outer repeater   
            foreach (RepeaterItem mainItem in rptGradeMain.Items)
            {

                //iterate inner repeater
                //foreach (RepeaterItem scoreItem in ((Repeater)(mainItem.FindControl("rptIsActiveCategory"))).Items)
                //{
                //    CheckBox cbIsActive = (CheckBox)scoreItem.FindControl("cbIsActive");
                //    cbIsActive.Enabled = true;
                //}

                // iterate inner repeater   
                foreach (RepeaterItem scoreItem in ((Repeater)(mainItem.FindControl("rptComponentScoreItem"))).Items)
                {
                    // get reference to controls  
                    TextBox txtScore = (TextBox)scoreItem.FindControl("txtScore");


                    txtScore.ReadOnly = false;
                    txtScore.CssClass += " edit-mode";
                    btnEdit.CssClass += " hide-button";
                    btnAddComponent.CssClass += " hide-button";
                    //btnEdit.Attributes.Add("class", "hide-button");
                    //btnAddComponent.Attributes.Add("class", "hide-button");
                    btnSubmit.CssClass = btnSubmit.CssClass.Replace("hide-button", "");
                    btnCancel.CssClass = btnSubmit.CssClass.Replace("hide-button", "");

                }

            }
        }
    }
}