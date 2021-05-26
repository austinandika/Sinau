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

        public bool InsertAssignmentByIdClassSubject(string classID, string subjectID, string academicYearID, string assignmentTitle, string assignDate, string dueDate, string assignmentPath)
        {
            try
            {
                return new AssignmentDA().InsertAssignmentByIdClassSubject(classID, subjectID, academicYearID, assignmentTitle, assignDate, dueDate, assignmentPath);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<AssignmentData> GetStudentClassById(string userID, string academicYearID)
        {
            try
            {
                return new AssignmentDA().GetStudentClassById(userID, academicYearID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<AssignmentData> GetStudentSubjectByClass(string classID, string academicYearID)
        {
            try
            {
                return new AssignmentDA().GetStudentSubjectByClass(classID, academicYearID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<AssignmentData> GetStudentAssignmentByClassSubject(string userID, string classID, string subjectID, string academicYearID)
        {
            try
            {
                return new AssignmentDA().GetStudentAssignmentByClassSubject(userID, classID, subjectID, academicYearID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public AssignmentData GetAssignmentFilePathByClassSubAssignID(int classSubjectAssignmentID)
        {
            try
            {
                return new AssignmentDA().GetAssignmentFilePathByClassSubAssignID(classSubjectAssignmentID);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool InsertStudentAsgAnswerByClSubAsgIDAndUserID(int classSubjectAssignmentID, string userID, string submissionDate, string answerPath)
        {
            try
            {
                return new AssignmentDA().InsertStudentAsgAnswerByClSubAsgIDAndUserID(classSubjectAssignmentID, userID, submissionDate, answerPath);
            }
            catch (Exception)
            {
                return false ;
            }
        }

        public AssignmentData GetAssignmentAnsFileByClassSubAssignIDAndUserID(int classSubjectAssignmentID, string userID)
        {
            try
            {
                return new AssignmentDA().GetAssignmentAnsFileByClassSubAssignIDAndUserID(classSubjectAssignmentID, userID);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<AssignmentData> GetAllAssignmentAnsFileByClassSubAssignID(int classSubjectAssignmentID)
        {
            try
            {
                return new AssignmentDA().GetAllAssignmentAnsFileByClassSubAssignID(classSubjectAssignmentID);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
