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

                List<GradeData> listComponentCategory = listGrade.Select(x => new GradeData { _Component = x._Component, _CategoryID = x._CategoryID, _isActiveComponent = x._isActiveComponent } ).DistinctBy(x => x._Component).ToList();

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

                int avgAssignmentScore = Convert.ToInt32(Math.Round(listScore.Where(x => x._CategoryID == "ASG" && x._isActiveComponent == 1).Select(x => x._Score ).Average()));
                int avgQuizScore = Convert.ToInt32(Math.Round(listScore.Where(x => x._CategoryID == "QUZ" && x._isActiveComponent == 1).Select(x => x._Score).Average()));
                int avgMidScore = Convert.ToInt32(Math.Round(listScore.Where(x => x._CategoryID == "MID" && x._isActiveComponent == 1).Select(x => x._Score).Average()));
                int avgFinalScore = Convert.ToInt32(Math.Round(listScore.Where(x => x._CategoryID == "FIN" && x._isActiveComponent == 1).Select(x => x._Score).Average()));

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
                lblTotalScore.Text = totalScore.ToString();
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
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                Response.Redirect(Request.RawUrl);
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
    }
}