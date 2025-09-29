using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5
{
    internal class Program
    {
        #region 1 and 2
        public static void PassByValue(int number)
        {
            Console.WriteLine($"Inside PassByValue before change: {number}");
            number = number + 10;
            Console.WriteLine($"Inside PassByValue after change: {number}");
        }

        public static void PassByReference(ref int number)
        {
            Console.WriteLine($"Inside PassByReference before change: {number}");
            number = number + 10;
            Console.WriteLine($"Inside PassByReference after change: {number}");
        }
        #endregion

        #region 3
        public static int total(int n1, int n2, int n3, int n4)
        {
            return n1 + n2 - n3 - n4;
        }
        #endregion

        #region 4
        public static int totalDigits(int num)
        {
            string n = num.ToString();
            int result = 0;
            for (int i = 0; i < n.Length; i++)
            {
                result += n[i] - '0';
            }

            return result;
        }
        #endregion

        #region 5
        public static bool IsPrime(int number)
        {

            if (number == 2)
            {
                return true;
            }

            if (number % 2 == 0 || number <= 1)
            {
                return false;
            }

            for (int i = 3; i * i <= number; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region 6
        public static int[] MinMaxArray(int[] arr)
        {
            int[] result = new int[2];
            result[0] = arr.Min();
            result[1] = arr.Max();
            return result;
        }
        #endregion

        #region 7
        public static long Fac(int n)
        {
            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
        #endregion

        #region 8
        public static void changeLetter(ref string s, int pos, char newChar)
        {
            char[] c = s.ToCharArray();
            c[pos] = newChar;
            s = new string(c);
        }
        #endregion

        #region 9
        public static int SumArray(int[] arr)
        {
            int result = 0;
            foreach (int n in arr)
            {
                result += n;
            }
            return result;
        }
        #endregion

        #region 10
        public static int[] merge(int[] arr1, int[] arr2)
        {
            int size = arr1.Length;

            int[] mergedArray = new int[size * 2];

            int i = 0;
            int j = 0;
            int k = 0;

            while (i < size && j < size)
            {
                if (arr1[i] < arr2[j])
                {
                    mergedArray[k++] = arr1[i++];
                }
                else
                {
                    mergedArray[k++] = arr2[j++];
                }
            }

            while (i < size)
            {
                mergedArray[k++] = arr1[i++];
            }

            while (j < size)
            {
                mergedArray[k++] = arr2[j++];
            }

            return mergedArray;
        }
        #endregion

        #region 11
        public static int[] freqency(int[] arr)
        {
            int m = arr[0];
            for (int i = 1; i < arr.Length - 1; i++)
            {
                if (m < arr[i])
                {
                    m = arr[i];
                }
            }
            int[] freq = new int[m + 1];

            for (int i = 0; i < arr.Length; i++)
            {
                freq[arr[i]]++;
            }

            return freq;
        }
        #endregion

        #region 12
        // The same as 6
        #endregion

        #region 13
        public static int secondLargest(int[] numbers)
        {
            int largest = int.MinValue;
            int secondLargest = int.MinValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > largest)
                {
                    secondLargest = largest;
                    largest = numbers[i];
                }
                else if (numbers[i] > secondLargest && numbers[i] != largest)
                {
                    secondLargest = numbers[i];
                }
            }
            return secondLargest;
        }
        #endregion

        #region 14
        public static void FindLongestDistance(int[] arr)
        {

            int longestDistance = -1;
            int value = -1;
            int finalFirstIndex = -1;
            int finalLastIndex = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        int currentDistance = j - i - 1;
                        if (currentDistance > longestDistance)
                        {
                            longestDistance = currentDistance;
                            value = arr[i];
                            finalFirstIndex = i;
                            finalLastIndex = j;
                        }
                    }
                }
            }

            if (longestDistance < 0)
            {
                Console.WriteLine("\nResult: No repeated elements.");
            }
            else
            {
                Console.WriteLine($"The longest distance is: {longestDistance}");
                Console.WriteLine($"This distance is between the number {value}:");
                Console.WriteLine($"- First occurrence (Index {finalFirstIndex})");
                Console.WriteLine($"- Last occurrence (Index {finalLastIndex})");
            }
        }
        #endregion

        #region 15
        public static void reverseSentence(string sent)
        {
            string[] words = sent.Split(' ');

            for (int i = words.Length - 1; i >= 0; i--)
            {
                Console.Write(words[i] + " ");
            }
            Console.WriteLine();
        }
        #endregion

        #region 16
        public static void PopulateArray(int[,] array, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int value;
                    Console.Write($"Enter element at [{i},{j}]: ");

                    while (!int.TryParse(Console.ReadLine(), out value))
                    {
                        Console.Write("Invalid input. Enter an integer: ");
                    }
                    array[i, j] = value;
                }
            }
        }

        public static void CopyArray(int[,] source, int[,] destination, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    destination[i, j] = source[i, j];
                }
            }
        }

        public static void PrintArray(int[,] array, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{array[i, j],5}");
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region 17
        public static void Print1DArray(int[] array, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }
        #endregion

        static void Main(string[] args)
        {
            #region 1 and 2
            // Passing by value means the method receives a copy
            // Passing by reference receives a pointer to the original variable's memory location
            /*
            int number = 1;
            PassByValue(number);
            Console.WriteLine($"after method calls: {number}\n\n");
            PassByReference(ref number);
            Console.WriteLine($"after method calls: {number}");
            */
            #endregion

            #region 3
            //Console.WriteLine(total(2, 4, 1, 3));
            #endregion

            #region 4
            //Console.WriteLine(totalDigits(15));
            #endregion

            #region 5
            //Console.WriteLine(IsPrime(29));
            #endregion

            #region 6
            //int[] a = MinMaxArray(new int[] { 1, 2, 3, 4, -5, 6 });
            //Console.WriteLine($"Min: {a[0]}, Max: {a[1]}");
            #endregion

            #region 7
            //Console.WriteLine(Fac(4));
            #endregion

            #region 8
            //string s = "hello";
            //changeLetter(ref s, 0, 'H');
            //Console.WriteLine(s);
            #endregion

            #region 9
            //int[] a = new int[] { 1, 2, 3, 4, 5 };
            //Console.WriteLine(SumArray(a));
            #endregion

            #region 10
            //int[] arr1 = { 1, 3, 5, 7, 9 };
            //int[] arr2 = { 2, 4, 6, 8, 10 };
            //int[] mergedArray = merge(arr1, arr2);

            //for (int i = 0; i < mergedArray.Length; i++)
            //{
            //   Console.Write(mergedArray[i] + " ");
            //}
            #endregion

            #region 11
            //int[] arr = { 2, 1, 8, 5, 3, 8, 4, 2 };
            //int[] freq = freqency(arr);
            //for (int i = 0; i < freq.Length; i++)
            //{
            //   Console.WriteLine($"{i} - {freq[i]} times");
            // }
            #endregion

            #region 12
            //int[] a = MinMaxArray(new int[] { 1, 2, 3, 4, -5, 6 });
            //Console.WriteLine($"Min: {a[0]}, Max: {a[1]}");
            #endregion

            #region 13
            /*int[] numbers = { 5, 2, 8, 1, 9, 4, 7, 8 };
            int sLN = secondLargest(numbers);
            if (sLN == int.MinValue)
            {
                Console.WriteLine("There is no second largest element as all elements are the same");
            }
            else
            {
                Console.WriteLine("The second largest element is: " + sLN);
            }*/
            #endregion

            #region 14
            //int[] arr = new int[] { 7, 0, 0, 0, 5, 6, 7, 5, 0, 7, 5, 3 };
            //FindLongestDistance(arr);
            #endregion

            #region 15
            //string input = Console.ReadLine();
            //reverseSentence(input);
            #endregion

            #region 16
            /*int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            int[,] arr1 = new int[rows, cols];
            PopulateArray(arr1, rows, cols);

            int[,] arr2 = new int[rows, cols];
            CopyArray(arr1, arr2, rows, cols);

            PrintArray(arr2, rows, cols);*/
            #endregion

            #region 17
            //Print1DArray(new int[] { 1, 2, 3, 4, 5 }, 5);
            #endregion
        }
    }
}