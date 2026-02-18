using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08
{
    internal class Circle : AbstractShape
    {
        private int v;

        public Circle(int v)
        {
            this.v = v;
        }

        public double Radius { get; set; }
        public override double GetArea() => Math.PI * Radius * Radius;
    }
}
