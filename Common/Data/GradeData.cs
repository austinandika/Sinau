using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Data
{
    [Serializable]
    public class GradeData
    {
        public string _ClassID { get; set; }
        public string _Class { get; set; }
        public int _Grade { get; set; }
        public int _Semester { get; set; }
        public string _AcademicYearID { get; set; }
        public string _AcademicYear { get; set; }
        public string _SemesterAndAcademicYear { get; set; }
    }
}
