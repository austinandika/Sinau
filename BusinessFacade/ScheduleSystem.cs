using Common;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFacade
{
    public class ScheduleSystem
    {
        public List<ScheduleData> GetStudentScheduleDataByID(string userID)
        {
            try
            {
                return new ScheduleDA().GetStudentScheduleDataByID(userID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
