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
    public class AccountDA
    {
        private Database db;

        public AccountDA()
        {
            try
            {
                db = DatabaseFactory.CreateDatabase("SinauConnectionString");
            }
            catch (Exception ex)
            {
                
            }
        }

        public AccountData VerifyAccountByEmailAndPassword(string email, string password)
        {
            string spName = "SP_VerifyAccountByEmailAndPassword";
            AccountData accountData = null;

            try
            {
                DbCommand cmd = db.GetStoredProcCommand(spName);
                db.AddInParameter(cmd, "Email", System.Data.DbType.String, email);
                db.AddInParameter(cmd, "Password", System.Data.DbType.String, password);

                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        accountData = new AccountData();
                        accountData._Email = reader["Email"].ToString().Trim();
                        accountData._UserID = reader["UserID"].ToString().Trim();
                        accountData._Role = reader["Role"].ToString().Trim();
                    }
                }
                return accountData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public AccountData GetUserByIdAndActivationCode(string userID, string activationCode)
        {
            string spName = "SP_GetUserByIdAndActivationCode";
            AccountData accountData = null;

            try
            {
                DbCommand cmd = db.GetStoredProcCommand(spName);
                db.AddInParameter(cmd, "UserID", System.Data.DbType.String, userID);
                db.AddInParameter(cmd, "ActivationCode", System.Data.DbType.String, activationCode);

                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        accountData = new AccountData();
                        accountData._UserID = reader["UserID"].ToString().Trim();
                        accountData._ActivationCode = reader["ActivationCode"].ToString().Trim();
                        accountData._Name = reader["Name"].ToString().Trim();
                        accountData._AccountStatusID = Convert.ToInt32(reader["AccountStatusID"]);
                    }
                }
                return accountData;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public bool InsertUserEmailAndPasswordById(string userID, string email, string password)
        {
            string spName = "SP_InsertUserEmailAndPasswordById";
            bool returnValue = false;

            try
            {
                using (DbConnection connection = db.CreateConnection())
                {
                    DbCommand cmd = db.GetStoredProcCommand(spName);
                    db.AddInParameter(cmd, "UserID", System.Data.DbType.String, userID);
                    db.AddInParameter(cmd, "Email", System.Data.DbType.String, email);
                    db.AddInParameter(cmd, "Password", System.Data.DbType.String, password);
                    db.ExecuteNonQuery(cmd);
                }

                returnValue = true;
            }
            catch (Exception ex)
            {
                returnValue = false;
            }

            return returnValue;
        }
    }
}
