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

        public bool InsertAssignmentByIdClassSubject(string classID, string subjectID, string academicYearID, string assignmentTitle, string assignDate, string dueDate, string assignmentPath, int statusID)
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
                    db.AddInParameter(cmd, "StatusID", System.Data.DbType.String, statusID);

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
    }
}
