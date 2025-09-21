using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*#region Q1
            Console.Write("Enter a number: ");
            int num = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Your number is {num}");
            #endregion*/

            /*#region Q2
            string s = "hello";
            int i = Convert.ToInt32(s); // this will throw an error, becuase it's non-numeric string
            Console.WriteLine(i);
            #endregion*/

            /*#region Q3
            float f1 = 1.1f;
            float f2 = 1.1f;
            Console.WriteLine(f1 + f2); // print 2.2
            #endregion*/

            /*#region Q4
            string s = "hello";
            Console.WriteLine(s.Substring(1,3));
            #endregion*/

            /*#region Q5
            int o = 5;
            int c = o;
            Console.WriteLine(o); // 5
            Console.WriteLine(c); // 5

            o = 10; // only change o, but c only takes the value 
            Console.WriteLine(o); // 10
            Console.WriteLine(c); // 5
            #endregion*/

            /*#region Q6
            int[] o = new int[] {5};
            int[] c = o;
            Console.WriteLine(o[0]); // 5
            Console.WriteLine(c[0]); // 5

            o[0] = 10; // now it's changed for both, because this is a pointer for reference
            Console.WriteLine(o[0]); // 10
            Console.WriteLine(c[0]); // 10
            #endregion */

            /*#region Q7
            string s1 = "hello ";
            string s2 = "world";
            string res = s1 + s2; 
            Console.WriteLine(res); // hello world
            #endregion*/

            /*#region Q8
            double principal = 1000;
            double rate = 5;
            double time = 3;
            double Interest = (principal * rate * time) / 100;
            Console.WriteLine(Interest); // 150
            #endregion*/

            /*#region Q9
            double Weight = 70;
            double Height = 1.75;
            double BMI = (Weight) / (Height * Height);
            Console.WriteLine(BMI);
            #endregion*/

            /*#region Q10
            double temp = 3;
            string des = (temp < 10)? "Cold" : (temp > 30)? "Hot" : "Good";
            Console.WriteLine(des);
            #endregion*/

            /*#region Q11
            DateTime date = new DateTime(2001, 11, 20); 
            Console.WriteLine($"Today’s date: {date:dd , MM , yyyy}");
            Console.WriteLine($"Today’s date: {date:dd / MM / yyyy}");
            Console.WriteLine($"Today’s date: {date:dd - MM - yyyy}");
            #endregion*/

            /*#region Q12
            DateTime date = new DateTime(2024, 6, 14); 
            Console.WriteLine($"The event is on {date:MM/dd/yyyy}"); // C) The event is on 06/14/2024
            #endregion*/

            /*#region Q13
            int d;
            d = Convert.ToInt32(!(30 < 20));
            Console.WriteLine(d); // F) A value 1 will be assigned to d.
            #endregion*/

            /*#region Q14
            Console.WriteLine(13 / 2 + " " + 13 % 2); // D) 6 1
            #endregion*/

            /*#region Q15
            int num = 1, z = 5;
            if (!(num <= 0))
                Console.WriteLine(++num + z++ + " " + ++z); // this here, D) 7 7 , because ++num is 2 and z++ is 5 then add 2 + 5 = 7, ++z is 7
            else
                Console.WriteLine(--num + z-- + " " + --z);

            #endregion*/
        }
    }
}
