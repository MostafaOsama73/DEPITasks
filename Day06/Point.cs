using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06
{
    internal struct Point
    {
        public int X;
        public int Y;

        public Point()
        {
            X = 0;
            Y = 0;
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(int value)
        {
            X = Y = value;
        }

        public Point(int x)
        {
            X = x;
            Y = 0;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }


    }
}
