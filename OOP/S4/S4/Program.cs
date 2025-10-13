using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*#region 1-5
            BaseClass o1 = new DerivedClass1();
            BaseClass o2 = new DerivedClass2();

            o1.DisplayMessage();
            o2.DisplayMessage();
            Console.WriteLine();

            DerivedClass2 realO2 = new DerivedClass2();
            realO2.DisplayMessage();
            #endregion*/

            /*#region 2-3
            Duration D1 = new Duration(1, 10, 15);
            Console.WriteLine(D1.ToString());
            // Output: Hours: 1, Minutes :10, Seconds :15

            Duration D2 = new Duration(3600);
            Console.WriteLine(D2.ToString());
            // Output: Hours: 1, Minutes :0, Seconds :0

            Duration D3 = new Duration(7800);
            Console.WriteLine(D3.ToString());
            // Output: Hours: 2, Minutes :10, Seconds :0

            Duration D4 = new Duration(666);
            Console.WriteLine(D4.ToString());
            // Output: Minutes :11, Seconds :6
            #endregion*/

            #region 2-4
            Duration D1 = new Duration(1, 10, 15);
            Duration D2 = new Duration(7800);  // 2h 10m 0s
            Duration D3;

            D3 = D1 + D2;
            Console.WriteLine(D3);  // 3h 20m 15s

            D3 = D1 + 7800;
            Console.WriteLine(D3);  // 3h 20m 15s

            D3 = 666 + D3;
            Console.WriteLine(D3);  // 3h 31m 21s

            D3 = ++D1;
            Console.WriteLine(D3);  // 1h 11m 15s

            D3 = --D2;
            Console.WriteLine(D3);  // 2h 9m 0s

            D1 = D1 - D2;
            Console.WriteLine(D1);

            if (D1 > D2)
                Console.WriteLine("D1 is greater than D2");
            else if (D1 <= D2)
                Console.WriteLine("D1 is less than or equal to D2");

            if (D1)
                Console.WriteLine("D1 is not zero");

            DateTime Obj = (DateTime)D1;
            Console.WriteLine($"DateTime: {Obj}");
            #endregion
        }
    }
}
