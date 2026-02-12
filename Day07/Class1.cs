using System;

namespace Day07
{
    public class Class1
    {
        static void Main(string[] args)
        {
            #region Problem1
            Car car = new Car();
            car.id = 1;
            car.Brand = "BMW";
            car.Price = 500000;

            Console.WriteLine($"Car id: {car.id}, Brand: {car.Brand}, Price: {car.Price}");

            Car car2 = new Car() { id = 2, Brand = "Audi", Price = 400000 };
            Console.WriteLine($"Car id: {car2.id}, Brand: {car2.Brand}, Price: {car2.Price}");

            Car car3 = new Car() { id = 3, Brand = "Mercedes" };
            Console.WriteLine($"Car id: {car3.id}, Brand: {car3.Brand}, Price: {car3.Price}");

            Car car4 = new Car() { id = 4 };
            Console.WriteLine($"Car id: {car4.id}, Brand: {car4.Brand}, Price: {car4.Price}");

            // Question: Why does defining a custom constructor suppress the default constructor in C#? 
            /*
             Defining a custom constructor in C# suppresses the default (parameterless) constructor 
            primarily because it indicates that the class cannot be correctly initialized without specific parameters [1, 2, 3]. 
             */
            #endregion

            #region problem2
            Calculator calc = new Calculator();

            int result1 = calc.Sum(10, 20);
            Console.WriteLine($"Result: {result1}\n");

            int result2 = calc.Sum(10, 20, 30);
            Console.WriteLine($"Result: {result2}\n");

            double result3 = calc.Sum(5.5, 10.5);
            Console.WriteLine($"Result: {result3}\n");

            // Question: How does method overloading improve code readability and reusability?  
            /*
             Method overloading improves code readability and reusability by allowing multiple methods with the same name but different parameters to coexist in a class.
            */

            #endregion

            #region problem3
            Child child = new Child(1, 2, 3);
            Console.WriteLine($"Child properties: X={child.X}, Y={child.Y}, Z={child.Z}");

            // Question: What is the purpose of constructor chaining in inheritance?  
            /*
             Constructor chaining in inheritance allows a derived class to call a constructor of its base class to ensure that the base class is properly initialized before the derived class adds its own initialization logic.
            */

            #endregion

            #region Problem4
            Child child1 = new Child(1, 2, 3);
            Console.WriteLine($"Product: {child1.Product()}");

            // Question: How does new differ from override in method overriding?  
            /*
             The new keyword in method overriding hides a member of the base class, while the override keyword provides a new implementation for a virtual method defined in the base class.
            */
            #endregion

            #region Problem5
            Parent parent = new Parent(1, 2);
            Console.WriteLine(parent.ToString());

            Child child2 = new Child(1, 2, 3);
            Console.WriteLine(child2.ToString());

            // Question: Why is ToString() often overridden in custom classes? 
            /*
             ToString() is often overridden in custom classes to provide a meaningful string representation of the object,
            which can be useful for debugging, logging, or displaying information about the object in a user-friendly format.
            */
            #endregion

            #region problem6
            Rectangle rectangle = new Rectangle(5, 10);

            rectangle.Draw();

            Console.WriteLine($"Area of the rectangle: {rectangle.Area}");

            // Question: Why can't you create an instance of an interface directly?  
            /*
             You cannot create an instance of an interface directly because an interface is a contract that defines a set of methods and properties that a class must implement, but it does not provide any implementation itself. 
            */
            #endregion

            #region problem7
            Circle circle = new Circle(5);

            circle.Draw();

            Console.WriteLine($"Area of the circle: {circle.Area}");

            IShape shape = circle;
            shape.PrintDetails();

            // Question: What are the benefits of default implementations in interfaces introduced in C# 8.0?  
            /*
             Default implementations in interfaces introduced in C# 8.0 provide several benefits, including:
            */
            #endregion

            #region problem8
            Vehicle vehicle = new Vehicle("Tesla");
            
            IMovable movable = vehicle;

            movable.Move();

            // Question: Why is it useful to use an interface reference to access implementing class methods?  
            /*
             Using an interface reference to access implementing class methods is useful because it allows for abstraction and decoupling of code.
                It enables you to write code that can work with any class that implements the interface, promoting flexibility and maintainability.
            */
            #endregion

            #region problem9
            File myFile = new File("data.txt");

            myFile.Write("Hello World");
            myFile.Read();

            IReadable reader = myFile;
            reader.Read();

            IWritable writer = myFile;
            writer.Write("Overwritten Data");

            reader.Read();

            // Question: How does C# overcome the limitation of single inheritance with interfaces?  
            /*
             C# overcomes the limitation of single inheritance with interfaces by allowing a class to implement multiple interfaces.
                This means that a class can inherit
                the behavior defined in multiple interfaces, providing a way to achieve polymorphism and code reuse without the need for multiple inheritance of classes.
            */
            #endregion

            #region problem10
            Rectangle2 myRect = new Rectangle2(10, 5);

            myRect.Draw(); 

            double area = myRect.CalculateArea(); 
            Console.WriteLine($"Area: {area}");

            Shape s = new Rectangle2(4, 4); 
            s.Draw();

            // Question: What is the difference between a virtual method and an abstract method in C#? 
            /*
             A virtual method in C# is a method that has an implementation in the base class and can be overridden in derived classes, while an abstract method is a method that does not have an implementation in the base class and must be overridden in derived classes.
            */
            #endregion

            #region Part 2
            //What is the difference between class and struct in C#? 
            /*
             The main differences between a class and a struct in C# are:
                1. Memory Allocation: Classes are reference types and are allocated on the heap, while structs are value types and are allocated on the stack.
                2. Inheritance: Classes support inheritance, allowing you to create a new class that inherits from an existing class, while structs do not support inheritance.
                3. Default Constructor: Classes can have a default constructor that initializes fields to default values, while structs cannot have a default constructor and their fields are automatically initialized to default values.
                4. Performance: Structs can be more efficient than classes for small data structures because they avoid the overhead of heap allocation and garbage collection, but they can also lead to performance issues if they are large or frequently copied.
            */

            //If inheritance is relation between classes clarify other relations between classes
            /*
             In addition to inheritance, there are several other relationships between classes in C#:
                1. Association: This is a relationship where one class uses another class as part of its functionality. For example, a Car class may have an Engine class as part of its implementation.
                2. Aggregation: This is a special form of association where one class contains another class as a part of its state. For example, a Library class may contain multiple Book classes.
                3. Composition: This is a stronger form of aggregation where the contained class cannot exist independently of the containing class. For example, a House class may contain Room classes, and the Room classes cannot exist without the House class.
                4. Dependency: This is a relationship where one class depends on another class for its functionality. For example, a CustomerService class may depend on a Database class to retrieve customer information.
            */


            #endregion

            #region Part 3
            //2- what is static and dynamic binding 
            /*
             Static binding (also known as early binding) occurs when the method to be called is determined at compile time. This happens when you call a method on an object that is of a specific type, and the method is not overridden in any derived class. The compiler knows exactly which method to call based on the type of the reference.
             Dynamic binding (also known as late binding) occurs when the method to be called is determined at runtime. This happens when you call a method on an object that is of a base class type, but the actual object is of a derived class type that overrides the method. The decision about which method to call is made at runtime based on the actual type of the object.
            */
            #endregion





        }
    }
}
