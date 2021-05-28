using Common.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GradeDA
    {
        private Database db;

        public GradeDA()
        {
            try
            {
                db = DatabaseFactory.CreateDatabase("SinauConnectionString");
            }
            catch (Exception ex)
            {

            }
        }

        public List<GradeData> GetStudentAllClassSemesterById(string userID)
        {
            string spName = "SP_GetStudentAllClassSemesterById";
            List<GradeData> returnList;

            try
            {
                DbCommand cmd = db.GetStoredProcCommand(spName);
                db.AddInParameter(cmd, "UserID", System.Data.DbType.String, userID);

                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    List<GradeData> classList = new List<GradeData>();

                    while (reader.Read())
                    {
                        GradeData data = new GradeData();
                        data._ClassID = Convert.ToString(reader["ClassID"]);
                        data._Class = Convert.ToString(reader["Class"]);
                        data._Grade = Convert.ToInt32(reader["Grade"]);
                        data._Semester = Convert.ToInt32(reader["Semester"]);
                        data._AcademicYearID = Convert.ToString(reader["AcademicYearID"]);
                        data._AcademicYear = Convert.ToString(reader["AcademicYear"]);

                        classList.Add(data);
                    }

                    returnList = classList;
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
