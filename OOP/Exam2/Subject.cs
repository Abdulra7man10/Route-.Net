using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2
{
    internal class Subject
    {
        public Subject(string sId = "None", string SN = "None") 
        {
            SubjectId = sId;
            SubjectName = SN;
        }
        public string SubjectId { get; set; }
        public string SubjectName { get; set; }

        public PraticalExam PracticlE { get; set; }
        public FinalExam FinalE { get; set; }
}
}
