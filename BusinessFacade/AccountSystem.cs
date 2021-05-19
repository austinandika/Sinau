using Common.Data;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFacade
{
    public class AccountSystem
    {
        public AccountData VerifyEmailAndPassword(string email, string password)
        {
            try
            {
                return new AccountDA().VerifyEmailAndPassword(email, password);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
