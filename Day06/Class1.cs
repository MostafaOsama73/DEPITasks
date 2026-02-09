using System;

namespace Day06
{
    public class Class1
    {
        static void Main(string[] args)
        {

            #region problem1
            Point p1 = new Point(5, 10);
            Point p2 = new Point(); // Calls the default constructor

            Console.WriteLine($"Point 1: {p1}"); // Output: (5, 10)
            Console.WriteLine($"Point 2: {p2}"); // Output: (0, 0)

            /*
            1. The Fixed Memory Layout (The "Slicing" Problem)
            Structs are Value Types. When you declare a struct, the compiler allocates a specific, fixed amount of memory on the stack (or inline within another object) to hold exactly that data.

            If struct B inherited from struct A, B would presumably be larger than A.

            Because value types are passed by value (copied directly), if you tried to assign an instance of B to a variable of type A, the extra data in B would be "sliced" off and lost, potentially corrupting the logic of the object.

            2. Avoidance of Reference Type Overhead
            The main purpose of a struct is to be a lightweight alternative to a class.

            Classes (Reference Types) support inheritance, which requires an Object Header and a Virtual Method Table (vtable) pointer in memory to handle polymorphism (determining which overridden method to call at runtime).

            Structs are designed to avoid this memory overhead. Adding inheritance support would force structs to carry this metadata, defeating the purpose of using a struct for performance.

            3. Simplicity and Design Intent
            Structs are intended for "atomic" values—small data structures that act like primitive types (like numbers or coordinates).

            Inheritance suggests an "is-a" relationship involving complex behavior extensions.

            Structs are designed for data storage where A = B creates a completely independent copy. Inheritance complicates this copy semantic.
             */
            #endregion

            #region problem2
            TypeA obj = new TypeA();

            // Console.WriteLine(obj.F); // Error: 'TypeA.F' is inaccessible due to its protection level
            obj.showPrivate();           // Allowed: Accessing private via public method
            Console.WriteLine($"Internal G: {obj.G}"); // Allowed: Same project
            Console.WriteLine($"Public H: {obj.H}");   // Allowed: Public

            /*
            private: The strictest level. Variables are visible only inside the class/struct they are defined in. It hides implementation details.

            internal: Visible to any file within the same Assembly (.dll or .exe). Useful for utility classes helper methods that shouldn't be exposed publicly to other libraries.

            public: Visible to everyone. This is the API of your code.
             */
            #endregion

            #region problem3
            Employee emp = new Employee(101, "Alice", 50000);
            emp.Display();

            Console.WriteLine("\n--- Testing Encapsulation ---");
          
            emp.SetName("Bob");
            Console.WriteLine($"Updated Name: {emp.GetName()}");
            /*
            Data Integrity: It prevents invalid data from entering your object (e.g., preventing a negative Salary or a null Name).

            Modularity: You can change the internal implementation (like how Salary is calculated) without breaking the code that uses the Employee object.

            Security: It hides sensitive data (like _salary) from being arbitrarily modified by external code. 
             */
            #endregion

            #region problem4
            Point p3 = new Point(5);      // X=5, Y=0
            Point p4 = new Point(5, 10);  // X=5, Y=10
            Console.WriteLine($"Point 3: {p3}"); // Output: (5, 0)
            Console.WriteLine($"Point 4: {p4}"); // Output: (5, 10)

            /*
             * Crucial Rule: A struct constructor must initialize all fields of the struct before it returns control. You cannot leave any field unassigned.

               Default Constructor: Prior to C# 10, you could not define a parameterless constructor Point(); the compiler provided one implicitly that zeroed out all fields.

            */
            #endregion

            #region problem5
            /*
             Debugging: Instead of printing the type name (e.g., MyProject.Point), you see the actual data values ((5, 10)), which makes debugging significantly faster.

             Simplicity: It allows you to pass the object directly to output functions (like Console.WriteLine(point)) without manually extracting and formatting properties every time.
             */
            #endregion

            #region part2
            /*
             1. What is a Copy Constructor?

                A Copy Constructor is a special constructor that creates a new object by copying the variables (state) from an existing object of the same type.

                In C#, unlike C++, the compiler does not provide a default copy constructor for classes. You must implement it manually if you need it.

                For Structs (Value Types): You rarely need a copy constructor because assigning a struct (StructA = StructB) automatically creates a copy of the data.

                For Classes (Reference Types): Assigning a class (ClassA = ClassB) only copies the reference (memory address), meaning both variables point to the same object. To create a true duplicate (a separate object with the same data), you use a Copy Constructor.
             */

            /*
             2. What is an Indexer?
                An Indexer allows an object to be indexed just like an array using square brackets [].
                It is syntactic sugar that makes your classes more intuitive to use,
                especially when they act as collections or containers of data.
             */

            /*
             4. Summary of Keywords (from typical OOP lectures)                
                Types: struct, class, enum

                Modifiers: public, private, internal, static

                Memory: new (allocation), value type (stack), reference type (heap)

                Methods: void, return, override                             
             */
            #endregion
        }
    }
}
