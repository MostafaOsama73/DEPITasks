using System;
using System.Linq;

namespace Day05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 01
            RunDivisionProgram();

            TestDefensiveCode();

            RunNullableDemo();

            RunArrayBoundsDemo();

            RunMatrixSumDemo();

            RunJaggedArrayDemo();

            RunNullableRefDemo();

            RunBoxingDemo();

            int sum, mul;
            SumAndMultiply(5, 10, out sum, out mul);
            Console.WriteLine($"Sum: {sum}, Product: {mul}");

            PrintString("Hello World");
            PrintString("Hello World", 3);

            RunNullPropDemo();

            RunSwitchExpressionDemo();

            int total = SumArray(10, 20, 30, 40);
            Console.WriteLine($"Total Sum: {total}");
            #endregion

            #region Part 02
            // 1. Print Numbers in Range
            PrintRange();

            // 2. Multiplication Table
            PrintMultiplicationTable();

            // 3. Even Numbers
            PrintEvenNumbers();

            // 4. Exponentiation
            ComputeExponentiation();

            // 5. Reverse String
            ReverseString();

            // 6. Reverse Integer
            ReverseInteger();

            // 7. Longest Distance
            FindLongestDistance();

            // 8. Reverse Words
            ReverseWords();
            #endregion
        }

        #region Part 01 Methods

        public static void RunDivisionProgram()
        {
            try
            {
                Console.Write("Enter first number: ");
                int n1 = int.Parse(Console.ReadLine());
                Console.Write("Enter second number: ");
                int n2 = int.Parse(Console.ReadLine());
                int result = n1 / n2;
                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero.");
            }
            finally
            {
                Console.WriteLine("Operation complete");
            }
        }

        public static void TestDefensiveCode()
        {
            int X, Y;
            do
            {
                Console.Write("Enter positive X: ");
            } while (!int.TryParse(Console.ReadLine(), out X) || X <= 0);

            do
            {
                Console.Write("Enter Y (greater than 1): ");
            } while (!int.TryParse(Console.ReadLine(), out Y) || Y <= 1);

            Console.WriteLine($"Valid inputs: X={X}, Y={Y}");
        }

        public static void RunNullableDemo()
        {
            int? val = null;
            int x = val ?? 10;
            Console.WriteLine($"Value: {x}");

            if (val.HasValue)
                Console.WriteLine(val.Value);
            else
                Console.WriteLine("val is null");
        }

        public static void RunArrayBoundsDemo()
        {
            int[] arr = new int[5];
            try
            {
                arr[10] = 50;
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void RunMatrixSumDemo()
        {
            int[,] matrix = new int[3, 3];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"Enter value [{i},{j}]: ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int rowSum = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    rowSum += matrix[i, j];
                }
                Console.WriteLine($"Row {i} Sum: {rowSum}");
            }

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int colSum = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    colSum += matrix[i, j];
                }
                Console.WriteLine($"Col {j} Sum: {colSum}");
            }
        }

        public static void RunJaggedArrayDemo()
        {
            int[][] jagged = new int[3][];
            jagged[0] = new int[2];
            jagged[1] = new int[3];
            jagged[2] = new int[4];

            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write($"Enter value for Row {i}: ");
                    jagged[i][j] = int.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write($"{jagged[i][j]} ");
                }
                Console.WriteLine();
            }
        }

        public static void RunNullableRefDemo()
        {
            Console.Write("Enter text (optional): ");
            string input = Console.ReadLine();
            string? text = string.IsNullOrEmpty(input) ? null : input;

            Console.WriteLine(text!.ToUpper());
        }

        public static void RunBoxingDemo()
        {
            int num = 10;
            object obj = num;
            try
            {
                int unboxed = (int)obj;
                Console.WriteLine($"Unboxed: {unboxed}");
                long invalid = (long)obj;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void SumAndMultiply(int n1, int n2, out int sum, out int mul)
        {
            sum = n1 + n2;
            mul = n1 * n2;
        }

        public static void PrintString(string message, int count = 5)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(message);
            }
        }

        public static void RunNullPropDemo()
        {
            int[]? numbers = null;
            int? length = numbers?.Length;
            Console.WriteLine($"Length: {length}");
        }

        public static void RunSwitchExpressionDemo()
        {
            Console.Write("Enter Day: ");
            string day = Console.ReadLine();
            int dayNum = day switch
            {
                "Monday" => 1,
                "Tuesday" => 2,
                "Wednesday" => 3,
                "Thursday" => 4,
                "Friday" => 5,
                "Saturday" => 6,
                "Sunday" => 7,
                _ => 0
            };
            Console.WriteLine($"Day Number: {dayNum}");
        }

        public static int SumArray(params int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        #endregion

        #region Part 02 Methods

        public static void PrintRange()
        {
            Console.Write("Enter Number: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.Write($"{i}, ");
            }
            Console.WriteLine();
        }

        public static void PrintMultiplicationTable()
        {
            Console.Write("Enter Number: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= 12; i++)
            {
                Console.Write($"{n * i}, ");
            }
            Console.WriteLine();
        }

        public static void PrintEvenNumbers()
        {
            Console.Write("Enter Number: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 2; i <= n; i += 2)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }

        public static void ComputeExponentiation()
        {
            Console.Write("Base: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Power: ");
            int p = int.Parse(Console.ReadLine());
            int res = 1;
            for (int i = 0; i < p; i++)
            {
                res *= b;
            }
            Console.WriteLine(res);
        }

        public static void ReverseString()
        {
            Console.Write("Enter String: ");
            string s = Console.ReadLine();
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            Console.WriteLine(new string(arr));
        }

        public static void ReverseInteger()
        {
            Console.Write("Enter Integer: ");
            int n = int.Parse(Console.ReadLine());
            string s = n.ToString();
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            Console.WriteLine(new string(arr));
        }

        public static void FindLongestDistance()
        {
            Console.Write("Size: ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            int maxDist = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = n - 1; j > i; j--)
                {
                    if (arr[i] == arr[j])
                    {
                        int dist = j - i - 1;
                        if (dist > maxDist) maxDist = dist;
                        break;
                    }
                }
            }
            Console.WriteLine(maxDist);
        }

        public static void ReverseWords()
        {
            Console.Write("Sentence: ");
            string s = Console.ReadLine();
            string[] parts = s.Split(' ');
            Array.Reverse(parts);
            Console.WriteLine(string.Join(" ", parts));
        }

        #endregion
    }

    /*
     Part 01: Questions & Answers
        Q: What is the purpose of the finally block? 
        A: It ensures that a specific block of code executes regardless of whether an exception is thrown or not, usually used for resource cleanup.

        Q: How does int.TryParse() improve program robustness compared to int.Parse()? 
        A: int.Parse throws an exception if the input is invalid, which crashes the program. int.TryParse returns false instead of throwing an exception, allowing the program to handle invalid input safely.

        Q: What exception occurs when trying to access Value on a null Nullable? 
        A: System.InvalidOperationException.

        Q: Why is it necessary to check array bounds before accessing elements? 
        A: To avoid a System.IndexOutOfRangeException, which occurs if you try to access an index that is outside the valid range of the array.

        Q: How is the GetLength(dimension) method used in multi-dimensional arrays? 
        A: It returns the size of a specific dimension (0 for rows, 1 for columns), which is needed to loop correctly through rectangular arrays.

        Q: How does the memory allocation differ between jagged arrays and rectangular arrays? 
        A: A rectangular array is a single block of memory. A jagged array is an array of arrays, where each inner array is a separate object stored in the heap.

        Q: What is the purpose of nullable reference types in C#? 
        A: They help prevent NullReferenceException by forcing developers to explicitly handle null cases and providing compile-time warnings if a null value is accessed unsafely.

        Q: What is the performance impact of boxing and unboxing in C#?
        A: Boxing and unboxing are computationally expensive. Boxing allocates new memory on the heap, and unboxing requires type checking and value extraction, making them slower than direct value assignments.

        Q: Why must out parameters be initialized inside the method?
        A: Because out parameters are treated as unassigned when they enter the method. The method must guarantee that a value is assigned to them before it finishes.

        Q: Why must optional parameters always appear at the end of a method's parameter list? 
        A: To avoid ambiguity so the compiler can correctly match the arguments provided by the caller to the method parameters.

        Q: How does the null propagation operator prevent NullReferenceException? 
        A: It checks if the object is null before performing the operation. If the object is null, the expression returns null instead of throwing an exception.

        Q: When is a switch expression preferred over a traditional if statement? 
        A: It is preferred when mapping a single input value directly to a result, as it is more concise and readable for assignment logic.

        Q: What are the limitations of the params keyword in method definitions? 
        A: A method can have only one params keyword, and it must be the last parameter in the method signature.
     
     */
}