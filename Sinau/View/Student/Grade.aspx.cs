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
    public partial class Grade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sessionUserID = Session["UserID"].ToString();
                string sessionRole = Session["Role"].ToString();

                List<GradeData> classList = new GradeSystem().GetStudentAllClassSemesterById(sessionUserID);
                List<int> classListGrade = null;
                List<GradeData> classListSemester = null;

                classListGrade = classList.Select(s => s._Grade).Distinct().ToList();
                ddlGrade.DataSource = classListGrade;
                ddlGrade.DataBind();

                int ddlGradeSelected = Convert.ToInt32(ddlGrade.SelectedValue);
                classListSemester = classList.Where(w => w._Grade == ddlGradeSelected).ToList();
                for (int i = 0; i < classListSemester.Count; i++)
                {
                    if(classListSemester[i]._Semester % 2 == 0)
                    {
                        classListSemester[i]._SemesterAndAcademicYear = classListSemester[i]._Semester.ToString() + " " + "(Even)" + " - " + classListSemester[i]._AcademicYear;
                    }
                    else
                    {
                        classListSemester[i]._SemesterAndAcademicYear = classListSemester[i]._Semester.ToString() + " " + "(Odd)" + " - " + classListSemester[i]._AcademicYear;
                    }

                }
               
                ddlSemester.DataSource = classListSemester;
                ddlSemester.DataTextField = "_SemesterAndAcademicYear";
                ddlSemester.DataValueField = "_AcademicYearID";
                ddlSemester.DataBind();


            }
        }

        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sessionUserID = Session["UserID"].ToString();
            string sessionRole = Session["Role"].ToString();

            List<GradeData> classList = new GradeSystem().GetStudentAllClassSemesterById(sessionUserID);
            List<GradeData> classListSemester = null;

            int ddlGradeSelected = Convert.ToInt32(ddlGrade.SelectedValue);
            classListSemester = classList.Where(w => w._Grade == ddlGradeSelected).ToList();
            for (int i = 0; i < classListSemester.Count; i++)
            {
                if (classListSemester[i]._Semester % 2 == 0)
                {
                    classListSemester[i]._SemesterAndAcademicYear = classListSemester[i]._Semester.ToString() + " " + "(Even)" + " - " + classListSemester[i]._AcademicYear;
                }
                else
                {
                    classListSemester[i]._SemesterAndAcademicYear = classListSemester[i]._Semester.ToString() + " " + "(Odd)" + " - " + classListSemester[i]._AcademicYear;
                }

            }

            ddlSemester.DataSource = classListSemester;
            ddlSemester.DataTextField = "_SemesterAndAcademicYear";
            ddlSemester.DataValueField = "_AcademicYearID";
            ddlSemester.DataBind();
        }

        protected void ddlSemester_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}