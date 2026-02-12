using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    public abstract class Shape : IShape
    {
        double IShape.Area => throw new NotImplementedException();

        public virtual void Draw()
        {
            Console.WriteLine("Drawing Shape (Base Implementation)");
        }

        public abstract double CalculateArea();
    }

    public class Rectangle2 : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle2(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public Rectangle2()
        {
        }

        public override void Draw()
        {
            Console.WriteLine($"Drawing Rectangle ({Width} x {Height})");
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }
}

