using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2
{
    abstract class Exam
    {
        public Exam(int ToE=0, int NoQ=0) 
        {
            TimeofExam = ToE;
            NumberofQuestions = NoQ;
        }

        public int TimeofExam { get; set; } // in minutes
        public int NumberofQuestions { get; set; }

        public Question[] Questions { get; set; }

        public double TotalMarks 
        {
            get
            {
                double total = 0;
                foreach (var question in Questions)
                {
                    total += question.Mark;
                }
                return total;
            }
        }

        public double UserTotalMarks
        {
            get
            {
                double total = 0;
                foreach (var question in Questions)
                {
                    if (question.CheckRightAnswer())
                    {
                        total += question.Mark;
                    }
                }
                return total;
            }
        }

        public double UserTotalPer
        {
            get
            {
                return (UserTotalMarks * 100) / TotalMarks;
            }
        }

        public override string ToString()
        {
            string result = $"Exam: {GetType()}\nNumber of Questions: {NumberofQuestions}\n" +
                $"Time of Exam: {TimeofExam} Min\nTotal Marks: {TotalMarks}\n";

            foreach (var question in Questions) 
                result += question.ToString() + "\n";

            return result;
        }

        public static bool operator >(Exam examA, Exam examB)
        {
            if (examA is null) return false;
            if (examB is null) return true;

            return examA.UserTotalPer > examB.UserTotalPer;
        }

        public static bool operator <(Exam examA, Exam examB)
        {
            if (examA is null) return true;
            if (examB is null) return false;

            return examA.UserTotalPer < examB.UserTotalPer;
        }

        public static bool operator ==(Exam examA, Exam examB)
        {
            if (examA is null || examB is null) return false;

            return examA.UserTotalPer == examB.UserTotalPer;
        }

        public static bool operator !=(Exam examA, Exam examB)
        {
            if (examA is null || examB is null) return false;

            return examA.UserTotalPer != examB.UserTotalPer;
        }

        public abstract void DisplayAfterExam();
    }

    class PraticalExam : Exam
    {
        public PraticalExam(int ToE = 0, int NoQ = 0) : base(ToE, NoQ)
        {
            Questions = new MultipleChoiceQuestion[NoQ];
        }

        public override void DisplayAfterExam()
        {
            Console.WriteLine("Pratical Exam Review:");

            int i = 1;
            foreach (var q in Questions)
            {
                if (q is MultipleChoiceQuestion mcq)
                {
                    Console.Write($"Q{i} -> ");
                    mcq.DisplayOnlyAnswer();
                }
                i++;
            }
            Console.WriteLine("++++++++++++++++++++++");

            Console.WriteLine($"Total result: {UserTotalMarks} out of {TotalMarks}");
        }
    }

    class FinalExam : Exam
    {
        public FinalExam(int ToE = 0, int NoQ = 0) : base(ToE, NoQ)
        {
            Questions = new Question[NoQ];
        }

        public override void DisplayAfterExam()
        {
            Console.WriteLine("Final Exam Review:");
            foreach (var q in Questions)
            {
                q.DisplayAnswer();
                Console.WriteLine("+++++++++++++++++++++++++++");
            }
            Console.WriteLine($"Total Marks: {UserTotalMarks} out of {TotalMarks}");
        }
    }
}
