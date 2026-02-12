using System;

namespace Day07
{
    public interface IShape
    {
        double Area { get; }

        void Draw();

        public void PrintDetails()
        {
            Console.WriteLine("\n--- Shape Details ---");
            Console.WriteLine("This is a shape.");
            Console.WriteLine($"Calculated Area: {this.Area}");
            Console.WriteLine("---------------------");
        }
    }

    public class Rectangle : IShape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public double Area
        {
            get { return width * height; }
        }

        public void Draw()
        {
            Console.WriteLine("Drawing a rectangle");
        }
    }

    // Class 2: Circle
    public class Circle : IShape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double Area
        {
            get { return Math.PI * radius * radius; }
        }

        public void Draw()
        {
            Console.WriteLine("Drawing a circle");
        }
    }
}