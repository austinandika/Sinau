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
        public AccountData VerifyAccountByEmailAndPassword(string email, string password)
        {
            try
            {
                return new AccountDA().VerifyAccountByEmailAndPassword(email, password);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public AccountData GetUserByIdAndActivationCode(string userID, string activationCode)
        {
            try
            {
                return new AccountDA().GetUserByIdAndActivationCode(userID, activationCode);
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public bool InsertUserEmailAndPasswordById(string userID, string email, string password)
        {
            try
            {
                return new AccountDA().InsertUserEmailAndPasswordById(userID, email, password);
            }
            catch (Exception e)
            {

                return false;
            }
        }
    }
}
