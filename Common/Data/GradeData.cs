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
        public int _Grade { get; set; }
        public int _Semester { get; set; }
        public string _AcademicYearID { get; set; }
        public string _AcademicYear { get; set; }
        public string _SemesterAndAcademicYear { get; set; }
        public string _ClassID { get; set; }
        public string _Class { get; set; }
        public string _SubjectID { get; set; }
        public string _Subject { get; set; }
        public string _TeacherName { get; set; }
        public string _CategoryID { get; set; }
        public string _Category { get; set; }
        public string _Component { get; set; }
        public int _MinScore { get; set; }
        public int _Score { get; set; }
        public string _GradeLetter { get; set; }

        // no for sequence in user view 
        public string _seqViewNo { get; set; }
    }
}
