using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DEBITasksDay1
{
    class Program
    {
        static void Main()
        {
            #region problem 1

            /* x is an integer
             * y is an integer
             */
            // Write a C# program to add two numbers and display the sum.           
            //int x = 10;
            //int y = 20;
            //int sum = x + y;
            //Console.WriteLine(sum);
            #endregion

            #region Question: What is the shortcut to comment and uncomment a selected block of code in Visual Studio ?
            // is "Ctrl + K, Ctrl + C" and to uncomment is "Ctrl + K, Ctrl + U".
            #endregion

            #region poblem 2
            //int x = "10";
            //Console.WriteLine(x + y);
            /* 
             * problem is c is integer and "10" is string
             * and y is not defined
             */
            #endregion

            #region Explain the difference between a runtime error and a logical error with examples.
            /*
             * A runtime error occurs during the execution of a program and causes it to terminate unexpectedly.
             * Example: Dividing a number by zero.
             * 
             * A logical error occurs when the program runs without crashing but produces incorrect results.
             * Example: Using the wrong formula to calculate the area of a rectangle.
             */
            #endregion

            #region Problem: Declare variables using proper naming conventions to store:            
            string FullName;
            int Age;
            decimal Salary;
            bool IsStudent;
            #endregion

            #region Why is it important to follow naming conventions such as PascalCase in C#?
            /*
             * Following naming conventions like PascalCase in C# is important because it enhances code readability and maintainability.
             * It helps developers quickly identify the purpose of variables, methods, and classes, making collaboration easier.
             * Consistent naming conventions also reduce the likelihood of errors and improve overall code quality.
             */
            #endregion

            #region Write a program to demonstrate that changing the value of a reference type affects all references pointing to that object.
                                    
            Person person1 = new Person();
            
            person1.Name = "Alice";
           
            Person person2 = person1;
           
            person2.Name = "Bob";
           
            Console.WriteLine(person1.Name); // Output: Bob
            #endregion

            #region Explain the difference between value types and reference types in terms of memory allocation.
            /*
             * value types store their data directly in the stack,
             * while reference types store a reference (memory address) on the stack that points to the actual data stored in the heap
             */
            #endregion

            #region problem 3
            int x = 15; 
            int y = 4;
            
            Console.WriteLine(x + y);
            Console.WriteLine(x - y);
            Console.WriteLine(x * y);
            Console.WriteLine(x / y);
            Console.WriteLine(x % y);
            #endregion

            #region What will be the output of the following code? Explain why:
            int a = 2, b = 7;
            Console.WriteLine(a % b);
            /*
             * The output will be 2 because when the dividend (a) is less than the divisor (b),
             * the remainder is equal to the dividend itself.
             */
            #endregion

            #region problem 4
            //Problem: Write a program that checks if a given number is both: 
            int Number = Convert.ToInt32(Console.ReadLine());
            bool IsEven = Number % 2 == 0;
            bool IsGreaterThan10 = Number > 10;

            Console.WriteLine("IsEven" + IsEven + "IsGreaterThan10" + IsGreaterThan10);
            #endregion

            #region How does the && (logical AND) operator differ from the & (bitwise AND) operator?
            /*
             * The && operator is a logical AND operator that evaluates the second operand only if the first operand is true.
             * The & operator is a bitwise AND operator that evaluates both operands regardless of the first operand's value.
             */
            #endregion

            #region problem 5
            /*: Implement a program that takes a double input from the user and casts it to an int. 
                Use both implicit and explicit casting, then print the results.*/
            // Implicit casting
            double doubleValue = Convert.ToDouble(Console.ReadLine());
            // Explicit casting
            int intValue = (int)doubleValue;
            Console.WriteLine("Double value: " + doubleValue);
            Console.WriteLine("Int value: " + intValue);
            #endregion

            #region Why is explicit casting required when converting a double to an int?
            /*
             * because it involves a potential loss of data.
             * A double can represent fractional values, while an int can only represent whole numbers.
             */
            #endregion

            #region problem 6
            /*Write a program that: (G01 Bonus, G02 mandatory) 
            o Prompts the user for their age as a string. 
            o Converts the string to an integer using Parse 
            o Checks if the age is valid (e.g., greater than 0).
            */
            Console.WriteLine("Please enter your age:");
            string ageInput = Console.ReadLine();
            int age = int.Parse(ageInput);
            if (age > 0)            
                Console.WriteLine("Valid age: " + age);
            else           
                Console.WriteLine("Invalid age. Age must be greater than 0.");
            #endregion

            #region What exception might occur if the input is invalid and how can you handle it?
            /*
             * FormatException might occur if the input string is not in a correct format to be parsed as an integer.
             */
            #endregion

            #region problem 7
            int num = 10;
            Console.WriteLine(++num); // Pre-increment: output 11
            Console.WriteLine(num++); // Post-increment: output 11, then num becomes 12
            #endregion

            #region  Given the code below, what is the value of x after execution? Explain why?

            //int x = 5;
            //int y = ++x + x++;
            // The value of x after execution is 7.
            //The final state of x after all increments have applied is 7
            #endregion


            #region Part 2

            #region 2- what's the difference between compiled and interpreted languages and in this way what about Csharp?
            /*
             * Compiled languages are translated into machine code before execution, resulting in faster performance.
             * Interpreted languages are executed line-by-line at runtime, which can be slower.
             * C# is a compiled language that is first compiled into Intermediate Language (IL) and then executed by the .NET runtime.
             */
            #endregion


            #region 3- Compare between implicit, explicit, Convert and parse casting
            /*
             * Implicit casting is automatic and safe, used for converting smaller types to larger types.
             * Explicit casting requires a cast operator and is used when converting larger types to smaller types, which may lead to data loss.
             * Convert class provides methods to convert between different types with built-in error handling.
             * Parse method is used to convert strings to specific types but can throw exceptions if the format is incorrect.
             */
            #endregion

            #endregion











        }
    }
}