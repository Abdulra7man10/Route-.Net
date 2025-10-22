using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exam2
{
    abstract class Question
    {
        protected Question() { }
        public string Header { get; set; }
        public string Body { get; set; }
        public double Mark { get; set; }

        public int AnswerRightId { get; set; }
        public int UserAnswerId { get; set; }

        protected Answer[] _answers;

        public Answer[] Answers
        {
            get { return _answers; }
            set { _answers = value; }
        }

        public bool CheckRightAnswer()
        {
            return AnswerRightId == UserAnswerId;
        }

        public void AssignAnswer(int answerId)
        {
            if (answerId >= 1 && answerId <= Answers.Length)
            {
                UserAnswerId = answerId;
            }
            else
            {
                throw new ArgumentException($"Answer ID must be between 1 and {Answers.Length}.");
            }
        }

        public override string ToString()
        {
            return $"{Header} ({Mark:F1} marks)\n" +
                   $"{Body}";
        }

        public abstract void DisplayAnswer();
        
    }

    class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion()
        {
            _answers = new Answer[2];
            _answers[0] = new Answer(1, "True");
            _answers[1] = new Answer(2, "False");
            AnswerRightId = 1;
        }

        public override string ToString()
        {
            return base.ToString() + "\n\n1. True\n2. False\n";
        }

        public override void DisplayAnswer()
        {
            Console.WriteLine(this.ToString());
            Console.WriteLine($"The correct answer is: {Answers[AnswerRightId - 1].AnswerText}");
            Console.WriteLine($"Mark: {(CheckRightAnswer()? Mark : 0)}/{Mark}");
        }
    }

    class MultipleChoiceQuestion : Question
    {
        public int NumberOfChoices
        {
            get { return Answers.Length; }
            set => Array.Resize<Answer>(ref _answers, value);
        }
        public MultipleChoiceQuestion(int numberOfChoices = 1)
        {
            _answers = new Answer[numberOfChoices];
            for (int i = 0; i < numberOfChoices; i++)
            {
                _answers[i] = new Answer(i + 1, $"Choice {i + 1}");
            }
        }

        public override string ToString()
        {
            string result = base.ToString() + "\n";
            for (int i = 0; i < Answers.Length; i++)
            {
                result += $"{Answers[i].AnswerId}. {Answers[i].AnswerText}\n";
            }
            return result;
        }

        public override void DisplayAnswer()
        {
            Console.WriteLine(this.ToString());
            Console.WriteLine($"The correct answer is: {Answers[AnswerRightId - 1].AnswerId}. {Answers[AnswerRightId - 1].AnswerText}");
            Console.WriteLine($"Mark: {(CheckRightAnswer() ? Mark : 0)}/{Mark}");
        }

        public void DisplayOnlyAnswer()
        {
            Console.WriteLine($"The correct answer is:\n" +
                $"{Answers[AnswerRightId - 1].AnswerId}. {Answers[AnswerRightId - 1].AnswerText}");
        }
    }
}
