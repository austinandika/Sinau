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
        public string _Name { get; set; }
        public string _PhoneNumber { get; set; }
        public string _Religion { get; set; }
        public string _DateOfBirth { get; set; }
        public string _PlaceOfBirth { get; set; }
        public string _Address { get; set; }

    }
}
