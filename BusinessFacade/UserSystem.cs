using Common.Data;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFacade
{
    public class UserSystem
    {
        public UserData GetUserInfoByUserID(string userID, string role)
        {
            try
            {
                return new UserDA().GetUserInfoByUserID(userID, role);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
