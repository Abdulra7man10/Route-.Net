using S1;
using System.Collections.Generic;

namespace S2
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = ListGenerator.ProductList;

            #region Element Operators

            /*#region 1
            var firstOutOfStock = products?.FirstOrDefault(p => p.UnitsInStock == 0);
            if (firstOutOfStock != null) { 
                Console.WriteLine($"First out of stock: {firstOutOfStock}");
            }
            else
            {
                Console.WriteLine("All products are in stock.");
            }
            #endregion*/

            /*region 2
            var firstPriceBiggerthan1000 = products?.FirstOrDefault(p => p.UnitPrice > 1000);
            if (firstPriceBiggerthan1000 != null)
            {
                Console.WriteLine($"First product that costs more than $1000: {firstPriceBiggerthan1000}");
            }
            else
            {
                Console.WriteLine("No products cost more than $1000.");
            }
            #endregion*/

            /*#region 3
            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var secondNumberGreaterThan5 = Arr.Where(n => n > 5).Skip(1).FirstOrDefault();
            Console.WriteLine($"The second number greater than 5 is: {secondNumberGreaterThan5}");
            #endregion*/

            #endregion

            string filePath = "dictionary_english.txt";
            string[] dictionary = File.ReadAllLines(filePath);

            #region Aggregate Operators

            /*#region 1
            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var countOddNumbers = Arr.Where(n => n % 2 != 0).Count();
            Console.WriteLine($"The count of odd numbers is: {countOddNumbers}");
            #endregion*/

            /*#region 2
            var costumbersHasOrders = ListGenerator.CustomerList
                .Select(c => new
                {
                    c.CustomerID,
                    c.CustomerName,
                    OrderCount = c.Orders.Length
                });
            foreach (var customer in costumbersHasOrders)
            {
                Console.WriteLine($"CustomerID: {customer.CustomerID}, CustomerName: {customer.CustomerName}, OrderCount: {customer.OrderCount}");
            }
            #endregion*/

            /*region 3
            var categoriesHasProducts = products
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    ProductCount = g.Count()
                });
            foreach (var category in categoriesHasProducts)
            {
                Console.WriteLine($"Category Name: {category.Category}, ProductCount: {category.ProductCount}");
            }
            #endregion*/

            /*#region 4
            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var sumOfNumbers = Arr.Sum();
            Console.WriteLine($"The sum of all numbers is: {sumOfNumbers}");
            #endregion*/

            /*#region 5
            var totalCharacters = dictionary.Sum(w => w.Length);
            Console.WriteLine($"Total number of characters in the dictionary: {totalCharacters}");
            #endregion*/

            /*#region 6
            var shortestWordLength = dictionary.Min(w => w.Length);
            Console.WriteLine($"The length of the shortest word in the dictionary is: {shortestWordLength}");
            #endregion*/

            /*#region 7
            var longestWordLength = dictionary.Max(w => w.Length);
            Console.WriteLine($"The length of the longest word in the dictionary is: {longestWordLength}");
            #endregion*/

            /*#region 8
            var wordsAverage = dictionary.Average(w => w.Length);
            Console.WriteLine($"The Avarage length of the words: {wordsAverage:F2}");
            #endregion*/

            /*#region 9
            var totalUnitsForEachProduct = products
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    TotalUnitsInStock = g.Sum(p => p.UnitsInStock)
                })
                .ToList();
            foreach (var category in totalUnitsForEachProduct)
            {
                Console.WriteLine($"Category: {category.Category}, Total Units In Stock: {category.TotalUnitsInStock}");
            }
            #endregion*/

            /*#region 10
            var cheapestPriceInEachCategory = products
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    CheapestPrice = g.Min(p => p.UnitPrice)
                }).ToList();
            foreach (var category in cheapestPriceInEachCategory)
            {
                 Console.WriteLine($"Category: {category.Category}, Cheapest Price: {category.CheapestPrice:C2}");
            }
            #endregion*/

            /*#region 11
            var cheapestProductsInEachCategory =
                from p in products
                where p.Category != null
                group p by p.Category into g
                let minPrice = g.Min(pro => pro.UnitPrice) // I'm using let :)
                select new
                {
                    Category = g.Key,
                    chPro = g.First(p => p.UnitPrice == minPrice) // only one cheap product needed
                };
            foreach (var cg in cheapestProductsInEachCategory)
            {
                var product = cg.chPro;
                Console.WriteLine($"Category: {cg.Category.PadRight(15)} | {product.ProductName}, Price: {product.UnitPrice:C}");
            }
            #endregion*/

            /*#region 12
            var mostExpensiveProductsInEachCategory = products
                .Where(p => p.Category != null)
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    MostExpensiveProduct = g.Max(p => p.UnitPrice)
                }).ToList();

            foreach (var category in mostExpensiveProductsInEachCategory)
                {
                Console.WriteLine($"Category: {category.Category.PadRight(15)} | Most Expensive Product Price: {category.MostExpensiveProduct:C2}");
            }

            #endregion*/

            /*#region 13
            var mostExpensiveProductsInEachCategory =
                from p in products
                where p.Category != null
                group p by p.Category into g
                let minPrice = g.Max(pro => pro.UnitPrice)
                select new
                {
                    Category = g.Key,
                    chPro = g.First(p => p.UnitPrice == minPrice) // only one most expen. product needed
                };
            foreach (var cg in mostExpensiveProductsInEachCategory)
            {
                var product = cg.chPro;
                Console.WriteLine($"Category: {cg.Category.PadRight(15)} | {product.ProductName}, Price: {product.UnitPrice:C}");
            }
            #endregion*/

            /*#region 14
            var averageProductsInEachCategory = products
                .Where(p => p.Category != null)
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    AveragePrice = g.Average(p => p.UnitPrice)
                }).ToList();

            foreach (var category in averageProductsInEachCategory)
            {
                Console.WriteLine($"Category: {category.Category.PadRight(15)} | Average Price: {category.AveragePrice:C2}");
            }
            #endregion*/

            #endregion

            var customers = ListGenerator.CustomerList;

            #region Set Operators

            /*#region 1
            var uniqueCategoryName = products
                .Select(p => p.Category)
                .Distinct();
            Console.WriteLine("Unique Category Names:");
            foreach (var category in uniqueCategoryName)
            {
                Console.WriteLine(category);
            }
            #endregion*/

            /*#region 2
            var uniqueFirstLetterProductAndCustomer = products
                .Select(p => p.ProductName[0])
                .Union(customers.Select(c => c.CustomerName[0]));
            Console.Write("Unique first letters from Product and Customer names: ");
            foreach (var letter in uniqueFirstLetterProductAndCustomer)
            {
                Console.Write(letter);
            }
            Console.WriteLine();
            #endregion*/

            /*#region 3
            var commonFirstLetterProductAndCustomer = products
                .Select(p => p.ProductName![0])
                .Concat(customers
                    .Select(c => c.CustomerName![0]))
                .GroupBy(letter => letter)
                .Select(g => new
                {
                    Letter = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(x => x.Count)
                .Select(x => x.Letter)
                .FirstOrDefault();

            Console.WriteLine($"Most common first letter between Product and Customer names: {commonFirstLetterProductAndCustomer}");
            #endregion*/

            /*#region 4
            var uniqueFirstLetterProductOnly = products
                .Select(p => p.ProductName[0])
                .Except(customers.Select(c => c.CustomerName[0]));
            Console.Write("First letters from Product names that are not in Customer names: ");
            foreach (var letter in uniqueFirstLetterProductOnly)
            {
                Console.Write(letter);
            }
            #endregion*/

            /*#region 5
            var productLastThree = products
                .Where(p => p.ProductName.Length >= 3)
                .Select(p => p.ProductName.Substring(p.ProductName.Length - 3));

            var customerLastThree = customers
                .Where(c => c.CustomerName.Length >= 3)
                .Select(c => c.CustomerName.Substring(c.CustomerName.Length - 3));

            var commonLastThreeCharacters = productLastThree
                .Intersect(customerLastThree)
                .ToList();
            Console.WriteLine("Common last three characters in Product and Customer names: ");
            foreach (var str in commonLastThreeCharacters)
            {
                Console.WriteLine(str);
            }
            #endregion*/

            #endregion

            #region Partitioning Operators

            /*#region 1
            var first3OrdersCustomersFromWashington = customers
                .Where(c => c.City == "Washington")
                .SelectMany(c => c.Orders)
                .Take(3);
            Console.WriteLine("First 3 orders from customers in Washington:");
            foreach (var order in first3OrdersCustomersFromWashington)
            {
                Console.WriteLine($"OrderID: {order.OrderID}, OrderDate: {order.OrderDate.ToShortDateString()}, Total: {order.Total:C2}");
            }
            #endregion*/

            /*#region 2
            var allButFirst2OrdersCustomersFromWashington = customers
                .Where(c => c.City == "Washington")
                .SelectMany(c => c.Orders)
                .Skip(2);
            Console.WriteLine("All but first 2 orders from customers in Washington:");
            foreach (var order in allButFirst2OrdersCustomersFromWashington)
            {
                Console.WriteLine($"OrderID: {order.OrderID}, OrderDate: {order.OrderDate.ToShortDateString()}, Total: {order.Total:C2}");
            }
            #endregion*/

            /*#region 3
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var allWithStopWhenHitLessThanPosition = numbers.TakeWhile((n, index) => n >= index);
            Console.WriteLine("Numbers from the start of the array until a number is less than its position:");
            foreach (var number in allWithStopWhenHitLessThanPosition)
            {
                Console.WriteLine(number);
            }
            #endregion*/

            /*#region 4
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var arr = numbers.SkipWhile(n => n % 3 != 0);
            foreach (var number in arr)
            {
                Console.WriteLine($"{number}");
            }
            #endregion*/

            /*#region 5
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var arr = numbers.SkipWhile((n, index) => n >= index);
            Console.Write("Numbers in the array starting from the first number that is less than its position:");
            foreach (var number in arr)
            {
                Console.Write($" {number}");
            }
            #endregion*/

            #endregion

            #region Quantifiers

            /*#region 1
            var isHasSubString_ei = dictionary.Any(w => w.Contains("ei"));
            Console.WriteLine($"Is The dictionary has words that contain 'ei'? {isHasSubString_ei}");
            #endregion*/

            /*#region 2
            var productsInCategoryThatHasAtLeastOneProductOut = products
                .GroupBy(p => p.Category)
                .Where(g => g.Any(p => p.UnitsInStock == 0))
                .Select(g => new
                {
                    Category = g.Key,
                    Products = g.ToList()
                }).ToList();
            Console.WriteLine("Categories with at least one product out of stock: ");
            foreach (var category in productsInCategoryThatHasAtLeastOneProductOut)
            {
                Console.WriteLine(category);
                foreach (var product in category.Products)
                {
                    Console.WriteLine($"{product}");
                }
            }
            #endregion*/

            /*#region 3
            var productsInCategoryThatHasAllProductStock = products
                .GroupBy(p => p.Category)
                .Where(g => g.All(p => p.UnitsInStock > 0))
                .Select(g => new
                {
                    Category = g.Key,
                    Products = g.ToList()
                }).ToList();
            Console.WriteLine("Categories with All product in stock: ");
            foreach (var category in productsInCategoryThatHasAllProductStock)
            {
                Console.WriteLine(category);
                foreach (var product in category.Products)
                {
                    Console.WriteLine($"{product}");
                }
                Console.WriteLine("-------------------");
            }
            #endregion*/

            #endregion

            #region Grouping Operators

            /*#region 1
            List<int> numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            var numbersByRemainder = numbers
                .GroupBy(n => n % 5)
                .Select(g => new
                {
                    Remainder = g.Key,
                    Numbers = g.ToList()
                });
            foreach (var group in numbersByRemainder)
            {
                Console.WriteLine($"Numbers with a remainder of {group.Remainder} when divided by 5:");
                foreach (var number in group.Numbers)
                {
                    Console.WriteLine(number);
                }
            }
            #endregion*/

            /*#region 2
            var FirstLetterGrouped = dictionary
                .GroupBy(w => w[0])
                .ToList();
            foreach (var group in FirstLetterGrouped)
            {
                Console.WriteLine($"Letter '{group.Key}': {group.Count()} words");

                Console.WriteLine($"  Example words: {string.Join(", ", group.Take(5))}");
            }
            #endregion*/

            /*#region 3
            string[] Arr = { "from", "salt", "earn", "last", "near", "form" };
            var charLetters = Arr
                .GroupBy(word => new string(word.OrderBy(c => c).ToArray()))
                .ToList();

            foreach (var group in charLetters)
            {
                foreach (var word in group)
                {
                    Console.WriteLine($"{word}");
                }
                Console.WriteLine("....");
            }
            #endregion*/

            #endregion
        }
    }
}
