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
    public class UserDA
    {
        private Database db;

        public UserDA()
        {
            try
            {
                db = DatabaseFactory.CreateDatabase("SinauConnectionString");
            }
            catch (Exception ex)
            {

            }
        }
        
        public UserData GetUserInfoByUserID(string userID, string role)
        {
            string spName = "SP_GetUserInfoByUserID";
            UserData userData = null;

            try
            {
                DbCommand cmd = db.GetStoredProcCommand(spName);
                db.AddInParameter(cmd, "UserID", System.Data.DbType.String, userID);
                db.AddInParameter(cmd, "Role", System.Data.DbType.String, role);

                using(IDataReader reader = db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        userData = new UserData();
                        userData._Name = reader["Name"].ToString().Trim();
                        userData._PhoneNumber = reader["PhoneNumber"].ToString().Trim();
                        userData._Religion = reader["Religion"].ToString().Trim();
                        userData._DateOfBirth = reader["DateOfBirth"].ToString().Trim();
                        userData._PlaceOfBirth = reader["PlaceOfBirth"].ToString().Trim();
                        userData._Address = reader["Address"].ToString().Trim();
                    }
                }
                return userData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
