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
    }
}
