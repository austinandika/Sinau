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
        public UserData VerifyEmailAndPassword(string email, string password)
        {
            try
            {
                return new UserDA().VerifyEmailAndPassword(email, password);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
