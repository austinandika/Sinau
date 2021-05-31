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
                List<int> classlistStudentGrade = null;
                List<GradeData> classListSemester = null;

                classlistStudentGrade = classList.Select(s => s._Grade).Distinct().ToList();
                ddlGrade.DataSource = classlistStudentGrade;
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

                string ddlAcademicYearSelected = ddlSemester.SelectedValue;
                viewStudentGrade(sessionUserID, ddlAcademicYearSelected);
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


            string ddlAcademicYearSelected = ddlSemester.SelectedValue;
            viewStudentGrade(sessionUserID, ddlAcademicYearSelected);
        }

        protected void ddlSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sessionUserID = Session["UserID"].ToString();
            string ddlAcademicYearSelected = ddlSemester.SelectedValue;

            viewStudentGrade(sessionUserID, ddlAcademicYearSelected);
        }

        protected void viewStudentGrade(string sessionUserID, string ddlAcademicYearSelected)
        {
            List<GradeData> listStudentGrade = new GradeSystem().GetStudentScoreByUserIDAcademicYearID(sessionUserID, ddlAcademicYearSelected);

            // eliminate the inactive score component
            listStudentGrade = listStudentGrade.Where(x => x._isActiveComponent == 1).ToList(); // isActiveComponent == 1 is true

            List<GradeData> listTeacher = new GradeSystem().GetTeacherByClassID(listStudentGrade[0]._ClassID);

            if(listStudentGrade == null)
            {
                noGradeDiv.Visible = true;
            }
            else
            {
                int seqViewNoTemp = 1;
                string lastIndexSubjectID = "";
                for (int i = 0; i < listStudentGrade.Count; i++)
                {
                    // Add grading
                    // source: https://en.wikipedia.org/wiki/Academic_grading_in_Indonesia
                    if (listStudentGrade[i]._Score >= 85)
                    {
                        listStudentGrade[i]._GradeLetter = "A";
                    }
                    else if (listStudentGrade[i]._Score >= 75 && listStudentGrade[i]._Score < 85)
                    {
                        listStudentGrade[i]._GradeLetter = "B";
                    }
                    else if (listStudentGrade[i]._Score >= 60 && listStudentGrade[i]._Score < 75)
                    {
                        listStudentGrade[i]._GradeLetter = "C";
                    }
                    else if (listStudentGrade[i]._Score >= 50 && listStudentGrade[i]._Score < 60)
                    {
                        listStudentGrade[i]._GradeLetter = "D";
                    }
                    else if (listStudentGrade[i]._Score >= 0 && listStudentGrade[i]._Score < 50)
                    {
                        listStudentGrade[i]._GradeLetter = "E";
                    }

                    // Add teacher name
                    string currSubjectID = listStudentGrade[i]._SubjectID;
                    listStudentGrade[i]._TeacherName = listTeacher.Where(x => x._SubjectID == currSubjectID).Select(x => x._TeacherName).FirstOrDefault();

                    // Modify view

                    if (i == 0)
                    {
                        listStudentGrade[i]._seqViewNo = seqViewNoTemp.ToString();
                        seqViewNoTemp++;
                    }
                    else if (i > 0)
                    {
                        if (listStudentGrade[i - 1]._SubjectID != "")
                        {
                            lastIndexSubjectID = listStudentGrade[i - 1]._SubjectID;
                        }

                        string currIndexSubjectID = listStudentGrade[i]._SubjectID;
                        if (lastIndexSubjectID == currIndexSubjectID)
                        {
                            listStudentGrade[i]._seqViewNo = "";
                            listStudentGrade[i]._Class = "";
                            listStudentGrade[i]._SubjectID = "";
                            listStudentGrade[i]._Subject = "";
                            listStudentGrade[i]._TeacherName = "";
                        }
                        else
                        {
                            listStudentGrade[i]._seqViewNo = seqViewNoTemp.ToString();
                            seqViewNoTemp++;
                        }
                    }
                }

                rptStudentGrade.DataSource = listStudentGrade;
                rptStudentGrade.DataBind();
            }
            
        }
    }
}