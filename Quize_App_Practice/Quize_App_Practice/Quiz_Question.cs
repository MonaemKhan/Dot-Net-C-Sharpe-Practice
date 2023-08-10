using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quize_App_Practice
{
    public class Quiz_Question
    {
        public string? Question { get; set; }

        public List<string>? QuestionOptions { get; set; }

        public string? RightAnswer { get; set; }

        public int Mark { get; set; }

        public string? YourAnswer { get; set; }
    }
}
