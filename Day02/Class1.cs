using System;
using System.Text;

namespace Day02
{ 
public class Class1
{


        #region problem 1
        /*
         * Problem: Write a program to: 
         o Accept a string input from the user. 
         o Convert it to an integer using both int.Parse and Convert.ToInt32. 
         o Handle potential exceptions using a try-catch block.      
        */
        public void Problem1()
        {
            Console.WriteLine("Please enter a number:");
            string userInput = Console.ReadLine();
            try
            {
                // Using int.Parse
                int parsedValue = int.Parse(userInput);
                Console.WriteLine("Parsed value using int.Parse: " + parsedValue);
            }
            catch (FormatException)
            {
                Console.WriteLine("int.Parse: Input string is not in a correct format.");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("int.Parse: Input string is null.");
            }
            try
            {
                // Using Convert.ToInt32
                int convertedValue = Convert.ToInt32(userInput);
                Console.WriteLine("Converted value using Convert.ToInt32: " + convertedValue);
            }
            catch (FormatException)
            {
                Console.WriteLine("Convert.ToInt32: Input string is not in a correct format.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Convert.ToInt32: Input string represents a number less than MinValue or greater than MaxValue.");
            }
        }
        // Question: What is the difference between int.Parse and Convert.ToInt32 when handling null inputs?
        /*
         * int.Parse throws an ArgumentNullException when the input is null, while Convert.ToInt32 returns 0 for null inputs.
         */
        #endregion

        #region problem 2
        /*
         *  Problem: Write a program that: 
        o Prompts the user to input a number. 
        o Uses int.TryParse to check if the input is a valid integer. 
        o If valid, print the number; otherwise, print an error message. 
         */

        public void Problem2()
        {
            string input = Console.ReadLine();
            bool isValid = int.TryParse(input, out int result);
            if (isValid)
            {
                Console.WriteLine("You entered the number: " + result);
            }
            else
            {
                Console.WriteLine("Error: Invalid input. Please enter a valid integer.");
            }
        }

        // Question: Why is TryParse recommended over Parse in user-facing applications?  
        /*
         * TryParse is recommended because it does not throw exceptions for invalid inputs, making it more efficient and user-friendly.
         */
        #endregion

        #region problem 3
        /*
          Problem: Implement a program to: 
        o Declare an object variable. 
        o Assign it different data types (e.g., int, string, double). 
        o Print the GetHashCode() of each assignment. 
        */
        public void Problem3()
        {
            object obj;
            obj = 42; // int
            Console.WriteLine("HashCode of int 42: " + obj.GetHashCode());
            obj = "Hello, World!"; // string
            Console.WriteLine("HashCode of string 'Hello, World!': " + obj.GetHashCode());
            obj = 3.14; // double
            Console.WriteLine("HashCode of double 3.14: " + obj.GetHashCode());
        }

        // Question: Explain the real purpose of the GetHashCode() method.

        /*
         * The GetHashCode() method provides a unique identifier for an object, which is useful for hashing algorithms and data structures like hash tables.
         */
        #endregion

        #region problem 4
        /*
          Problem: Demonstrate how changing one reference affects another when both point to 
        the same object. Use the following steps: 
        o Create an object and assign it a value. 
        o Create a second reference to the same object. 
        o Modify the value of the object using one reference and print the value using the other. 
        */
        public void Problem4()
        {
            // Create an object and assign it a value
            Person person1 = new Person { Name = "Alice" };
            // Create a second reference to the same object
            Person person2 = person1;
            // Modify the value of the object using one reference
            person2.Name = "Bob";
            // Print the value using the other reference
            Console.WriteLine("person1 Name: " + person1.Name); // Output: Bob
        }
        // Question: What is the significance of reference equality in .NET? 
        /*
         * it distinguishes object identity from object equivalence,
         * allowing developers to confirm if two references are truly pointing to the same entity or just copies with identical content,
         * a fundamental concept for managing state, performance,
         * and correct behavior with mutable objects and collections. 
         */
        #endregion

        #region problem 5
        /*
          Problem: Write a program to: 
        o Declare a string and modify it by concatenating additional text “Hi Willy”. 
        o Print the GetHashCode() before and after modification. 
        */
        public void Problem5()
        {
            string sayHi = "Hi";            
            Console.WriteLine("Before " + sayHi.GetHashCode());
            sayHi += " willy";
            Console.WriteLine("After " + sayHi.GetHashCode());
        }
        // Question: Why string is immutable in C# ? 
        /*
         * by design to provide thread safety, enhanced security, and performance optimizations like string interning
         */


        #endregion

        #region problem 6
        /*
         * Problem: Create a program to: 
         o Use StringBuilder to append text to a string “Hi Willy”. 
         o Print the GetHashCode() of the StringBuilder instance before and after the modification. 
         */
        public void Problem6()
        {
            StringBuilder sb = new StringBuilder("Hi");
            Console.WriteLine("Before " + sb.GetHashCode());
            sb.Append(" Willy");
            Console.WriteLine("After " + sb.GetHashCode());          
        }
        // Question: How does StringBuilder address the inefficiencies of string concatenation? 
        /*
         * StringBuilder addresses the inefficiencies of string concatenation by bypassing the overhead caused by string immutability
         */
        #endregion

        #region problem 7
        // Question: Why is StringBuilder faster for large-scale string modifications? 
        /*
         * StringBuilder is faster for large-scale modifications because it treats memory like a reusable workspace rather than a single-use product.
         */
        #endregion

        #region problem 8
        /*
         * Problem: Create a program to: 
         o Accept two integer inputs from the user. 
         o Display the sum using all three methods “Sum is input1+input2”: 
          Concatenation (+ operator) 
          Composite formatting (string.Format) 
          String interpolation ($) 
         */

        public void problem8()
        {
            Console.WriteLine("Enter first number ");
            string input1str = Console.ReadLine();
            Console.WriteLine("Enter second number ");
            string input2str = Console.ReadLine();


            int input1 = int.Parse(input1str);
            int input2 = int.Parse(input2str);

            int sum = input1 + input2;
            Console.WriteLine("Method 1 (Concatenation): Sum is " + sum);

            string compositeResult = string.Format("Sum is {0}", sum);
            Console.WriteLine("Method 2 (Composite):     " + compositeResult);

            Console.WriteLine($"Method 3 (Interpolation): Sum is {sum}");
        }

        // Question: Which string formatting method is most used and why? 

        /*
         The most used and recommended string formatting method in modern C# is String Interpolation (introduced in C# 6). 
         Most Used: String Interpolation ($"") 
         Developers prefer this method for several reasons:
         Readability: It allows you to embed variables and expressions directly inside the string literal using curly braces (e.g., $"Hello {name}"), which is much easier to read than numbered placeholders.
         Safety: It reduces the risk of runtime errors caused by mismatched argument orders or counts, which frequently occur in string.Format.
         Flexibility: It supports all standard and custom format specifiers (e.g., $"Price: {price:C}" for currency).
         Performance: In modern .NET (C# 10+ / .NET 6+), the compiler uses Interpolated String Handlers to write directly to a buffer, making it highly efficient and often reducing memory allocations compared to older methods. 
         */
        #endregion

        #region problem 9
        /*
          Problem: Create a program using StringBuilder to: 
        o Append text. 
        o Replace a substring. 
        o Insert a string at a specific position. 
        o Remove a portion of text. 
         Question: Explain how StringBuilder is designed to handle frequent modifications 
        compared to strings.
         */

        public void problem9()
        {
            // Initialize StringBuilder
            StringBuilder sb = new StringBuilder("Initial Text");
            Console.WriteLine($"Start:   {sb}");

            // 1. Append text
            sb.Append(" - Appended Text");
            Console.WriteLine($"Append:  {sb}");

            // 2. Replace a substring
            sb.Replace("Initial", "Modified");
            Console.WriteLine($"Replace: {sb}");

            // 3. Insert a string at a specific position (index 0)
            sb.Insert(0, "Start: ");
            Console.WriteLine($"Insert:  {sb}");

            // 4. Remove a portion of text (Remove 7 characters starting from index 0)
            sb.Remove(0, 7);
            Console.WriteLine($"Remove:  {sb}");
        }

        /*
         StringBuilder is mutable. It is designed like a dynamic container (specifically, a resizeable char[] array) that allows you to modify the data in-place.

         Internal Buffer: StringBuilder maintains an internal buffer (a character array) with a specific Capacity.

         Modifying: When you Append or Insert, it simply fills the empty slots in that existing array. No new objects are created.

         Resizing: If you add more text than the buffer can hold,
         StringBuilder automatically creates a new, 
         larger array (usually double the size),
         copies the characters over, and continues.
         This happens far less frequently than creating a new object for every single edit.
        */
        #endregion


        #region Part 2
        /*
         Enum Data Type
        What it is: An Enum (Enumeration) is a value type that defines a set of named integer constants. It allows you to assign friendly names to numeric values.

        When it is used: It is used to represent a fixed set of related options, states, or categories (e.g., days of the week, order status, colors). This replaces "magic numbers" in your code, making it safer and easier to read.

        Three Common Built-in Enums:

        DayOfWeek (e.g., DayOfWeek.Monday, DayOfWeek.Friday)

        ConsoleColor (e.g., ConsoleColor.Red, ConsoleColor.Green - used for console text)

        HttpStatusCode (e.g., HttpStatusCode.OK, HttpStatusCode.NotFound - used in web API responses)
         */

        /*
         * 3- what are scenarios to use  string Vs StringBuilder? 
         *  Fixed Text: When you have a piece of text that won't change, like a message: string message = "Hello World";.

            Minimal Concatenation: If you are only joining 2 or 3 strings together once (e.g., string fullName = firstName + " " + lastName;).

            Dictionary/Key Values: Since strings are immutable, they are perfect for use as keys in a Dictionary or for storing configuration settings.

            Readability: String operations are often more concise and readable for simple logic.

            Scenarios for StringBuilder
            You should use StringBuilder when performance and memory management are the priority.

            Loops: This is the most common scenario. If you are appending text inside a for or foreach loop (e.g., building a CSV row or a long list), never use a string.

            Large-Scale Manipulation: When you are performing complex operations on a large block of text, such as replacing 50 different keywords or inserting data at multiple specific indexes.

            Real-time Data Processing: If your application is receiving many small chunks of data (like a stream) and needs to assemble them into one large report.
                     * 

         
         */
        #endregion

    }


}

