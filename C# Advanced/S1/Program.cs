using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1
{
    internal class Program
    {
        #region 2
        public static void ReverseArrayList(ArrayList list)
        {
            if (list == null || list.Count < 2)
            {
                return;
            }

            int left = 0;
            int right = list.Count - 1;

            while (left < right)
            {
                object temp = list[left];
                list[left] = list[right];
                list[right] = temp;

                left++;
                right--;
            }
        }
        #endregion

        #region 3
        public static List<int> GetEvenNumbers(List<int> numbers)
        {
            List<int> evenNumbers = new List<int>();

            foreach (int number in numbers)
                if (number % 2 == 0)
                    evenNumbers.Add(number);

            return evenNumbers;
        }
        #endregion

        #region 5
        public static int FirstUnrepeatedChar(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return -1;
            }
            Dictionary<char, int> charCounts = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (charCounts.ContainsKey(c))
                {
                    charCounts[c]++;
                }
                else
                {
                    charCounts[c] = 1;
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (charCounts[c] == 1)
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion
        static void Main(string[] args)
        {
            /*#region 1
            // Integer
            var intRange = new Range<int>(10, 50);

            Console.WriteLine($"Minimum: {intRange.Minimum}, Maximum: {intRange.Maximum}");
            Console.WriteLine($"Length of intRange: {intRange.Length()}");

            Console.WriteLine($"Is 35 in range? {intRange.IsInRange(35)}");
            Console.WriteLine($"Is 60 in range? {intRange.IsInRange(60)}");

            // DateTime
            var startTime = new DateTime(2025, 1, 1);
            var endTime = new DateTime(2025, 1, 31);
            var dateRange = new Range<DateTime>(startTime, endTime);

            Console.WriteLine($"Is 2025-01-15 in range? {dateRange.IsInRange(new DateTime(2025, 1, 15))}");

            #endregion*/

            /*#region 2
            ArrayList myArrayList = new ArrayList { 'A', 1, "Banana", 42, 5.5 };

            Console.WriteLine("Original List:");
            foreach (var item in myArrayList)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            ReverseArrayList(myArrayList);

            Console.WriteLine("\nReversed List (in-place):");
            foreach (var item in myArrayList)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            #endregion*/

            /*#region 3
            List<int> data = new List<int> { 1, 15, 22, 37, 40, 51, 68, 79, 84 };
            List<int> result = GetEvenNumbers(data);

            Console.WriteLine("Original Data: " + string.Join(", ", data));
            Console.WriteLine("Even Numbers Found: " + string.Join(", ", result));
            #endregion*/

            #region 4
            var fixedList = new FixedSizeList<string>(3);

            try
            {
                fixedList.Add("Apple");
                fixedList.Add("Banana");
                Console.WriteLine($"Added 2 items. Current Count: {fixedList.Count}");

                Console.WriteLine($"Item at index 1: {fixedList.Get(1)}");

                fixedList.Add("Cherry");
                Console.WriteLine($"Added 3rd item. Current Count: {fixedList.Count}");

                fixedList.Add("Date"); // error
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"\n[Capacity Error] {ex.Message}");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"\n[Index Error] {ex.Message}");
            }

            try
            {
                Console.WriteLine(fixedList.Get(3));
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"\n[Index Error] {ex.Message}");
            }
            #endregion

            /*#region 5
            string s1 = "abcdbcz";
            int index1 = FirstUnrepeatedChar(s1);
            Console.WriteLine($"String: '{s1}', First unique index: {index1}");

            string s2 = "aabcdabdd";
            int index2 = FirstUnrepeatedChar(s2);
            Console.WriteLine($"String: '{s2}', First unique index: {index2}");
            #endregion*/
        }
    }
}
