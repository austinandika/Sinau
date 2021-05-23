using Common.Data;
using DataAccess;
using DataAccess.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFacade
{
    public class AssignmentSystem
    {
        public List<AssignmentData> GetTeacherClassById(string userID, string academicYearID)
        {
            try
            {
                return new AssignmentDA().GetTeacherClassById(userID, academicYearID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<AssignmentData> GetTeacherSubjectByIdAndClass(string userID, string classID, string academicYearID)
        {
            try
            {
                return new AssignmentDA().GetTeacherSubjectByIdAndClass(userID, classID, academicYearID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<AssignmentData> GetTeacherAssignmentByIdClassSubject(string userID, string classID, string subjectID, string academicYearID)
        {
            try
            {
                return new AssignmentDA().GetTeacherAssignmentByIdClassSubject(userID, classID, subjectID, academicYearID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool InsertAssignmentByIdClassSubject(string classID, string subjectID, string academicYearID, string assignmentTitle, string assignDate, string dueDate, string assignmentPath, int statusID)
        {
            try
            {
                return new AssignmentDA().InsertAssignmentByIdClassSubject(classID, subjectID, academicYearID, assignmentTitle, assignDate, dueDate, assignmentPath, statusID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
