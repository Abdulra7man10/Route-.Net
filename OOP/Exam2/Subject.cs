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

        public void HigherExam()
        {

            if (FinalE > PracticlE)
            {
                Console.WriteLine($"The final {FinalE.UserTotalPer:F2} is higher than the pratical {PracticlE.UserTotalPer:F2}.");
            }
            else if (FinalE < PracticlE)
            {
                Console.WriteLine($"The final {FinalE.UserTotalPer:F2} is lower than the pratical {PracticlE.UserTotalPer:F2}.");
            }
            else
            {
                Console.WriteLine($"The final is equal to the pratical, both are {FinalE.UserTotalPer:F2}.");
            }
        }
}
}
