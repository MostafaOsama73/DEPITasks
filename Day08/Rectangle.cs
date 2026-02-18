using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08
{
    internal class Rectangle : AbstractShape
    {
        private int v1;
        private int v2;

        public Rectangle(int v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public double Width { get; set; }
        public double Height { get; set; }
        public override double GetArea() => Width * Height;
    }
}
