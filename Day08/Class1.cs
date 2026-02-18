using Day08.Interfaces;
using Day08.Part02;
using System;
using System.Collections.Generic;

namespace Day08
{
    public class Class1
    {
        public static void PrintTenShapes(IShapeSeries series)
        {
            Console.WriteLine("Printing Series:");
            series.ResetSeries();
            for (int i = 0; i < 10; i++)
            {
                series.GetNextArea();
                Console.WriteLine($"Step {i + 1}: Area = {series.CurrentShapeArea}");
            }
        }
        static void Main(string[] args)
        {
            #region problem 1
            IVehicle car = new Car();
            car.StartEngine();
            car.StopEngine();

            IVehicle bike = new Bike();
            bike.StartEngine();
            bike.StopEngine();

            //Why is it better to code against an interface rather than a concrete class? 
            //Coding against an interface allows for more flexibility and maintainability.
            //It allows you to change the implementation of the class without affecting the code that uses it.
            //It also promotes loose coupling, which makes it easier to test and debug your code.
            #endregion

            #region problem 2
            AbstractShape rect = new Rectangle(5, 10);
            rect.DisplayArea();

            AbstractShape circle = new Circle(5);
            circle.DisplayArea();

            //Question: When should you prefer an abstract class over an interface?  
            //You should prefer an abstract class over an interface when you want to provide a common base implementation for a group of related classes.
            //An abstract class can have both abstract and non-abstract members, while an interface can only have abstract members.
            #endregion

            #region problem 3
            Product[] products = {
                new Product { Id=1, Name="Laptop", Price=1000 },
                new Product { Id=2, Name="Mouse", Price=20 },
                new Product { Id=3, Name="Keyboard", Price=50 }
            };

            Array.Sort(products);

            foreach (var p in products) Console.WriteLine(p);

            //Question: How does implementing IComparable improve flexibility in sorting?  
            //Implementing IComparable allows you to define a natural ordering for your objects, which can be used by sorting algorithms.


            #endregion

            #region problem 4

            Student s1 = new Student { Id = 1, Name = "Mostafa", Grade = 90 };

            Student s2 = new Student(s1); 

            s1.Name = "Updated Name";

            Console.WriteLine($"Original: {s1.Name}, Copy: {s2.Name}");

            //Question: What is the primary purpose of a copy constructor in C#? 
            //The primary purpose of a copy constructor in C# is to create a new object that is a copy of an existing object.
            #endregion

            #region problem 5
            Robot robo = new Robot();

            robo.Run(); 

            ((IWalkable)robo).Walk();

            //Question: How does explicit interface implementation help in resolving naming conflicts?  
            //Explicit interface implementation allows you to implement interface members in a way that they are only accessible through the interface,
            //which helps in resolving naming conflicts when a class implements multiple interfaces with the same member names.
            #endregion

            #region problem 6
            Account acc = new Account(101, "User", 5000);

            Console.WriteLine($"Account Balance: {acc.Balance}");

            //Question: What is the key difference between encapsulation in structs and classes? 
            //The key difference between encapsulation in structs and classes is that structs are value types and classes are reference types.

            //Question: what is abstraction as a guideline, what’s its relation with encapsulation?  
            //Abstraction is the process of hiding the implementation details and showing only the essential features of an object.



            #endregion

            #region problem 7
            ILogger logger = new ConsoleLogger();

            logger.Log("System Failure");

            //Question: How do default interface implementations affect backward compatibility in C#?
            //Default interface implementations allow you to add new members to an interface without breaking existing implementations, which improves backward compatibility in C#.

            #endregion

            #region problem 8
            Book b1 = new Book("C# Deep Dive", "John Doe");

            Console.WriteLine(b1);

            //Question: How does constructor overloading improve class usability?  
            //Constructor overloading allows you to create multiple constructors with different parameters, which improves class usability by providing flexibility in object creation.
            #endregion

            #region Part 2
            IShapeSeries squareSeries = new SquareSeries();

            PrintTenShapes(squareSeries);

            List<SortableShape> shapes = new List<SortableShape>
            {
                new SortableShape { Name = "Small Circle", Area = 12.5 },
                new SortableShape { Name = "Big Rect", Area = 100 },
                new SortableShape { Name = "Tiny Square", Area = 4 }
            };

            shapes.Sort(); 
            Console.WriteLine("\nSorted Shapes:");
            foreach (var s in shapes) Console.WriteLine(s);

            
            GeometricShape t = ShapeFactory.CreateShape("triangle", 10, 20);
            GeometricShape r = ShapeFactory.CreateShape("rectangle", 10, 20);
            Console.WriteLine($"\nFactory Triangle Area: {t.CalculateArea()}");
            Console.WriteLine($"Factory Rectangle Area: {r.CalculateArea()}");

           
            int[] areas = { 50, 10, 40, 20, 30 };
            Sorter.SelectionSort(areas);
            Console.WriteLine("\nSelection Sorted Integers:");
            foreach (var val in areas) Console.Write(val + " ");
            Console.WriteLine();


            //What we mean by coding against interface rather than class ? and if u get it so What we mean by code against abstraction not concreteness ? 
            //Coding against an interface means that you write your code to depend on an interface rather than a concrete class.
            //Coding against abstraction means that you write your code to depend on abstract classes or interfaces rather than concrete implementations, which promotes flexibility and maintainability.

            //Question : What is abstraction as a guideline and how we can implement this through what we have studied ? 
            //Abstraction as a guideline is the principle of hiding the implementation details and showing only the essential features of an object.









            #endregion


        }
    }
}
