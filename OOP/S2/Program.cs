using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*#region 1
            Person[] ArrP = new Person[3];
            ArrP[0].name = "Ali";
            ArrP[0].age = 20;
            ArrP[1].name = "Fadi";
            ArrP[1].age = 25;
            ArrP[2].name = "Omar";
            ArrP[2].age = 30;

            foreach (var item in ArrP)
            {
                Console.WriteLine(item.ToString());
            }
            #endregion*/

            /*#region 2
            Point p = new Point();
            Console.Write("Enter X value: ");
            p.x = int.Parse(Console.ReadLine());
            Console.Write("Enter Y value: ");
            p.y = int.Parse(Console.ReadLine());
            Console.WriteLine($"Distance between x and y: {p.distnanceP()}");
            #endregion*/

            /*#region 3
            Person[] ArrP = new Person[3];

            for (int i = 0; i < ArrP.Length; i++)
            {
                Console.Write($"Enter name of person {i + 1}: ");
                ArrP[i].name = Console.ReadLine();
                Console.Write($"Enter age of person {i + 1}: ");
                ArrP[i].age = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }
            
            Console.WriteLine();
            foreach (var item in ArrP)
            {
                Console.WriteLine(item.ToString());
            }
            #endregion*/

            #region 4
            Rectangle rect = new Rectangle();
            rect.width = 5;
            //rect.height = -10;
            rect.height = 10;
            rect.DisplayInfo();
            #endregion
        }
    }
}
