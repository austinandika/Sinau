using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Data
{
    [Serializable]
    public class UserData
    {
        public string _Email { get; set; }
        public string _UserID { get; set; }
        public string _Role { get; set; }
    }
}
