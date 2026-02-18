using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08.Part02
{
    public class Triangle : GeometricShape
    {

        public override double CalculateArea() => 0.5 * Dimension1 * Dimension2;

        public override double Perimeter => Dimension1 + Dimension2 + Math.Sqrt(Dimension1 * Dimension1 + Dimension2 * Dimension2);
    }
}
