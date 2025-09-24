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
            /*#region 1
            Console.Write("Enter a number: ");
            int num = Int32.Parse(Console.ReadLine());
            if (num % 3 == 0 || num % 4 == 0)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
            #endregion*/

            /*#region 2
            Console.Write("Enter a number: ");
            int num = Int32.Parse(Console.ReadLine());
            if (num < 0)
                Console.WriteLine("Negative");
            else
            {
                Console.WriteLine("Positive");
            }
            #endregion*/

            /*#region 3
            Console.Write("Enter first number: ");
            int n1 = Int32.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            int n2 = Int32.Parse(Console.ReadLine());

            Console.Write("Enter third number: ");
            int n3 = Int32.Parse(Console.ReadLine());

            Console.WriteLine($"Max element is: {Math.Max(n1, Math.Max(n2, n3))}");
            Console.WriteLine($"Min element is: {Math.Min(n1, Math.Min(n2, n3))}");
            #endregion*/

            /*#region 4
            Console.Write("Enter a number: ");
            int num = Int32.Parse(Console.ReadLine());
            if (num % 2 == 0)
                Console.WriteLine("Even");
            else
            {
                Console.WriteLine("Odd");
            }
            #endregion*/

            /*#region 5
            Console.Write("enter a single letter: ");
            string c = Console.ReadLine();

            char character = char.ToLower(c[0]);

            if (character == 'a' || character == 'e' || character == 'i' || character == 'o' || character == 'u')
            {
                Console.WriteLine("vowel");
            }
            else
            {
                Console.WriteLine("consonant");
            }
            #endregion*/

            /*#region 6
            int num = Int32.Parse(Console.ReadLine());
            for (int i = 1; i <= num; i++)
            {
                Console.Write($"{i} ");
            }
            #endregion*/

            /*#region 7
            int num = Int32.Parse(Console.ReadLine());
            for (int i = 1; i <= 12; i++)
            {
                Console.Write($"{num*i} ");
            }
            #endregion*/

            /*#region 8
            int num = Int32.Parse(Console.ReadLine());
            for (int i = 2; i <= num; i++)
            {
                if (i % 2 == 0)
                    Console.Write($"{i} ");
            }
            #endregion*/

            /*#region 9
            int b = Int32.Parse(Console.ReadLine());
            int o = Int32.Parse(Console.ReadLine());
            int result = 1;
            for (int i = 1; i <= o; i++)
            {
                result *= b;
            }
            Console.WriteLine(result);
            #endregion*/

            /*#region 10
            Console.WriteLine("Enter Marks of five subjects: ");
            int[] s = new int[5];

            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                s[i] = Int32.Parse(Console.ReadLine());
                sum += s[i];
            }

            double average = (double)sum / 5;
            double percentage = average;

            Console.WriteLine($"\nTotal Marks: {sum}");
            Console.WriteLine($"Average Marks: {average}");
            Console.WriteLine($"Percentage: {percentage}%");
            #endregion*/

            /*#region 11
            Console.Write("Enter a month number (1-12): ");
            int monthNumber = Int32.Parse(Console.ReadLine());

            Console.Write("Days in Month: ");
            switch (monthNumber)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    Console.Write("31");
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    Console.WriteLine("30");
                    break;
                case 2:
                    Console.WriteLine("28 or 29");
                    break;
                default:
                    Console.WriteLine("Invalid Month Number");
                    break;
            }
            #endregion*/

            /*#region 12
            Console.Write("first number: ");
            int num1 = Int32.Parse(Console.ReadLine());

            Console.Write("Enter an operator (+, -, *, /): ");
            char op = Console.ReadLine()[0];

            Console.Write("second number: ");
            int num2 = Int32.Parse(Console.ReadLine());

            int result = 0;

            switch (op)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Error: Division by zero is not allowed.");
                    }
                    break;
                default:
                    Console.WriteLine("Error: Invalid operator.");
                    break;
            }
            Console.WriteLine($"Result: {result}");
            #endregion*/

            /*#region 13
            string s = Console.ReadLine();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                Console.Write(s[i]);
            }
            #endregion*/

            /*#region 14
            int n = Int32.Parse(Console.ReadLine());
            int reversedNumber = 0;

            while (n != 0)
            {
                int r = n % 10;
                reversedNumber = reversedNumber * 10 + r;
                n /= 10;
            }
            Console.WriteLine(reversedNumber);
            #endregion*/

            #region 15
            // not solved
            #endregion

            #region 16
            // not solved
            #endregion

            /*#region 17
            Console.WriteLine("first point (x1, y1):");
            Console.Write("x1: ");
            double x1 = double.Parse(Console.ReadLine());
            Console.Write("y1: ");
            double y1 = double.Parse(Console.ReadLine());

            Console.WriteLine("\nsecond point (x2, y2):");
            Console.Write("x2: ");
            double x2 = double.Parse(Console.ReadLine());
            Console.Write("y2: ");
            double y2 = double.Parse(Console.ReadLine());

            Console.WriteLine("\nthird point (x3, y3):");
            Console.Write("x3: ");
            double x3 = double.Parse(Console.ReadLine());
            Console.Write("y3: ");
            double y3 = double.Parse(Console.ReadLine());

            if ((y2 - y1) / (x2 - x1) == (y3 - y2) * (x3 - x2))
            {
                Console.WriteLine("\nstraight line");
            }
            else
            {
                Console.WriteLine("\nnot straight line");
            }
            #endregion*/

            /*#region 18
            Console.WriteLine("Enter time for the task:");
            double hours = double.Parse(Console.ReadLine());

            if (hours > 0 && hours <= 2)
            {
                Console.WriteLine("The worker is highly efficient.");
            }
            else if (hours > 2 && hours <= 3)
            {
                Console.WriteLine("The worker is highly efficient.");
            }
            else if (hours > 3 && hours <= 4)
            {
                Console.WriteLine("The worker is instructed to increase their speed.");
            }
            else if (hours > 4 && hours <= 5)
            {
                Console.WriteLine("The worker is provided with training to enhance their speed.");
            }
            else if (hours > 5)
            {
                Console.WriteLine("The worker is required to leave the company.");
            }
            else
            {
                Console.WriteLine("Invalid time entered.");
            }
            #endregion*/

            #region 19
            // not solved
            #endregion

            /*#region 20
            int[] numbers = { 10, 20, 30, 40, 50 };
            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            Console.WriteLine($"Sum: {sum}");
            #endregion*/

            /*#region 21
            int[] array1 = { 1, 3, 5, 7, 9 };
            int[] array2 = { 2, 4, 6, 8, 10 };
            int size = array1.Length;

            int[] mergedArray = new int[size * 2];

            int i = 0;
            int j = 0;
            int k = 0;

            while (i < size && j < size)
            {
                if (array1[i] < array2[j])
                {
                    mergedArray[k++] = array1[i++];
                }
                else
                {
                    mergedArray[k++] = array2[j++];
                }
            }

            while (i < size)
            {
                mergedArray[k++] = array1[i++];
            }

            while (j < size)
            {
                mergedArray[k++] = array2[j++];
            }

            for (i = 0; i < mergedArray.Length; i++)
            {
                Console.Write(mergedArray[i] + " ");
            }
            #endregion*/

            /*#region 22
            int[] array = { 2, 1, 8, 5, 3, 8, 4, 2 };
            int m = array[0];
            for (int i = 1; i < array.Length - 1; i++)
            {
                if (m < array[i])
                {
                    m = array[i];
                }
            }
            int[] freq = new int[m + 1];

            for (int i = 0; i < array.Length; i++)
            {
                freq[array[i]]++;
            }

            for (int i = 0; i < freq.Length; i++)
            {
                Console.WriteLine($"{i} - {freq[i]} times");
            }
            #endregion*/

            /*#region 23
            int[] numbers = { 5, 2, 8, 1, 9, 4, 7 };

            int max = numbers[0];
            int min = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }

                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }

            Console.WriteLine("Maximum element: " + max);
            Console.WriteLine("Minimum element: " + min);
            #endregion*/

            /*#region 24
            int[] numbers = { 5, 2, 8, 1, 9, 4, 7, 8 };

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

            if (secondLargest == int.MinValue)
            {
                Console.WriteLine("There is no second largest element as all elements are the same");
            }
            else
            {
                Console.WriteLine("The second largest element is: " + secondLargest);
            }
            #endregion*/

            #region 25
            #endregion

            /*#region 26
            Console.WriteLine("Enter a sentence: ");
            string input = Console.ReadLine();

            string[] words = input.Split(' ');

            for (int i = words.Length - 1; i >= 0; i--)
            {
                Console.Write(words[i] + " ");
            }
            #endregion*/

            /*#region 27
            int[] numbers = { 1, 2, 3, 4, 5 };

            Console.WriteLine("Array in reverse order: ");
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine();
            #endregion*/
        }
    }
}
