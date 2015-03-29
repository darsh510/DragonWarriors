using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App3
{
    public class CodeForcesUser
    {
        public string handle { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string organization { get; set; }
        public int contribution { get; set; }
        public string rank { get; set; }
        public int rating { get; set; }
        public string maxRank { get; set; }
        public int maxRating { get; set; }
        public int lastOnlineTimeSeconds { get; set; }
        public int registrationTimeSeconds { get; set; }
    }

    public class MainUserObject
    {
        public string status { get; set; }
        public List<CodeForcesUser> result { get; set; }
    }
}
