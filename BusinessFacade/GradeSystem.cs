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
    }
}
