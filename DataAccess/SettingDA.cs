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
    public class SettingDA
    {
        private Database db;

        public SettingDA()
        {
            try
            {
                db = DatabaseFactory.CreateDatabase("SinauConnectionString");
            }
            catch (Exception ex)
            {

            }
        }

        public SettingData GetUserLatestAcademicYearByIdAndRole(string userID, string role)
        {
            string spName = "SP_GetUserLatestAcademicYearByIdAndRole";
            SettingData settingData = null;

            try
            {
                DbCommand cmd = db.GetStoredProcCommand(spName);
                db.AddInParameter(cmd, "UserID", System.Data.DbType.String, userID);
                db.AddInParameter(cmd, "Role", System.Data.DbType.String, role);

                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        settingData = new SettingData();
                        settingData._AcademicYearID = reader["AcademicYearID"].ToString().Trim();
                    }
                }
                return settingData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<SettingData> GetUserAllAcademicYearByIdAndRole(string userID, string role)
        {
            string spName = "SP_GetUserAllAcademicYearByIdAndRole";
            List<SettingData> returnList;

            try
            {
                DbCommand cmd = db.GetStoredProcCommand(spName);
                db.AddInParameter(cmd, "UserID", System.Data.DbType.String, userID);
                db.AddInParameter(cmd, "Role", System.Data.DbType.String, role);

                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    List<SettingData> academicYearList = new List<SettingData>();

                    if (reader.Read())
                    {
                        SettingData data = new SettingData();
                        data._AcademicYearID = Convert.ToString(reader["AcademicYearID"]);
                        data._AcademicYearName = Convert.ToString(reader["AcademicYear"]);

                        academicYearList.Add(data);
                    }
                    returnList = academicYearList;
                }
                return returnList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
