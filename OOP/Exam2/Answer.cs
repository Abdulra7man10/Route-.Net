using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2
{
    internal class Answer
    {
        public Answer(int _aId = 0, string _aT = "None")
        {
            AnswerId = _aId;
            AnswerText = _aT;
        }
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
    }
}
