using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Data
{
    [Serializable]
    public class AssignmentData
    {
        public string _ClassID { get; set; }
        public string _Class { get; set; }
        public string _SubjectID { get; set; }
        public string _Subject { get; set; }
        public int _ClassSubAssignID { get; set; }
        public string _AssignmentTitle { get; set; }
        public string _AssignmentPath { get; set; }
        public string _AssignDate { get; set; }
        public string _DueDate { get; set; }
        public int _StatusID { get; set; }
        public string _Status { get; set; }
        public string _SubmissionDate { get; set; }
        public string _AnswerPath { get; set; }
        public int _SubmissionStatusID { get; set; }
        public string _SubmissionStatus { get; set; }
    }
}
