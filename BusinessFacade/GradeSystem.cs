using Common.Data;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFacade
{
    public class GradeSystem
    {
        public List<GradeData> GetStudentAllClassSemesterById(string userID)
        {
            try
            {
                return new GradeDA().GetStudentAllClassSemesterById(userID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<GradeData> GetStudentScoreByUserIDAcademicYearID(string userID, string academicYearID)
        {
            try
            {
                return new GradeDA().GetStudentScoreByUserIDAcademicYearID(userID, academicYearID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<GradeData> GetTeacherByClassID(string classID)
        {
            try
            {
                return new GradeDA().GetTeacherByClassID(classID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<GradeData> GetTeacherClassById(string userID, string academicYearID)
        {
            try
            {
                return new GradeDA().GetTeacherClassById(userID, academicYearID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<GradeData> GetTeacherSubjectByIdAndClass(string userID, string classID, string academicYearID)
        {
            try
            {
                return new GradeDA().GetTeacherSubjectByIdAndClass(userID, classID, academicYearID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<GradeData> GetAllStudentScoreByAcademicYearSubjectClass(string academicYearID, string classID, string subjectID)
        {
            try
            {
                return new GradeDA().GetAllStudentScoreByAcademicYearSubjectClass(academicYearID, classID, subjectID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<GradeData> GetCategoryScorePercentage()
        {
            try
            {
                return new GradeDA().GetCategoryScorePercentage();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool InsertGradeComponent(string classID, string subjectID, string categoryID, string componentName)
        {
            try
            {
                return new GradeDA().InsertGradeComponent(classID, subjectID, categoryID, componentName);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateComponentStatus(int componentID, int isActiveComponent)
        {
            try
            {
                return new GradeDA().UpdateComponentStatus(componentID, isActiveComponent);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateNewScoreInput(int scoreID, int score)
        {
            try
            {
                return new GradeDA().UpdateNewScoreInput(scoreID, score);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
