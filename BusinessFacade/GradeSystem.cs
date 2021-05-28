using Common.Data;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFacade
{
    public class GradeSystem
    {
        public List<GradeData> GetStudentAllClassSemesterById(string userID)
        {
            try
            {
                return new GradeDA().GetStudentAllClassSemesterById(userID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
