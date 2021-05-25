using Common.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Properties
{
    public class AssignmentDA
    {
        private Database db;

        public AssignmentDA()
        {
            try
            {
                db = DatabaseFactory.CreateDatabase("SinauConnectionString");
            }
            catch (Exception ex)
            {

            }
        }

        public List<AssignmentData> GetTeacherClassById(string userID, string academicYearID)
        {
            string spName = "SP_GetTeacherClassById";
            List<AssignmentData> returnList;

            try
            {
                DbCommand cmd = db.GetStoredProcCommand(spName);
                db.AddInParameter(cmd, "UserID", System.Data.DbType.String, userID);
                db.AddInParameter(cmd, "AcademicYearID", System.Data.DbType.String, academicYearID);

                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    List<AssignmentData> teacherClassList = new List<AssignmentData>();

                    while (reader.Read())
                    {
                        AssignmentData data = new AssignmentData();
                        data._ClassID = Convert.ToString(reader["ClassID"]);
                        data._Class = Convert.ToString(reader["Class"]);

                        teacherClassList.Add(data);
                    }

                    returnList = teacherClassList;
                }
                return returnList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<AssignmentData> GetTeacherSubjectByIdAndClass(string userID, string classID, string academicYearID)
        {
            string spName = "SP_GetTeacherSubjectByIdAndClass";
            List<AssignmentData> returnList;

            try
            {
                DbCommand cmd = db.GetStoredProcCommand(spName);
                db.AddInParameter(cmd, "UserID", System.Data.DbType.String, userID);
                db.AddInParameter(cmd, "ClassID", System.Data.DbType.String, classID);
                db.AddInParameter(cmd, "AcademicYearID", System.Data.DbType.String, academicYearID);

                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    List<AssignmentData> teacherSubjectList = new List<AssignmentData>();

                    while (reader.Read())
                    {
                        AssignmentData data = new AssignmentData();
                        data._SubjectID = Convert.ToString(reader["SubjectID"]);
                        data._Subject = Convert.ToString(reader["Subject"]);

                        teacherSubjectList.Add(data);
                    }

                    returnList = teacherSubjectList;
                }
                return returnList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<AssignmentData> GetTeacherAssignmentByIdClassSubject(string userID, string classID, string subjectID, string academicYearID)
        {
            string spName = "SP_GetTeacherAssignmentByIdClassSubject";
            List<AssignmentData> returnList;

            try
            {
                DbCommand cmd = db.GetStoredProcCommand(spName);
                db.AddInParameter(cmd, "UserID", System.Data.DbType.String, userID);
                db.AddInParameter(cmd, "ClassID", System.Data.DbType.String, classID);
                db.AddInParameter(cmd, "SubjectID", System.Data.DbType.String, subjectID);
                db.AddInParameter(cmd, "AcademicYearID", System.Data.DbType.String, academicYearID);

                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    List<AssignmentData> teacherAssignmentList = new List<AssignmentData>();

                    while (reader.Read())
                    {
                        AssignmentData data = new AssignmentData();
                        data._ClassSubAssignID = Convert.ToInt32(reader["ClSubAsID"]);
                        data._Class = Convert.ToString(reader["Class"]);
                        data._Subject = Convert.ToString(reader["Subject"]);
                        data._AssignmentTitle = Convert.ToString(reader["AssignmentTitle"]);
                        data._AssignmentPath = Convert.ToString(reader["AssignmentPath"]);
                        data._AssignDate = (Convert.ToDateTime(reader["AssignDate"])).ToString("MMM dd, yyyy");
                        data._DueDate = Convert.ToDateTime(reader["DueDate"]).ToString("MMM dd, yyyy");
                        data._StatusID = Convert.ToInt32(reader["StatusID"]);
                        data._Status = Convert.ToString(reader["Status"]);

                        teacherAssignmentList.Add(data);
                    }

                    returnList = teacherAssignmentList;
                }
                return returnList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool InsertAssignmentByIdClassSubject(string classID, string subjectID, string academicYearID, string assignmentTitle, string assignDate, string dueDate, string assignmentPath)
        {
            string spName = "SP_InsertAssignmentByIdClassSubject";
            bool returnValue = false;

            try
            {
                using (DbConnection connection = db.CreateConnection())
                {
                    DbCommand cmd = db.GetStoredProcCommand(spName);
                    db.AddInParameter(cmd, "ClassID", System.Data.DbType.String, classID);
                    db.AddInParameter(cmd, "SubjectID", System.Data.DbType.String, subjectID);
                    db.AddInParameter(cmd, "AcademicYearID", System.Data.DbType.String, academicYearID);
                    db.AddInParameter(cmd, "AssignmentTitle", System.Data.DbType.String, assignmentTitle);
                    db.AddInParameter(cmd, "AssignDate", System.Data.DbType.String, assignDate);
                    db.AddInParameter(cmd, "DueDate", System.Data.DbType.String, dueDate);
                    db.AddInParameter(cmd, "AssignmentPath", System.Data.DbType.String, assignmentPath);

                    db.ExecuteNonQuery(cmd);
                }

                returnValue = true;
            }
            catch (Exception e)
            {
                returnValue = false;
            }

            return returnValue;
        }

        public List<AssignmentData> GetStudentClassById(string userID, string academicYearID)
        {
            string spName = "SP_GetStudentClassById";
            List<AssignmentData> returnList;

            try
            {
                DbCommand cmd = db.GetStoredProcCommand(spName);
                db.AddInParameter(cmd, "UserID", System.Data.DbType.String, userID);
                db.AddInParameter(cmd, "AcademicYearID", System.Data.DbType.String, academicYearID);

                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    List<AssignmentData> studentClassList = new List<AssignmentData>();

                    while (reader.Read())
                    {
                        AssignmentData data = new AssignmentData();
                        data._ClassID = Convert.ToString(reader["ClassID"]);
                        data._Class = Convert.ToString(reader["Class"]);

                        studentClassList.Add(data);
                    }

                    returnList = studentClassList;
                }
                return returnList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<AssignmentData> GetStudentSubjectByClass(string classID, string academicYearID)
        {
            string spName = "SP_GetStudentSubjectByClass";
            List<AssignmentData> returnList;

            try
            {
                DbCommand cmd = db.GetStoredProcCommand(spName);
                db.AddInParameter(cmd, "ClassID", System.Data.DbType.String, classID);
                db.AddInParameter(cmd, "AcademicYearID", System.Data.DbType.String, academicYearID);

                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    List<AssignmentData> studentSubjectList = new List<AssignmentData>();

                    while (reader.Read())
                    {
                        AssignmentData data = new AssignmentData();
                        data._SubjectID = Convert.ToString(reader["SubjectID"]);
                        data._Subject = Convert.ToString(reader["Subject"]);

                        studentSubjectList.Add(data);
                    }

                    returnList = studentSubjectList;
                }
                return returnList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<AssignmentData> GetStudentAssignmentByClassSubject(string userID, string classID, string subjectID, string academicYearID)
        {
            string spName = "SP_GetStudentAssignmentByClassSubject";
            List<AssignmentData> returnList;

            try
            {
                DbCommand cmd = db.GetStoredProcCommand(spName);
                db.AddInParameter(cmd, "UserID", System.Data.DbType.String, userID);
                db.AddInParameter(cmd, "ClassID", System.Data.DbType.String, classID);
                db.AddInParameter(cmd, "SubjectID", System.Data.DbType.String, subjectID);
                db.AddInParameter(cmd, "AcademicYearID", System.Data.DbType.String, academicYearID);

                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    List<AssignmentData> studentAssignmentList = new List<AssignmentData>();

                    while (reader.Read())
                    {
                        AssignmentData data = new AssignmentData();
                        data._ClassSubAssignID = Convert.ToInt32(reader["ClSubAsID"]);
                        data._Class = Convert.ToString(reader["Class"]);
                        data._Subject = Convert.ToString(reader["Subject"]);
                        data._AssignmentTitle = Convert.ToString(reader["AssignmentTitle"]);
                        data._AssignmentPath = Convert.ToString(reader["AssignmentPath"]);
                        data._AssignDate = (Convert.ToDateTime(reader["AssignDate"])).ToString("MMM dd, yyyy");
                        data._DueDate = Convert.ToDateTime(reader["DueDate"]).ToString("MMM dd, yyyy");
                        data._StatusID = Convert.ToInt32(reader["StatusID"]);
                        data._Status = Convert.ToString(reader["Status"]);
                        
                        try
                        {
                            data._SubmissionDate = (Convert.ToDateTime(reader["SubmissionDate"])).ToString("MMM dd, yyyy");
                        }
                        catch (Exception ex)
                        {
                            data._SubmissionDate = "";
                        }

                        data._AnswerPath = Convert.ToString(reader["AnswerPath"]);
                        try
                        {
                            data._SubmissionStatusID = Convert.ToInt32(reader["SubmStatusID"]);
                        }
                        catch (Exception)
                        {

                            data._SubmissionStatusID = -1;      // haven't submitted the answer
                        }
                        
                        data._SubmissionStatus = Convert.ToString(reader["SubmStatus"]);

                        studentAssignmentList.Add(data);
                    }

                    returnList = studentAssignmentList;
                }
                return returnList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public AssignmentData GetAssignmentFilePathByClassSubAssignID(int classSubjectAssignmentID)
        {
            string spName = "SP_GetAssignmentFilePathByClassSubAssignID";
            AssignmentData assignmentPath = null;

            try
            {
                DbCommand cmd = db.GetStoredProcCommand(spName);
                db.AddInParameter(cmd, "ClassSubAssignID", System.Data.DbType.String, classSubjectAssignmentID);

                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        assignmentPath = new AssignmentData();
                        assignmentPath._AssignmentPath = reader["AssignmentPath"].ToString().Trim();
                    }
                }
                return assignmentPath;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool InsertStudentAsgAnswerByClSubAsgIDAndUserID(int classSubjectAssignmentID, string userID, string submissionDate, string answerPath)
        {
            string spName = "SP_InsertStudentAsgAnswerByClSubAsgIDAndUserID";
            bool returnValue = false;

            try
            {
                using (DbConnection connection = db.CreateConnection())
                {
                    DbCommand cmd = db.GetStoredProcCommand(spName);
                    db.AddInParameter(cmd, "ClassSubAssignID", System.Data.DbType.Int32, classSubjectAssignmentID);
                    db.AddInParameter(cmd, "UserID", System.Data.DbType.String, userID);
                    db.AddInParameter(cmd, "SubmissionDate", System.Data.DbType.String, submissionDate);
                    db.AddInParameter(cmd, "AnswerPath", System.Data.DbType.String, answerPath);

                    db.ExecuteNonQuery(cmd);
                }

                returnValue = true;
            }
            catch (Exception e)
            {
                returnValue = false;
            }

            return returnValue;
        }

        public AssignmentData GetAssignmentAnsFileByClassSubAssignIDAndUserID(int classSubjectAssignmentID, string userID)
        {
            string spName = "SP_GetAssignmentAnsFileByClassSubAssignIDAndUserID";
            AssignmentData assignmentPath = null;

            try
            {
                DbCommand cmd = db.GetStoredProcCommand(spName);
                db.AddInParameter(cmd, "ClassSubAssignID", System.Data.DbType.String, classSubjectAssignmentID);
                db.AddInParameter(cmd, "UserID", System.Data.DbType.String, userID);

                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        assignmentPath = new AssignmentData();
                        assignmentPath._AnswerPath = reader["AnswerPath"].ToString().Trim();
                    }
                }
                return assignmentPath;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
