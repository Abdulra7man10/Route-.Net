using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*#region TestQuestions
            Question[] questions = new Question[5];

            questions[0] = new TrueFalseQuestion()
            {
                Header = "Question 1",
                Body = "The Earth is flat.",
                Mark = 1,
                AnswerRightId = 1
            };
            questions[1] = new TrueFalseQuestion()
            {
                Header = "Question 2",
                Body = "The sky is blue.",
                Mark = 1,
                AnswerRightId = 1
            };
            questions[2] = new TrueFalseQuestion()
            {
                Header = "Question 3",
                Body = "C# is not a programming language.",
                Mark = 1,
                AnswerRightId = 2
            };
            questions[3] = new MultipleChoiceQuestion(4)
            {
                Header = "Question 4",
                Body = "What is the capital of France?",
                Mark = 2,
                Answers = new Answer[]
                {
                    new Answer(1, "Berlin"),
                    new Answer(2, "Madrid"),
                    new Answer(3, "Paris"),
                    new Answer(4, "Rome")
                },
                AnswerRightId = 3
            };
            questions[4] = new MultipleChoiceQuestion(3)
            {
                Header = "Question 5",
                Body = "Which planet is known as the Red Planet?",
                Mark = 2,
                Answers = new Answer[]
                {
                    new Answer(1, "Earth"),
                    new Answer(2, "Mars"),
                    new Answer(3, "Jupiter")
                },
                AnswerRightId = 2
            };

            double totalScore = 0;
            double userScore = 0;
            foreach (var question in questions)
            {
                Console.WriteLine(question.ToString());
                Console.Write("Your answer (enter the answer ID): ");

                question.UserAnswerId = int.Parse(Console.ReadLine());

                totalScore += question.Mark;
                if (question is TrueFalseQuestion tfQuestion) 
                {
                    if (tfQuestion.CheckRightAnswer())
                    {
                        userScore += question.Mark;
                    }
                }
                else if (question is MultipleChoiceQuestion mcQuestion)
                {
                    if (mcQuestion.CheckRightAnswer())
                    {
                        userScore += question.Mark;
                    }
                }

                Console.WriteLine();
            }

            foreach (var question in questions)
            {
                question.DisplayAnswer();
                Console.WriteLine();
            }
            Console.WriteLine($"Your total score is: {userScore} out of {totalScore}");
            #endregion*/

            #region TestExams
            Subject Programming = new Subject("CS101", "Programming");

            #region TestPraticalExam

            PraticalExam praticalExam = new PraticalExam(30, 10);
            #region Populate Questions
            praticalExam.Questions[0] = new MultipleChoiceQuestion(4)
            {
                Header = $"Pratical Question {1}",
                Body = $"Which is not programming Langauge.",
                Mark = 1,
                Answers = new Answer[]
                {
                    new Answer(1, "C#"),
                    new Answer(2, "HTML"),
                    new Answer(3, "C++"),
                    new Answer(4, "Java")
                },
                AnswerRightId = 2
            };
            praticalExam.Questions[1] = new MultipleChoiceQuestion(4)
            {
                Header = $"Pratical Question {2}",
                Body = $"Which company developed the C# programming language?",
                Mark = 1,
                Answers = new Answer[]
                {
                    new Answer(1, "Microsoft"),
                    new Answer(2, "Apple"),
                    new Answer(3, "Google"),
                    new Answer(4, "IBM")
                },
                AnswerRightId = 1
            };
            praticalExam.Questions[2] = new MultipleChoiceQuestion(4)
            {
                Header = $"Pratical Question {3}",
                Body = $"What does 'OOP' stand for in programming?",
                Mark = 1,
                Answers = new Answer[]
                {
                    new Answer(1, "Object-Oriented Programming"),
                    new Answer(2, "Open-Source Programming"),
                    new Answer(3, "Operational Object Programming"),
                    new Answer(4, "Optimal Output Processing")
                },
                AnswerRightId = 1
            };
            praticalExam.Questions[3] = new MultipleChoiceQuestion(4)
            {
                Header = $"Pratical Question {4}",
                Body = $"Which keyword is used to define a class in C#?",
                Mark = 1,
                Answers = new Answer[]
                {
                    new Answer(1, "struct"),
                    new Answer(2, "class"),
                    new Answer(3, "interface"),
                    new Answer(4, "enum")
                },
                AnswerRightId = 2
            };
            praticalExam.Questions[4] = new MultipleChoiceQuestion(4)
            {
                Header = $"Pratical Question {5}",
                Body = $"Which of the following is NOT a value type in C#?",
                Mark = 1,
                Answers = new Answer[]
                {
                    new Answer(1, "int"),
                    new Answer(2, "float"),
                    new Answer(3, "string"),
                    new Answer(4, "bool")
                },
                AnswerRightId = 3
            };
            praticalExam.Questions[5] = new MultipleChoiceQuestion(4)
            {
                Header = $"Pratical Question {6}",
                Body = $"What is the default access modifier for class members in C#?",
                Mark = 1,
                Answers = new Answer[]
                {
                    new Answer(1, "public"),
                    new Answer(2, "private"),
                    new Answer(3, "protected"),
                    new Answer(4, "internal")
                },
                AnswerRightId = 2
            };
            praticalExam.Questions[6] = new MultipleChoiceQuestion(4)
            {
                Header = $"Pratical Question {7}",
                Body = $"Which of the following is used to handle exceptions in C#?",
                Mark = 1,
                Answers = new Answer[]
                {
                    new Answer(1, "try-catch"),
                    new Answer(2, "if-else"),
                    new Answer(3, "switch-case"),
                    new Answer(4, "for-loop")
                },
                AnswerRightId = 1
            };
            praticalExam.Questions[7] = new MultipleChoiceQuestion(4)
            {
                Header = $"Pratical Question {8}",
                Body = $"Which operator is used to concatenate strings in C#?",
                Mark = 1,
                Answers = new Answer[]
                {
                    new Answer(1, "+"),
                    new Answer(2, "&"),
                    new Answer(3, "||"),
                    new Answer(4, "++")
                },
                AnswerRightId = 1
            };
            praticalExam.Questions[8] = new MultipleChoiceQuestion(4)
            {
                Header = $"Pratical Question {9}",
                Body = $"What is the size of an int data type in C#?",
                Mark = 1,
                Answers = new Answer[]
                {
                    new Answer(1, "2 bytes"),
                    new Answer(2, "4 bytes"),
                    new Answer(3, "8 bytes"),
                    new Answer(4, "16 bytes")
                },
                AnswerRightId = 2
            };
            praticalExam.Questions[9] = new MultipleChoiceQuestion(4)
            {
                Header = $"Pratical Question {10}",
                Body = $"Which of the following is NOT a loop structure in C#?",
                Mark = 1,
                Answers = new Answer[]
                {
                    new Answer(1, "for"),
                    new Answer(2, "while"),
                    new Answer(3, "foreach"),
                    new Answer(4, "repeat-until")
                },
                AnswerRightId = 4
            };
            #endregion

            Programming.PracticlE = praticalExam;

            /*Console.WriteLine($"Pratical Exam of Programming Subject");
            Console.WriteLine("===============================\n");

            int userInput;
            foreach (var question in Programming.PracticlE.Questions)
            {
                Console.WriteLine(question.ToString());
                Console.Write("Your answer (enter the answer ID): ");

                userInput = int.Parse(Console.ReadLine());
                question.AssignAnswer(userInput);

                Console.WriteLine("--------------------------\n");
            }

            Programming.PracticlE.DisplayAfterExam();*/

            #endregion

            #region TestFinalExam
            FinalExam finalExam = new FinalExam(60, 15);
            #region Populate Questions
            finalExam.Questions[0] = new TrueFalseQuestion()
            {
                Header = $"Final Question {1}",
                Body = $"The C# programming language was developed by Microsoft.",
                Mark = 2,
                AnswerRightId = 1
            };
            finalExam.Questions[1] = new TrueFalseQuestion()
            {
                Header = $"Final Question {2}",
                Body = $"In C#, 'int' is a reference type.",
                Mark = 2,
                AnswerRightId = 2
            };
            finalExam.Questions[2] = new TrueFalseQuestion()
            {
                Header = $"Final Question {3}",
                Body = $"The 'using' directive is used to include namespaces in C#.",
                Mark = 2,
                AnswerRightId = 1
            };
            finalExam.Questions[3] = new MultipleChoiceQuestion(4)
            {
                Header = $"Final Question {4}",
                Body = $"Which of the following is NOT a C# access modifier?",
                Mark = 3,
                Answers = new Answer[]
                {
                    new Answer(1, "public"),
                    new Answer(2, "private"),
                    new Answer(3, "protected"),
                    new Answer(4, "external")
                },
                AnswerRightId = 4
            };
            finalExam.Questions[4] = new MultipleChoiceQuestion(4)
            {
                Header = $"Final Question {5}",
                Body = $"What is the output of the following code snippet?\n\nint x = 5;\nConsole.WriteLine(x++);",
                Mark = 3,
                Answers = new Answer[]
                {
                    new Answer(1, "5"),
                    new Answer(2, "6"),
                    new Answer(3, "Error"),
                    new Answer(4, "Undefined")
                },
                AnswerRightId = 1
            };
            finalExam.Questions[5] = new MultipleChoiceQuestion(5)
            {
                Header = $"Final Question {6}",
                Body = $"Which of the following data types is used to store decimal numbers in C#?",
                Mark = 3,
                Answers = new Answer[]
                {
                    new Answer(1, "int"),
                    new Answer(2, "float"),
                    new Answer(3, "double"),
                    new Answer(4, "char"),
                    new Answer(5, "bool")
                },
                AnswerRightId = 3
            };
            finalExam.Questions[6] = new TrueFalseQuestion()
            {
                Header = $"Final Question {7}",
                Body = $"In C#, 'null' is a valid value for value types.",
                Mark = 2,
                AnswerRightId = 2
            };
            finalExam.Questions[7] = new MultipleChoiceQuestion(4)
            {
                Header = $"Final Question {8}",
                Body = $"Which keyword is used to inherit a class in C#?",
                Mark = 3,
                Answers = new Answer[]
                {
                    new Answer(1, "this"),
                    new Answer(2, "base"),
                    new Answer(3, "extends"),
                    new Answer(4, ":")
                },
                AnswerRightId = 4
            };
            finalExam.Questions[8] = new TrueFalseQuestion()
            {
                Header = $"Final Question {9}",
                Body = $"The 'static' keyword in C# indicates that a member belongs to the class itself rather than an instance of the class.",
                Mark = 2,
                AnswerRightId = 1
            };
            finalExam.Questions[9] = new MultipleChoiceQuestion(4)
            {
                Header = $"Final Question {10}",
                Body = $"Which of the following is NOT a valid C# loop structure?",
                Mark = 3,
                Answers = new Answer[]
                {
                    new Answer(1, "for"),
                    new Answer(2, "while"),
                    new Answer(3, "foreach"),
                    new Answer(4, "loop-until")
                },
                AnswerRightId = 4
            };
            finalExam.Questions[10] = new TrueFalseQuestion()
            {
                Header = $"Final Question {11}",
                Body = $"In C#, 'const' variables can be changed after their initial assignment.",
                Mark = 2,
                AnswerRightId = 2
            };
            finalExam.Questions[11] = new MultipleChoiceQuestion(4)
            {
                Header = $"Final Question {12}",
                Body = $"What is the purpose of the 'interface' keyword in C#?",
                Mark = 3,
                Answers = new Answer[]
                {
                    new Answer(1, "To define a class"),
                    new Answer(2, "To define a method"),
                    new Answer(3, "To define a contract for classes"),
                    new Answer(4, "To define a namespace")
                },
                AnswerRightId = 3
            };
            finalExam.Questions[12] = new TrueFalseQuestion()
            {
                Header = $"Final Question {13}",
                Body = $"The 'foreach' loop can be used to iterate over arrays and collections in C#.",
                Mark = 4,
                AnswerRightId = 1
            };
            finalExam.Questions[13] = new MultipleChoiceQuestion(3)
            {
                Header = $"Final Question {14}",
                Body = $"Which of the following is NOT a valid C# data type?",
                Answers = new Answer[]
                {
                    new Answer(1, "int"),
                    new Answer(2, "string"),
                    new Answer(3, "number")
                },
                Mark = 2,
                AnswerRightId = 3
            };
            finalExam.Questions[14] = new MultipleChoiceQuestion(4)
            {
                Header = $"Final Question {15}",
                Body = $"What does the 'async' keyword indicate in a method declaration in C#?",
                Mark = 3,
                Answers = new Answer[]
                {
                    new Answer(1, "The method is synchronous"),
                    new Answer(2, "The method can be awaited"),
                    new Answer(3, "The method is static"),
                    new Answer(4, "The method returns void")
                },
                AnswerRightId = 2
            };
            #endregion

            Programming.FinalE = finalExam;

            Console.WriteLine($"Final Exam of Programming Subject");
            Console.WriteLine("===============================\n");

            int userInput;
            foreach (var question in Programming.FinalE.Questions)
            {
                Console.WriteLine(question.ToString());
                Console.Write("Your answer (enter the answer ID): ");

                userInput = int.Parse(Console.ReadLine());
                question.AssignAnswer(userInput);

                Console.WriteLine("--------------------------\n");
            }

            Programming.FinalE.DisplayAfterExam();
            #endregion

            #endregion
        }
}
}
