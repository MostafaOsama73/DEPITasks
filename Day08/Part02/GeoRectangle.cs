using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08.Part02
{
    public class GeoRectangle : GeometricShape
    {
        public override double CalculateArea() => Dimension1 * Dimension2;
        public override double Perimeter => 2 * (Dimension1 + Dimension2);
    }
}

