using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class ScheduleData
    {
        public string _DayID { get; set; }
        public string _SubjectName { get; set; }
        public string _TimeStart { get; set; }
        public string _TimeEnd { get; set; }
        public string _LinkVidcon { get; set; }
    }
}
