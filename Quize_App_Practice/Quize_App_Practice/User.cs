using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quize_App_Practice
{
    public class User
    {
        public string? UserName { get; set; }

        public List<Quiz_Question>? Quiz { get; set; }

        public int TotalMark { set; get; }

        public int TotalRightAnswer { set; get; }

        public int TotalWrongAnswer { set; get; }
    }
}
