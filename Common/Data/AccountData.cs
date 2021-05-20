using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Data
{
    [Serializable]
    public class AccountData
    {
        public string _Email { get; set; }
        public string _Password { get; set; }
        public string _UserID { get; set; }
        public string _Name { get; set; }
        public string _Role { get; set; }
        public string _ActivationCode { get; set; }
        public int _AccountStatusID { get; set; }
    }
}
