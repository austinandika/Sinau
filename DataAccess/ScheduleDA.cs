using Common;
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
    public class ScheduleDA
    {
        private Database db;
        public ScheduleDA()
        {
            try
            {
                db = DatabaseFactory.CreateDatabase("SinauConnectionString");
            }
            catch (Exception ex)
            {

            }
        }

        public List<ScheduleData> GetStudentScheduleDataByID(string userID)
        {
            string spName = "SP_GetStudentScheduleById";
            List<ScheduleData> returnList;

            try
            {
                DbCommand cmd = db.GetStoredProcCommand(spName);
                db.AddInParameter(cmd, "UserID", System.Data.DbType.String, userID);

                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    List<ScheduleData> studentScheduleList = new List<ScheduleData>();

                    while (reader.Read())
                    {
                        ScheduleData data = new ScheduleData();
                        data._DayID = Convert.ToString(reader["DayID"]);
                        data._SubjectName = Convert.ToString(reader["SubjectName"]);

                        data._TimeStart = TimeSpan.Parse(reader["TimeStart"].ToString()).ToString(@"hh\:mm");
                        data._TimeEnd = TimeSpan.Parse(reader["TimeEnd"].ToString()).ToString(@"hh\:mm");
                        data._LinkVidcon = Convert.ToString(reader["LinkVidcon"]);

                        studentScheduleList.Add(data);
                    }

                    returnList = studentScheduleList;
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
