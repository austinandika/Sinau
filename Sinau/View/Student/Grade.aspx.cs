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
            noGradeDiv.Visible = false;
            List<GradeData> listStudentGrade = new GradeSystem().GetStudentScoreByUserIDAcademicYearID(sessionUserID, ddlAcademicYearSelected);
            List<GradeData> listStudentGradeDuplicate = new List<GradeData>();

            // eliminate the inactive score component
            listStudentGrade = listStudentGrade.Where(x => x._isActiveComponent == 1).ToList(); // isActiveComponent == 1 is true


            
            if (listStudentGrade.Count == 0 || listStudentGrade == null)
            {
                rptStudentGrade.DataSource = null;
                rptStudentGrade.DataBind();
                noGradeDiv.Visible = true;
            }
            else
            {
                List<GradeData> listTeacher = new GradeSystem().GetTeacherByClassID(listStudentGrade[0]._ClassID);

                int seqViewNoTemp = 1;
                string lastIndexSubjectID = "";

                int sumAssignmentScore = 0;
                int sumQuizScore = 0;
                int sumMidScore = 0;
                int sumFinalScore = 0;

                int countAssignmentScore = 0;
                int countQuizScore = 0;
                int countMidScore = 0;
                int countFinalScore = 0;

                int avgAssignmentScore = 0;
                int avgQuizScore = 0;
                int avgMidScore = 0;
                int avgFinalScore = 0;

                List<GradeData> categoryPercentageList = new GradeSystem().GetCategoryScorePercentage();
                int percentageASG = categoryPercentageList.Where(x => x._CategoryID == "ASG").Select(x => x._CategoryPercentage).FirstOrDefault();
                int percentageQuiz = categoryPercentageList.Where(x => x._CategoryID == "QUZ").Select(x => x._CategoryPercentage).FirstOrDefault();
                int percentageMid = categoryPercentageList.Where(x => x._CategoryID == "MID").Select(x => x._CategoryPercentage).FirstOrDefault();
                int percentageFinal = categoryPercentageList.Where(x => x._CategoryID == "FIN").Select(x => x._CategoryPercentage).FirstOrDefault();

                int tempGradeListCount = listStudentGrade.Count;

                for (int i = 0; i < listStudentGrade.Count; i++)
                {
                    // Add grading
                    
                    //listStudentGrade[i]._GradeLetter = scoreGradingGenerator(listStudentGrade[i]._Score);

                    // Add teacher name
                    string currSubjectID = listStudentGrade[i]._SubjectID;
                    listStudentGrade[i]._TeacherName = listTeacher.Where(x => x._SubjectID == currSubjectID).Select(x => x._TeacherName).FirstOrDefault();

                    // Modify view

                    if (i == 0)
                    {
                        listStudentGrade[i]._seqViewNo = seqViewNoTemp.ToString();
                        seqViewNoTemp++;
                        listStudentGradeDuplicate.Add(listStudentGrade[i]);

                        if(listStudentGrade[i]._CategoryID == "ASG")
                        {
                            sumAssignmentScore += listStudentGrade[i]._Score;
                            countAssignmentScore++;
                        }
                        else if (listStudentGrade[i]._CategoryID == "QUZ")
                        {
                            sumQuizScore += listStudentGrade[i]._Score;
                            countQuizScore++;
                        }
                        else if (listStudentGrade[i]._CategoryID == "MID")
                        {
                            sumMidScore += listStudentGrade[i]._Score;
                            countMidScore++;
                        }
                        else if (listStudentGrade[i]._CategoryID == "FIN")
                        {
                            sumFinalScore += listStudentGrade[i]._Score;
                            countFinalScore++;
                        }
                    }
                    else if (i > 0)
                    {
                        string currIndexSubjectID = listStudentGrade[i]._SubjectID;


                        if (listStudentGrade[i - 1]._SubjectID != "")
                        {
                            lastIndexSubjectID = listStudentGrade[i - 1]._SubjectID;
                        }

                        
                        if (lastIndexSubjectID == currIndexSubjectID)
                        {
                            listStudentGrade[i]._seqViewNo = "";
                            listStudentGrade[i]._Class = "";
                            listStudentGrade[i]._SubjectID = "";
                            listStudentGrade[i]._Subject = "";
                            listStudentGrade[i]._TeacherName = "";

                            listStudentGradeDuplicate.Add(listStudentGrade[i]);

                            if (listStudentGrade[i]._CategoryID == "ASG")
                            {
                                sumAssignmentScore += listStudentGrade[i]._Score;
                                countAssignmentScore++;
                            }
                            else if (listStudentGrade[i]._CategoryID == "QUZ")
                            {
                                sumQuizScore += listStudentGrade[i]._Score;
                                countQuizScore++;
                            }
                            else if (listStudentGrade[i]._CategoryID == "MID")
                            {
                                sumMidScore += listStudentGrade[i]._Score;
                                countMidScore++;
                            }
                            else if (listStudentGrade[i]._CategoryID == "FIN")
                            {
                                sumFinalScore += listStudentGrade[i]._Score;
                                countFinalScore++;
                            }
                        }
                        if(lastIndexSubjectID != currIndexSubjectID || i == tempGradeListCount-1)
                        {

                            avgAssignmentScore = Convert.ToInt32(Math.Round((float)sumAssignmentScore / countAssignmentScore));
                            avgQuizScore = Convert.ToInt32(Math.Round((float)sumQuizScore / countQuizScore));
                            avgMidScore = Convert.ToInt32(Math.Round((float)sumMidScore / countMidScore));
                            avgFinalScore = Convert.ToInt32(Math.Round((float)sumFinalScore / countFinalScore));

                            int totalAssignment = Convert.ToInt32(Math.Round(avgAssignmentScore * ((float)percentageASG / 100)));
                            int totalQuiz = Convert.ToInt32(Math.Round(avgQuizScore * ((float)percentageQuiz / 100)));
                            int totalMid = Convert.ToInt32(Math.Round(avgMidScore * ((float)percentageMid / 100)));
                            int totalFinal = Convert.ToInt32(Math.Round(avgFinalScore * ((float)percentageFinal / 100)));

                            int totalScore = totalAssignment + totalQuiz + totalMid + totalFinal;
                            string gradeLetter = "";
                            int minScore = listStudentGrade[i]._MinScore;

                            gradeLetter = scoreGradingGenerator(totalScore);

                            
                            listStudentGradeDuplicate.Add(new GradeData { _Component = "TOTAL SCORE", _MinScore = minScore, _Score = totalScore, _GradeLetter = gradeLetter });

                            // reset
                            sumAssignmentScore = 0;
                            sumQuizScore = 0;
                            sumMidScore = 0;
                            sumFinalScore = 0;

                            countAssignmentScore = 0;
                            countQuizScore = 0;
                            countMidScore = 0;
                            countFinalScore = 0;

                            if (lastIndexSubjectID != currIndexSubjectID)
                            {
                                // Next subject
                                listStudentGrade[i]._seqViewNo = seqViewNoTemp.ToString();
                                seqViewNoTemp++;
                                listStudentGradeDuplicate.Add(listStudentGrade[i]);

                                if (listStudentGrade[i]._CategoryID == "ASG")
                                {
                                    sumAssignmentScore += listStudentGrade[i]._Score;
                                    countAssignmentScore++;
                                }
                                else if (listStudentGrade[i]._CategoryID == "QUZ")
                                {
                                    sumQuizScore += listStudentGrade[i]._Score;
                                    countQuizScore++;
                                }
                                else if (listStudentGrade[i]._CategoryID == "MID")
                                {
                                    sumMidScore += listStudentGrade[i]._Score;
                                    countMidScore++;
                                }
                                else if (listStudentGrade[i]._CategoryID == "FIN")
                                {
                                    sumFinalScore += listStudentGrade[i]._Score;
                                    countFinalScore++;
                                }
                            }
                        }
                    }
                }

                rptStudentGrade.DataSource = listStudentGradeDuplicate;
                rptStudentGrade.DataBind();
            }
            
        }

        protected string scoreGradingGenerator(int score)
        {
            string gradeLetter = "";
            // source: https://en.wikipedia.org/wiki/Academic_grading_in_Indonesia
            if (score >= 85)
            {
                gradeLetter = "A";
            }
            else if (score >= 75 && score < 85)
            {
                gradeLetter = "B";
            }
            else if (score >= 60 && score < 75)
            {
                gradeLetter = "C";
            }
            else if (score >= 50 && score < 60)
            {
                gradeLetter = "D";
            }
            else if (score >= 0 && score < 50)
            {
                gradeLetter = "E";
            }

            return gradeLetter;
        }
    }
}