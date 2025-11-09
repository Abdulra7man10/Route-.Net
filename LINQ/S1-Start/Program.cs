using S1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace S1_Start
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 
            #endregion
            List<Product> products = ListGenerator.ProductList;

            #region Restriction Operators
            /*#region Out Of Stock
            List<Product> productsOutofStock = products
                .Where(p => p.UnitsInStock == 0)
                .ToList();
            productsOutofStock.ForEach(p => { 
                Console.WriteLine($"ID: {p.ProductID}, Name: {p.ProductName}, Stock: {p.UnitsInStock}"); 
            });
            #endregion*/

            /*#region In Stock and Cost more than 3
            List<Product> productsInStockMoreThan3 = products
                .Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3M)
                .ToList();
            productsInStockMoreThan3.ForEach(p => {
                Console.WriteLine($"ID: {p.ProductID}, Name: {p.ProductName}, Stock: {p.UnitsInStock}, Price: {p.UnitPrice}");
            });
            #endregion*/

            /*#region digits whose name is shorter than their value
            string[] arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            List<string> digitsShorterThanValue = arr.Where(w => w.Length < Array.IndexOf(arr, w))
                .ToList();

            digitsShorterThanValue.ForEach(w => Console.WriteLine(w));
            #endregion*/
            #endregion

            #region Ordering Operators

            /*#region Order Products by Name
            List<Product> productsOrderedByName = products
                .OrderBy(p => p.ProductName)
                .ToList();
            productsOrderedByName.ForEach(p => Console.WriteLine($"{p.ProductName}"));
            #endregion*/

            /*#region 2
            String[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            List<string> sortedArr = Arr
                .OrderBy(s => s, StringComparer.OrdinalIgnoreCase)
                .ToList();
            sortedArr.ForEach(s => Console.WriteLine(s));
            #endregion*/

            /*#region Sort products by units in stock
            List<Product> productsSortedByUnitsInStock = products
                .OrderByDescending(p => p.UnitsInStock)
                .ToList();
            productsSortedByUnitsInStock.ForEach(p => Console.WriteLine($"Name: {p.ProductName}, UnitsInStock: {p.UnitsInStock}"));
            #endregion*/

            /*#region 4
            string[] arr = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
            List<string> sortedArr = arr
                .OrderByDescending(s => s.Length)
                .ThenBy(s => s)
                .ToList();
            sortedArr.ForEach(s => Console.WriteLine(s));
            #endregion*/

            /*#region 5
            String[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            List<string> sortedArr = Arr
                .OrderByDescending(s => s.Length)
                .ThenBy(s => s, StringComparer.OrdinalIgnoreCase)
                .ToList();
            sortedArr.ForEach(s => Console.WriteLine(s));
            #endregion*/

            /*#region sort by category, then by unit price
            List<Product> productsSortedByCategoryThenByPrice = products
                .Where(p => p.Category != null)
                .OrderBy(p => p.Category)
                .ThenByDescending(p => p.UnitPrice)
                .ToList();
            productsSortedByCategoryThenByPrice.ForEach(p => Console.WriteLine($"Category: {p.Category}, Name: {p.ProductName}, Price: {p.UnitPrice}"));
            #endregion*/

            /*#region 7
            String[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            List<string> sortedArr = Arr
                .OrderBy(s => s.Length)
                .ThenByDescending(s => s, StringComparer.OrdinalIgnoreCase)
                .ToList();
            sortedArr.ForEach(s => Console.WriteLine(s));
            #endregion*/

            /*#region 8
            string[] Arr = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
            List<string> sortedArr = Arr
                .Where(s => s[1]=='i')
                .Reverse()
                .ToList();
            sortedArr.ForEach(s => Console.WriteLine(s));
            #endregion*/

            #endregion

            #region Transformation Operators

            /*#region sequence of the names of products
            List<string> productNames = products
                .Where(p => p.ProductName != null)
                .Select(p => p.ProductName)
                .ToList();
            productNames.ForEach(n => Console.WriteLine(n));
            #endregion*/

            /*#region 2
            String[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            List<string> upperWords = words
                .Select(w => w.ToUpper())
                .ToList();
            upperWords.ForEach(w => Console.WriteLine(w));

            Console.WriteLine("\n--------------\n");

            List<string> lowerWords = words
                .Select(w => w.ToLower())
                .ToList();
            lowerWords.ForEach(w => Console.WriteLine(w));
            #endregion*/

            /*#region UnitPrice which is renamed to Price in the resulting type
            var productsRename = products
                .Select(p => new
                {
                    p.ProductName,
                    Price = p.UnitPrice
                })
                .ToList();
            productsRename.ForEach(p => Console.WriteLine($"Name: {p.ProductName}, Price: {p.Price}"));
            #endregion*/

            /*#region 4
            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var MatchIndexOrNot = Arr
                .Select((value, index) => new
                {
                    Value = value,
                    IsMatch = (value == index)
                })
                .ToList();
            MatchIndexOrNot.ForEach(n => Console.WriteLine($"{n.Value}: {n.IsMatch}"));
            #endregion*/

            /*#region 5
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var pairs = numbersA
                .SelectMany(
                    a => numbersB,
                    (a, b) => new
                    {
                        A = a,
                        B = b,
                        isLess = a < b
                    }
                ).Where(pair => pair.isLess).ToList();

            pairs.ForEach(p => Console.WriteLine($"{p.A} is less than {p.B}"));

            #endregion*/


            List<Order> orders = ListGenerator.CustomerList
                .SelectMany(c => c.Orders)
                .ToList();

            /*#region Orders with total less than 500
            List<Order> OrderLessThan500 = orders
                .Where(o => o.Total < 500M)
                .OrderBy(o => o.Total)
                .ToList();
            OrderLessThan500.ForEach(o => Console.WriteLine($"OrderID: {o.OrderID}, Total: {o.Total}"));
            #endregion*/

            /*#region order was made in 1998 or later
            List<Order> Orders1998OrLater = orders
                .Where(o => o.OrderDate.Year >= 1998)
                .OrderBy(o => o.OrderDate)
                .ToList();
            Orders1998OrLater.ForEach(o => Console.WriteLine($"OrderID: {o.OrderID}, OrderDate: {o.OrderDate.ToShortDateString()}"));
            #endregion*/

            #endregion
        }
    }
}
