using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;

namespace Day10
{
    class Employee : IComparable<Employee>, ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee(int _id, string _name, double _salary)
        {
            Id = _id;
            Name = _name;
            Salary = _salary;
        }

        public override string ToString()
        {
            return $"Id is {Id}, Name is {Name}, Salary is {Salary}";
        }

        public int CompareTo(Employee other)
        {
            return this.Salary.CompareTo(other.Salary);
        }

        public object Clone()
        {
            return new Employee(this.Id, this.Name, this.Salary);
        }
    }

    class Manager : Employee, IComparable<Manager>
    {
        public Manager(int id, string name, double salary) : base(id, name, salary) { }

        public int CompareTo(Manager other)
        {
            if (other == null) return 1;
            return this.Salary.CompareTo(other.Salary);
        }
    }

    static class SortingTwo<T>
    {
        public static void Sort(T[] items, Func<T, T, bool> compareFunc)
        {
            for (int i = 0; i < items.Length - 1; i++)
            {
                for (int j = 0; j < items.Length - 1 - i; j++)
                {
                    if (compareFunc.Invoke(items[j], items[j + 1]))
                    {
                        Swap(ref items[j], ref items[j + 1]);
                    }
                }
            }
        }

        public static void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }

    static class SortingAlgorithm<T> where T : IComparable<T>
    {
        public static void SortAscending(T[] items)
        {
            for (int i = 0; i < items.Length - 1; i++)
            {
                for (int j = 0; j < items.Length - 1 - i; j++)
                {
                    if (items[j].CompareTo(items[j + 1]) > 0)
                    {
                        Swap(ref items[j], ref items[j + 1]);
                    }
                }
            }
        }

        public static void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }

    static class GenericUtilities
    {
        public static T GetDefault<T>()
        {
            return default(T);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Problem 1

            Employee[] emps1 = {
                new Employee(1, "Ali", 6000),
                new Employee(2, "Alexander", 5000),
                new Employee(3, "Mona", 3000)
            };

            foreach (var emp in emps1) Console.WriteLine(emp);
            Console.WriteLine();

            SortingAlgorithm<Employee>.SortAscending(emps1);

            foreach (var emp in emps1) Console.WriteLine(emp);
            Console.WriteLine();

            // Question : What are the benefits of using a generic sorting algorithm over a non-generic one? 
            // Answer: A generic sorting algorithm can work with any data type that implements the required interface (like IComparable<T>),
            // providing code reusability and type safety. It eliminates the need for multiple sorting implementations for different types,
            // reducing code duplication and potential errors. Additionally, it allows for more flexible sorting criteria through the use of delegates or lambda expressions,
            // enabling custom sorting logic without modifying the underlying sorting algorithm.

            #endregion

            #region Problem 2

            int[] nums = { 1, 5, 3, 9, 2 };

            foreach (var num in nums) Console.Write(num + " ");
            Console.WriteLine();

            SortingTwo<int>.Sort(nums, (x, y) => x < y);

            foreach (var num in nums) Console.Write(num + " ");
            Console.WriteLine("\n");

            //Question: How do lambda expressions improve the readability and flexibility of sorting methods? 
            //Answer: Lambda expressions allow for concise and inline definition of comparison logic directly within the sorting method call,
            //improving readability by keeping related code together. They eliminate the need for separate method definitions for simple comparisons,
            //making the code more compact and easier to understand. Additionally,
            //lambda expressions provide flexibility by enabling developers to easily change sorting criteria without modifying the underlying sorting algorithm,
            //allowing for dynamic and customizable sorting behavior.


            #endregion

            #region Problem 3

            string[] names = { "Alexander", "Ali", "Mahmoud", "Abdo" };

            foreach (var name in names) Console.Write(name + " ");
            Console.WriteLine();

            SortingTwo<string>.Sort(names, (x, y) => x?.Length > y?.Length);

            foreach (var name in names) Console.Write(name + " ");
            Console.WriteLine("\n");

            //Why is it important to use a dynamic comparer function when sorting objects of various data types?
            //Using a dynamic comparer function allows for greater flexibility and adaptability when sorting objects of various data types.
            //It enables the sorting algorithm to work with different types of data without needing to implement separate sorting logic for each type.
            //This is particularly important in scenarios where the sorting criteria may vary based on the context or user preferences.
            //By using a dynamic comparer function, developers can easily customize the sorting behavior without modifying the underlying sorting algorithm,
            //promoting code reusability and maintainability across different data types and sorting requirements.


            #endregion

            #region Problem 4

            Manager[] managers = {
                new Manager(1, "BossA", 12000),
                new Manager(2, "BossB", 9000)
            };

            foreach (var manager in managers) Console.WriteLine(manager);
            Console.WriteLine();

            SortingAlgorithm<Manager>.SortAscending(managers);

            foreach (var manager in managers) Console.WriteLine(manager);
            Console.WriteLine();

            //How does implementing IComparable<T> in derived classes enable custom sorting? 
            //Implementing IComparable<T> in derived classes allows for custom sorting by defining the comparison logic specific to that class.
            //When a class implements IComparable<T>, it provides a CompareTo method that determines how instances of that class should be compared to each other.
            //This enables sorting algorithms to use the CompareTo method to order objects based on the defined criteria (e.g., Salary for Manager).
            //By implementing IComparable<T>, derived classes can specify their own sorting behavior, allowing for more meaningful and context-specific sorting of objects.

            #endregion

            #region Problem 5

            Employee[] emps2 = {
                new Employee(1, "Ali", 4000),
                new Employee(2, "Alexander", 5000),
                new Employee(3, "Mona", 3000)
            };

            Func<Employee, Employee, bool> compareNameLength = (e1, e2) => e1.Name.Length > e2.Name.Length;

            foreach (var emp in emps2) Console.WriteLine(emp);
            Console.WriteLine();

            SortingTwo<Employee>.Sort(emps2, compareNameLength);

            foreach (var emp in emps2) Console.WriteLine(emp);
            Console.WriteLine();

            //What is the advantage of using built-in delegates like Func<T, T, TResult> in generic programming ?
            //Using built-in delegates like Func<T, T, TResult> in generic programming provides several advantages:
            //1. Reusability: Built-in delegates are widely used and recognized in the .NET ecosystem, making them easily reusable across different projects and libraries.
            //2. Readability: They improve code readability by providing a clear and concise way to represent methods that take parameters and return a value, making it easier for developers to understand the intent of the code.
            //3. Flexibility: Built-in delegates allow for greater flexibility in defining and passing around methods as parameters, enabling developers to easily customize behavior without needing to create custom delegate types.

            #endregion

            #region Problem 6

            int[] numsAsc1 = { 8, 2, 4 };
            int[] numsAsc2 = { 7, 1, 9 };

            foreach (var num in numsAsc1) Console.Write(num + " ");
            Console.WriteLine();
            SortingTwo<int>.Sort(numsAsc1, delegate (int a, int b) { return a > b; });
            foreach (var num in numsAsc1) Console.Write(num + " ");
            Console.WriteLine("\n");

            foreach (var num in numsAsc2) Console.Write(num + " ");
            Console.WriteLine();
            SortingTwo<int>.Sort(numsAsc2, (a, b) => a > b);
            foreach (var num in numsAsc2) Console.Write(num + " ");
            Console.WriteLine("\n");

            //How does the usage of anonymous functions differ from lambda expressions in terms of readability and efficiency ?
            //Anonymous functions and lambda expressions both allow for inline method definitions, but they differ in terms of syntax and readability.
            //Anonymous functions use the 'delegate' keyword and can be more verbose, which may reduce readability, especially for simple operations.
            //Lambda expressions provide a more concise and cleaner syntax, improving readability by reducing boilerplate code.
            //In terms of efficiency, both anonymous functions and lambda expressions are compiled into similar intermediate language (IL) code, so there is generally no significant performance difference between the two.

            #endregion

            #region Problem 7

            int val1 = 10, val2 = 20;

            Console.WriteLine($"{val1} {val2}");
            SortingAlgorithm<int>.Swap(ref val1, ref val2);
            Console.WriteLine($"{val1} {val2}\n");

            //Why is the use of generic methods beneficial when creating utility functions like Swap? 
            //The use of generic methods in utility functions like Swap is beneficial because it allows the same method to work with any data type without needing to create multiple overloads for each type.
            //This promotes code reusability and reduces redundancy, as the same logic can be applied to different types without modification.
            //Additionally, generic methods provide type safety at compile time, ensuring that the correct types are used and preventing potential runtime errors.

            #endregion

            #region Problem 8

            Employee[] empsMulti = {
                new Employee(1, "Zebra", 4000),
                new Employee(2, "Ali", 4000),
                new Employee(3, "Mona", 3000)
            };

            foreach (var emp in empsMulti) Console.WriteLine(emp);
            Console.WriteLine();

            SortingTwo<Employee>.Sort(empsMulti, (e1, e2) =>
            {
                if (e1.Salary == e2.Salary)
                    return e1.Name.CompareTo(e2.Name) > 0;

                return e1.Salary > e2.Salary;
            });

            foreach (var emp in empsMulti) Console.WriteLine(emp);
            Console.WriteLine();

            //What are the challenges and benefits of implementing multi-criteria sorting logic in generic methods?
            //Challenges of implementing multi-criteria sorting logic in generic methods include increased complexity in the comparison logic,
            //as it requires handling multiple conditions and ensuring that the sorting criteria are applied correctly.
            //Additionally, it may require more computational resources if the sorting algorithm needs to evaluate multiple criteria for each comparison.
            //Benefits include the ability to sort data in a more meaningful way, as it allows for more nuanced ordering based on multiple attributes (e.g., Salary and Name for Employee).
            //This can lead to more accurate and relevant sorting results, especially in scenarios where a single criterion is insufficient to determine the order of items.

            #endregion

            #region Problem 9

            int defaultInt = GenericUtilities.GetDefault<int>();
            Employee defaultEmp = GenericUtilities.GetDefault<Employee>();

            Console.WriteLine(defaultInt);
            Console.WriteLine(defaultEmp == null ? "null\n" : defaultEmp.ToString() + "\n");

            //Why is the default(T) keyword crucial in generic programming, and how does it handle value and reference types differently?
            //The default(T) keyword is crucial in generic programming because it provides a way to obtain the default value for any type T, whether it's a value type or a reference type.
            //For value types (e.g., int, struct), default(T) returns the default value (e.g., 0 for int, a struct with all fields set to their default values).
            //For reference types (e.g., class), default(T) returns null, indicating that there is no instance of the type.
            //This allows generic methods to safely initialize variables of type T without needing to know the specific type at compile time, ensuring that the code can handle both value and reference types appropriately.

            #endregion

            #region Problem 10

            Employee[] clonedEmps = emps2.Select(e => (Employee)e.Clone()).ToArray();

            foreach (var emp in clonedEmps) Console.WriteLine(emp);
            Console.WriteLine();

            SortingAlgorithm<Employee>.SortAscending(clonedEmps);

            foreach (var emp in clonedEmps) Console.WriteLine(emp);
            Console.WriteLine();

            //How do constraints in generic programming ensure type safety and improve the reliability of generic methods?
            //Constraints in generic programming ensure type safety by restricting the types that can be used with a generic method or class to those that meet specific criteria (e.g., implementing an interface, being a reference type, etc.).
            //This allows the compiler to enforce that only compatible types are used, preventing potential runtime errors and improving the reliability of generic methods.
            //For example, by constraining a generic method to types that implement IComparable<T>, we can ensure that the sorting logic will work correctly, as it relies on the ability to compare instances of the type.

            #endregion

            #region Problem 11

            List<string> strList = new List<string> { "hello", "world" };
            List<string> upperList = FunctionalUtilities.TransformStrings(strList, s => s.ToUpper());
            List<string> reversedList = FunctionalUtilities.TransformStrings(strList, s => new string(s.Reverse().ToArray()));

            foreach (var s in strList) Console.Write(s + " ");
            Console.WriteLine();
            foreach (var s in upperList) Console.Write(s + " ");
            Console.WriteLine();
            foreach (var s in reversedList) Console.Write(s + " ");
            Console.WriteLine("\n");

            //What are the benefits of using delegates for string transformations in a functional programming style?
            //Using delegates for string transformations in a functional programming style allows for greater flexibility and reusability of code.
            //Delegates enable developers to pass different transformation logic as parameters, making it easy to apply various transformations without modifying the underlying method.
            //This promotes a separation of concerns, as the transformation logic is decoupled from the method that applies it, leading to cleaner and more maintainable code.

            #endregion

            #region Problem 12

            int addResult = FunctionalUtilities.PerformMath(10, 5, (a, b) => a + b);
            int multResult = FunctionalUtilities.PerformMath(10, 5, (a, b) => a * b);

            Console.WriteLine(addResult);
            Console.WriteLine(multResult + "\n");

            //How does the use of delegates promote code reusability and flexibility in implementing mathematical operations? 
            //The use of delegates promotes code reusability and flexibility in implementing mathematical operations by allowing developers to define and pass different operation logic as parameters to a single method.
            //This means that the same method can be used to perform various mathematical operations (e.g., addition, multiplication) without needing to create separate methods for each operation.
            //Delegates enable a functional programming style, where behavior can be treated as data, allowing for more dynamic and customizable code.

            #endregion

            #region Problem 13

            List<int> intList = new List<int> { 1, 2, 3 };
            List<string> strInts = FunctionalUtilities.TransformGeneric(intList, i => $"Number: {i}");

            foreach (var i in intList) Console.Write(i + " ");
            Console.WriteLine();
            foreach (var s in strInts) Console.WriteLine(s);
            Console.WriteLine();

            //What are the advantages of using generic delegates in transforming data structures? 
            //Using generic delegates in transforming data structures offers several advantages:
            //1. Type Safety: Generic delegates ensure that the transformations are type-safe, as they can only be used with compatible types, reducing the risk of runtime errors.
            //2. Reusability: Generic delegates can be reused across different data types and transformation scenarios, promoting code reuse and reducing duplication.
            //3. Flexibility: They allow for flexible transformation logic, as developers can easily define and pass different transformation functions without modifying the underlying method, enabling a more functional programming style.


            #endregion

            #region Problem 14

            List<int> squares = FunctionalUtilities.ApplyFunc(intList, x => x * x);

            foreach (var s in squares) Console.Write(s + " ");
            Console.WriteLine("\n");

            //How does Func simplify the creation and usage of delegates in C#? 
            //Func simplifies the creation and usage of delegates in C# by providing a built-in delegate type that can represent methods with a return value and parameters.
            //It eliminates the need to define custom delegate types for common scenarios, allowing developers to quickly create delegates using lambda expressions or method groups.
            //This leads to more concise and readable code, as the intent of the delegate is clear from the context, and it promotes a functional programming style by enabling the use of higher-order functions.

            #endregion

            #region Problem 15

            FunctionalUtilities.ApplyAction(strList, s => Console.WriteLine(s));
            Console.WriteLine();

            //Why is Action preferred for operations that do not return values? 
            //Action is preferred for operations that do not return values because it clearly indicates that the delegate is intended for performing an action or side effect rather than producing a result.
            //Using Action improves code readability by signaling to developers that the method is meant for executing code without returning a value, such as printing to the console or modifying state.
            //This helps to prevent confusion and promotes a clearer understanding of the code's intent, especially in scenarios where the focus is on performing an operation rather than calculating a result.

            #endregion

            #region Problem 16

            List<int> numberSet = new List<int> { 1, 2, 3, 4, 5, 6 };
            List<int> evens = FunctionalUtilities.FilterList(numberSet, x => x % 2 == 0);

            foreach (var n in numberSet) Console.Write(n + " ");
            Console.WriteLine();
            foreach (var e in evens) Console.Write(e + " ");
            Console.WriteLine("\n");

            //What role do predicates play in functional programming, and how do they enhance code clarity?
            //Predicates play a crucial role in functional programming as they represent conditions or criteria that can be used to filter or evaluate data.
            //They enhance code clarity by providing a clear and concise way to express conditions directly within the context of data processing, such as filtering a list of integers to find even numbers.
            //Using predicates allows developers to write more declarative code, where the focus is on what the code is doing rather than how it is doing it, improving readability and maintainability.


            #endregion

            #region Problem 17

            List<string> startsWithH = FunctionalUtilities.FilterStrings(strList, delegate (string s) {
                return s.StartsWith("h");
            });

            foreach (var s in startsWithH) Console.Write(s + " ");
            Console.WriteLine("\n");

            //How do anonymous functions improve code modularity and customization? 
            //Anonymous functions improve code modularity and customization by allowing developers to define and use functions inline without needing to create separate named methods.
            //This promotes modularity by keeping related logic together, making it easier to understand and maintain.

            #endregion

            #region Problem 18

            int subResult = FunctionalUtilities.PerformMath(20, 8, delegate (int a, int b) {
                return a - b;
            });

            Console.WriteLine(subResult + "\n");

            //When should you prefer anonymous functions over named methods in implementing mathematical operations? 
            //Anonymous functions should be preferred over named methods when the operation is simple and only used in a specific context, as it can improve readability by keeping the logic close to where it is used.

            #endregion

            #region Problem 19

            List<string> containsO = FunctionalUtilities.FilterStrings(strList, s => s.Contains("o") || s.Length > 3);

            foreach (var s in containsO) Console.Write(s + " ");
            Console.WriteLine("\n");

            //What makes lambda expressions an essential feature in modern C# programming? 
            //Lambda expressions are an essential feature in modern C# programming because they provide a concise and expressive way to represent anonymous functions, enabling developers to write more readable and maintainable code.

            #endregion

            #region Problem 20

            double divResult = FunctionalUtilities.PerformDoubleMath(15.0, 2.0, (x, y) => x / y);

            Console.WriteLine(divResult + "\n");

            //How do lambda expressions enhance the expressiveness of mathematical computations in C#?
            //Lambda expressions enhance the expressiveness of mathematical computations in C# by allowing developers to define complex operations inline, directly within the context of the computation.

            #endregion

            #region part 02
            /*
             * 
             * LinkedIn article about Delegates in implementing functional paradigm  => done

              Search about these topics (Parallel Programming and Concurrency - Unit Testing and 
              Test-Driven Development (TDD) - Asynchronous Programming with async and await) => done
                        
            */
            #endregion

            #region part 03
            //2- what is Asynchronous programming 
            /* Asynchronous programming is a programming paradigm that allows for non-blocking operations, enabling a program to perform tasks concurrently without waiting for each task to complete before moving on to the next one. 
            * It is particularly useful for I/O-bound operations, such as reading from a file or making network requests, where the program can continue executing other code while waiting for the operation to finish. 
            * In C#, asynchronous programming is often implemented using the async and await keywords, which simplify the process of writing asynchronous code by allowing developers to write code that looks synchronous while still being non-blocking.
            */
            #endregion




        }
    }

    public delegate string StringTransformer(string input);
    public delegate int MathOperation(int a, int b);
    public delegate R GenericTransformer<T, R>(T input);

    static class FunctionalUtilities
    {
        public static List<string> TransformStrings(List<string> list, StringTransformer transformer)
        {
            return list.Select(s => transformer(s)).ToList();
        }

        public static int PerformMath(int a, int b, MathOperation operation)
        {
            return operation(a, b);
        }

        public static double PerformDoubleMath(double a, double b, Func<double, double, double> operation)
        {
            return operation(a, b);
        }

        public static List<R> TransformGeneric<T, R>(List<T> list, GenericTransformer<T, R> transformer)
        {
            return list.Select(item => transformer(item)).ToList();
        }

        public static List<TResult> ApplyFunc<T, TResult>(List<T> list, Func<T, TResult> func)
        {
            return list.Select(func).ToList();
        }

        public static void ApplyAction<T>(List<T> list, Action<T> action)
        {
            foreach (var item in list) action(item);
        }

        public static List<T> FilterList<T>(List<T> list, Predicate<T> predicate)
        {
            return list.FindAll(predicate);
        }

        public static List<string> FilterStrings(List<string> list, Func<string, bool> condition)
        {
            return list.Where(condition).ToList();
        }
    }
}