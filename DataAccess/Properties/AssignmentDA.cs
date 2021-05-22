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
                db.AddInParameter(cmd, "classID", System.Data.DbType.String, classID);
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
    }
}
