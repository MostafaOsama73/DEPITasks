using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08
{
    internal abstract class AbstractShape
    {
        public abstract double GetArea();
        public void DisplayArea()
        {
            Console.WriteLine($"The area of the shape is: {GetArea()}");
        }
    }
}
