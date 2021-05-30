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
    }
}
