﻿using Common.Data;
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
            catch (Exception e)
            {

                throw;
            }
        }

        public UserData VerifyEmailAndPassword(string email, string password)
        {
            string spName = "";
            UserData userData = null;

            try
            {
                DbCommand cmd = db.GetStoredProcCommand(spName);
                db.AddInParameter(cmd, "Email", System.Data.DbType.String, email);
                db.AddInParameter(cmd, "Password", System.Data.DbType.String, password);

                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        userData = new UserData();
                        userData._Email = reader["Email"].ToString().Trim();
                        userData._UserID = reader["UserID"].ToString().Trim();
                        userData._Role = reader["Role"].ToString().Trim();
                    }
                }
                return userData;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}