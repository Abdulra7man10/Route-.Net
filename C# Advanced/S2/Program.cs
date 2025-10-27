using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2
{
    internal class Program
    {
        #region 1
        public static void OptimisedBubbleSort(int[] arr)
        {
            int n = arr.Length;
            bool swapped = false;

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;

                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;

                        swapped = true;
                    }
                }

                // when it's not swapped, means the array is sorted
                if (swapped == false)
                {
                    break;
                }
            }
        }
        #endregion

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
        public static int CountGreaterNumbers(int[] arr, int x)
        {
            int count = 0;

            foreach (int number in arr)
                if (number > x)
                    count++;

            return count;
        }
        #endregion

        #region 4
        public static bool IsPalindrome(int[] arr)
        {
            if (arr == null)
            {
                return true;
            }

            int left = 0;
            int right = arr.Length - 1;

            while (left < right)
            {
                if (arr[left] != arr[right])
                {
                    return false;
                }
                left++;
                right--;
            }

            return true;
        }
        #endregion

        #region 5
        public static void ReverseQueue<T>(Queue<T> queue)
        {
            if (queue == null || queue.Count <= 1)
            {
                return;
            }

            Stack<T> stack = new Stack<T>();
            while (queue.Count > 0)
            {
                stack.Push(queue.Dequeue());
            }

            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }
        }
        #endregion

        #region 6
        public static bool IsParenthesesBalanced(string s)
        {
            Stack<char> expectedClosers = new Stack<char>();

            foreach (char c in s)
            {
                if (c == '(')
                {
                    expectedClosers.Push(')');
                }
                else if (c == '{')
                {
                    expectedClosers.Push('}');
                }
                else if (c == '[')
                {
                    expectedClosers.Push(']');
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (expectedClosers.Count == 0)
                    {
                        return false;
                    }

                    char expected = expectedClosers.Pop();
                    if (c != expected)
                    {
                        return false;
                    }
                }
            }

            return expectedClosers.Count == 0;
        }
        #endregion

        #region 7
        public static int[] RemoveDuplicates(int[] arr)
        {
            List<int> uniqueList = new List<int>();

            foreach (int number in arr)
            {
                if (!uniqueList.Contains(number))
                {
                    uniqueList.Add(number);
                }
            }

            return uniqueList.ToArray();
        }
        #endregion

        #region 8
        public static List<int> GetNoOddNumbers(List<int> numbers)
        {
            List<int> evenNumbers = new List<int>();

            foreach (int number in numbers)
                if (number % 2 == 0)
                    evenNumbers.Add(number);

            return evenNumbers;
        }
        #endregion

        #region 10
        public static int SearchStack(Stack<int> stack, int target)
        {
            int count = 0;
            bool found = false;

            foreach (int element in stack)
            {
                count++;

                if (element == target)
                {
                    found = true;
                    break;
                }
            }

            if (found)
                return count;
            return -1;
        }
        #endregion

        #region 11
    public static int[] Intersect(int[] arr1, int[] arr2)
        {

            Dictionary<int, int> counts = new Dictionary<int, int>();

            foreach (int num in arr1)
            {
                if (counts.ContainsKey(num))
                    counts[num]++;

                else
                    counts[num] = 1;
            }

            List<int> intersection = new List<int>();

            foreach (int num in arr2)
            {
                if (counts.ContainsKey(num) && counts[num] > 0)
                {
                    intersection.Add(num);
                    counts[num]--;
                }
            }

            return intersection.ToArray();
        }
        #endregion

        #region 12
        public static List<int> FindSublistWithSum(ArrayList arrayList, int target)
        {
            List<int> arr = new List<int>();
            foreach (object item in arrayList)
            {
                arr.Add(Convert.ToInt32(item));
            }

            int n = arr.Count;
            int currentSum = 0;
            int start = 0; 

            for (int end = 0; end < n; end++)
            {
                currentSum += arr[end];

                while (currentSum > target && start <= end)
                {
                    currentSum -= arr[start];
                    start++;
                }

                if (currentSum == target)
                {
                    return arr.GetRange(start, end - start + 1);
                }
            }

            return new List<int>();
        }
        #endregion

        #region 13
        public static void ReverseFirstKElements<T>(Queue<T> queue, int k)
        {
            int n = queue.Count;

            if (k < 0 || k > n)
            {
                throw new ArgumentOutOfRangeException(nameof(k), "K must be between 0 and the queue size :(");
            }
            if (k <= 1)
            {
                return;
            }

            Stack<T> stack = new Stack<T>();

            for (int i = 0; i < k; i++)
            {
                stack.Push(queue.Dequeue());
            }

            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }

            for (int i = 0; i < n - k; i++)
            {
                T item = queue.Dequeue();
                queue.Enqueue(item);
            }
        }
        #endregion

        static void Main(string[] args)
        {
            /*#region 1
            int[] array = { 10, 20, 30, 40, 50 }; // Already sorted
            Console.Write("\nOriginal Array: ");
            Console.WriteLine(string.Join(", ", array));

            OptimisedBubbleSort(array);
            Console.Write("Sorted Array:   ");
            Console.WriteLine(string.Join(", ", array));
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
            int s, q;
            s = int.Parse(Console.ReadLine());
            q = int.Parse(Console.ReadLine());

            List<int> data = new List<int>();
            for (int i = 0; i < s; i++)
            {
                int num = int.Parse(Console.ReadLine());
                data.Add(num);
            }

            int[] arr = data.ToArray();

            while (q-- > 0)
            {
                int x = int.Parse(Console.ReadLine());
                int result = CountGreaterNumbers(arr, x);
                Console.WriteLine(result);
            }
            #endregion*/

            /*#region 4
            int[] array1 = { 1, 3, 2, 3, 1 };
            bool result1 = IsPalindrome(array1);
            Console.WriteLine($"Array: [1, 3, 2, 3, 1] -> {(result1 ? "YES" : "NO")}");
            #endregion*/

            /*#region 5
            Queue<int> q = new Queue<int>();
            q.Enqueue(10);
            q.Enqueue(20);
            q.Enqueue(30);
            q.Enqueue(40);

            Console.Write("Original Queue: ");
            Console.WriteLine(string.Join(", ", q));

            ReverseQueue(q);

            Console.Write("Reversed Queue by stack: ");
            Console.WriteLine(string.Join(", ", q));
            #endregion*/

            /*#region 6
            string s1 = "[()]{}";
            Console.WriteLine($"'{s1}' is balanced: {IsParenthesesBalanced(s1)}");

            string s3 = "([)]";
            Console.WriteLine($"'{s3}' is balanced: {IsParenthesesBalanced(s3)}");
            #endregion*/

            /*#region 7
            int[] data = { 1, 5, 2, 8, 5, 1, 9, 2 };

            int[] result = RemoveDuplicates(data);

            Console.WriteLine($"Original Data: {string.Join(", ", data)}");
            Console.WriteLine($"Unique Result: {string.Join(", ", result)}");
            #endregion*/

            /*#region 8
            List<int> data = new List<int> { 1, 15, 22, 37, 40, 51, 68, 79, 84 };
            List<int> result = GetNoOddNumbers(data);

            Console.WriteLine("Original Data: " + string.Join(", ", data));
            Console.WriteLine("Even Numbers Found: " + string.Join(", ", result));
            #endregion*/

            /*#region 9
            Queue<object> multiTypeQueue = new Queue<object>();


            int intValue = 1;
            multiTypeQueue.Enqueue(intValue);

            string stringValue = "Apple";
            multiTypeQueue.Enqueue(stringValue);

            double doubleValue = 5.28;
            multiTypeQueue.Enqueue(doubleValue);


            while (multiTypeQueue.Count > 0)
            {
                object item = multiTypeQueue.Dequeue();
                Console.WriteLine($"Dequeued: {item}, Type: {item.GetType().Name}");
            }
            #endregion*/

            /*#region 10
            Stack<int> myStack = new Stack<int>();
            int[] initialData = { 25, 10, 50, 5, 80, 15 };

            foreach (int num in initialData)
            {
                myStack.Push(num);
            }

            Console.WriteLine($"Stack Data: [{string.Join(", ", myStack)}]");
            Console.Write("Enter the target integer to search for: ");

            if (int.TryParse(Console.ReadLine(), out int target))
            {
                int r = SearchStack(myStack, target);
                if (r != -1)
                {
                    Console.WriteLine($"Element {target} after check {r-1} :)");
                }
                else
                {
                    Console.WriteLine($"Element {target} not found in the stack :(");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            #endregion*/

            /*#region 11
            int[] arrayA = { 1, 2, 3, 4, 4 };
            int[] arrayB = { 10, 4, 4 };

            int[] result = Intersect(arrayA, arrayB);

            Console.WriteLine($"Array 1: [{string.Join(", ", arrayA)}]");
            Console.WriteLine($"Array 2: [{string.Join(", ", arrayB)}]");
            Console.WriteLine($"Intersection: [{string.Join(", ", result)}]");
            #endregion*/

            #region 12
            ArrayList data = new ArrayList { 1, 2, 3, 7, 5 };
            int targetSum = 12;

            List<int> result = FindSublistWithSum(data, targetSum);

            Console.WriteLine($"Input Array: [{string.Join(", ", data.Cast<int>())}]");
            Console.WriteLine($"Target Sum: {targetSum}");
            Console.WriteLine($"Output Sublist: [{string.Join(", ", result)}]");
            #endregion

            /*#region 13
            Queue<int> q = new Queue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            q.Enqueue(5);

            int k = 3;

            Console.Write("Original Queue: ");
            Console.WriteLine(string.Join(", ", q));

            ReverseFirstKElements(q, k);

            Console.Write($"Reversed First K={k}: ");
            Console.WriteLine(string.Join(", ", q));
            #endregion*/
        }
    }
}
