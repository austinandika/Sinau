using Common.Data;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFacade
{
    public class SettingSystem
    {
        public SettingData GetUserLatestAcademicYearByIdAndRole(string userID, string role)
        {
            try
            {
                return new SettingDA().GetUserLatestAcademicYearByIdAndRole(userID, role);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
