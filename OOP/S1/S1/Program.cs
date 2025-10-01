using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* part1 task (to apply what we 've learned) -> I 've added some concepts 
               from session in enums and classes like (constructors, propeties, ...) 
            */

            /*#region 1
            Console.WriteLine("--- Days of the Week ---");

            Array days = Enum.GetValues(typeof(WeekDays));
            foreach (WeekDays day in days)
            {
                Console.WriteLine(day.ToString());
            }

            Console.WriteLine("------------------------");
            #endregion*/

            /*#region 2
            Person[] people = new Person[3];
            people[0].Name = "Ahmed";
            people[0].Age = 30;
            people[1].Name = "Basem";
            people[1].Age = 27;
            people[2].Name = "Shahd";
            people[2].Age = 21;

            foreach (Person person in people)
            {
                person.Print();
            }
            #endregion*/

            /*#region 3
            Console.Write("Enter Season name: ");
            string str = Console.ReadLine();

            if (Enum.TryParse(str, true, out Season s))
            {
                string r = s.ToString() == "Spring" ? "March to May" : s.ToString() == "Summer" ? "June to Aug" : s.ToString() == "Autumn" ? "Sep to Nov" : s.ToString() == "Winter" ? "Dec to Feb" : "No range";
                Console.WriteLine($"The month range for {s} is: {r}");
            }
            else
            {
                Console.WriteLine($"Error: '{str}' is not a valid season name :(");
            }

            #endregion*/

            /*#region 4
            Permissions Uper = Permissions.Write | Permissions.Delete;
            if (Uper.HasFlag(Permissions.Write))
            {
                Console.WriteLine("User has Write permission :)");
            }
            else
            {
                Console.WriteLine("User does not have Write permission :(");
            }

            if (Uper.HasFlag(Permissions.Delete))
            {
                Console.WriteLine("User has Delete permission :)");
            }
            else
            {
                Console.WriteLine("User does not have Delete permission :(");
            }
            #endregion*/

            /*#region 5
            Console.Write("Enter Color Primary or not: ");
            string str = Console.ReadLine();

            if (Enum.TryParse(str, true, out Color c))
            {
                Console.WriteLine($"{c} is a Primary color");
            }
            else
            {
                Console.WriteLine($"{c} is not a Primary color");
            }
            #endregion*/

            #region 6
            Point p = new Point();
            Console.Write("Enter X: ");
            p.x= int.Parse(Console.ReadLine());
            Console.Write("Enter Y: ");
            p.y = int.Parse(Console.ReadLine());

            Console.WriteLine($"Points {p.ToString()} its distance: {Math.Abs(p.x-p.y)}");
            #endregion

            /*#region 7
            Person[] people = new Person[3];
            for (int i = 0; i<people.Length; i++)
            {
                Console.WriteLine($"Enter person's {i} data:-");

                Console.Write("Name: ");
                people[i].Name = Console.ReadLine();

                Console.Write("Age: ");
                people[i].Age = int.Parse(Console.ReadLine());

                Console.WriteLine();
            }

            int oldest = 0;
            for (int i = 1; i < people.Length; i++)
            {
                if (people[i].Age > people[oldest].Age)
                {
                    oldest = i;
                }
            }
            Console.WriteLine("\n--Oldest person date :-");
            people[oldest].Print();
            #endregion*/
        }
    }
}
