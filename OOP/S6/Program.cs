using S6.First;
using S6.Second;
using S6.Third;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S6
{
    internal class Program
    {
        #region 1
        static int ReadCoordinate(string name)
        {
            int coord;
            while (true)
            {
                Console.Write($"Enter {name} coordinate: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out coord))
                {
                    return coord;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }
        }

        static Point3D ReadPoint(string pointName)
        {
            Console.WriteLine($"\n--- Reading Coordinates for {pointName} ---");
            int x = ReadCoordinate("X");
            int y = ReadCoordinate("Y");
            int z = ReadCoordinate("Z");
            return new Point3D(x, y, z);
        }
        #endregion

        #region 3
        private static User GetUserType(string name)
        {
            while (true)
            {
                Console.WriteLine("\nPlease enter User Type (Regular, Premium, or Guest):");
                string userInput = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;

                switch (userInput)
                {
                    case "regular":
                        return new RegularUser(name);
                    case "premium":
                        return new PremiumUser(name);
                    case "guest":
                        return new GuestUser(name);
                    default:
                        Console.WriteLine("Invalid input. Please enter 'Regular', 'Premium', or 'Guest'.");
                        break;
                }
            }
        }

        private static (decimal price, int quantity) GetProductDetails()
        {
            decimal price = 0;
            int quantity = 0;

            while (true)
            {
                Console.Write("Enter product price: $");
                if (decimal.TryParse(Console.ReadLine(), out price) && price > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid price. Please enter a valid positive number.");
            }

            while (true)
            {
                Console.Write("Enter quantity: ");
                if (int.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid quantity. Please enter a valid positive integer.");
            }

            return (price, quantity);
        }
        #endregion
        static void Main(string[] args)
        {
            #region 1
            /*#region equal
            Point3D p1 = ReadPoint("P1");
            Point3D p2 = ReadPoint("P2");

            Console.WriteLine($"\n--- Checking P1 == P2 ---");

            if (p1 == p2)
            {
                Console.WriteLine("P1 is equal P2");
            }
            else
            {
                Console.WriteLine("P1 != P2");
            }
            #endregion*/

            /*#region sort
            Point3D[] points = new Point3D[]
            {
            new Point3D(5, 10, 5),
            new Point3D(1, 5, 10),
            new Point3D(5, 5, 20),
            new Point3D(10, 1, 30),
            new Point3D(1, 10, 40)
            };

             Console.WriteLine("--- Original Array ---");
            foreach (var point in points)
            {
                Console.WriteLine(point.ToString());
            }

            Array.Sort(points);

            Console.WriteLine("--- Sorted Array (by X then Y then Z) ---");
            foreach (var point in points)
            {
                Console.WriteLine(point.ToString());
            }
            #endregion*/

            /*#region clone
            Point3D originalPoint = new Point3D(100, 200, 300);
            Point3D clonedPoint = (Point3D)originalPoint.Clone();

            Console.WriteLine($"Original: {originalPoint.ToString()}");
            Console.WriteLine($"Cloned: {clonedPoint.ToString()}");

            Console.WriteLine($"ReferenceEquals(Original, Cloned): {ReferenceEquals(originalPoint, clonedPoint)}");

            clonedPoint.X = 999;
            Console.WriteLine("\nAfter modifying clone's X coordinate:");
            Console.WriteLine($"Original: {originalPoint.ToString()} (Unchanged)");
            Console.WriteLine($"Cloned: {clonedPoint.ToString()} (Changed)");
            #endregion*/
            #endregion

            /*#region 2
            int val1 = 20;
            int val2 = 5;
            int val3 = 3;

            Console.WriteLine($"Add({val1}, {val2}) = {Maths.Add(val1, val2)}");

            Console.WriteLine($"Subtract({val1}, {val2}) = {Maths.Subtract(val1, val2)}");

            Console.WriteLine($"Multiply({val2}, {val3}) = {Maths.Multiply(val2, val3)}");

            Console.WriteLine($"Divide({val1}, {val3}) = {Maths.Divide(val1, val3)}");

            Console.Write($"Divide({val1}, 0): ");
            Maths.Divide(val1, 0);
            #endregion*/

            #region 3
            Console.WriteLine("--- E-commerce Discount Calculator System ---");

            Console.Write("Enter user's name: ");
            string userName = Console.ReadLine();

            User currentUser = GetUserType(userName);
            if (currentUser == null)
            {
                Console.WriteLine("Exiting program due to invalid user type.");
                return;
            }

            (decimal price, int quantity) = GetProductDetails();
            if (price <= 0 || quantity <= 0)
            {
                Console.WriteLine("Price and quantity must be greater than zero. Calculation aborted.");
                return;
            }

            Discount discountStrategy = currentUser.GetDiscount();

            decimal originalTotal = price * quantity;
            decimal discountAmount = discountStrategy.CalculateDiscount(price, quantity);

            discountAmount = Math.Min(discountAmount, originalTotal); // if discount greater than total price

            decimal finalPrice = originalTotal - discountAmount;

            Console.WriteLine("\n=============================================");
            Console.WriteLine($"User: {currentUser.Name} ({currentUser.GetType().Name})");
            Console.WriteLine($"Original Total Price: ${originalTotal:N2}");
            Console.WriteLine($"Discount Applied: {discountStrategy.Name}");
            Console.WriteLine($"Total Discount Amount: -${discountAmount:N2}");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"Final Price: ${finalPrice:N2}");
            Console.WriteLine("=============================================");
            #endregion
        }
    }
}
