using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App3
{
        public class Problem
        {
            public int contestId { get; set; }
            public string index { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public double points { get; set; }
            public List<string> tags { get; set; }
        }

        public class Member
        {
            public string handle { get; set; }
        }

        public class Author
        {
            public int contestId { get; set; }
            public List<Member> members { get; set; }
            public string participantType { get; set; }
            public int teamId { get; set; }
            public string teamName { get; set; }
            public bool ghost { get; set; }
            public int room { get; set; }
            public int startTimeSeconds { get; set; }
        }

        public class Result
        {
            public int id { get; set; }
            public int contestId { get; set; }
            public int creationTimeSeconds { get; set; }
            public int relativeTimeSeconds { get; set; }
            public Problem problem { get; set; }
            public Author author { get; set; }
            public string programmingLanguage { get; set; }
            public string verdict { get; set; }
            public string testset { get; set; }
            public int passedTestCount { get; set; }
            public int timeConsumedMillis { get; set; }
            public int memoryConsumedBytes { get; set; }
        }

        public class Submission
        {
            public string status { get; set; }
            public List<Result> result { get; set; }
        }
}
