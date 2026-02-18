using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08.Part02
{
    public class SortableShape : IComparable<SortableShape>
    {
        public string Name { get; set; }
        public double Area { get; set; }

        public int CompareTo(SortableShape other)
        {
            if (other == null) return 1;
            return this.Area.CompareTo(other.Area);
        }

        public override string ToString() => $"{Name} (Area: {Area:F2})";
    }
}
