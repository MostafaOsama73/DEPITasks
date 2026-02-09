using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Day06
{
    public class TypeA
    {
        public int H;
        internal int G;
        private int F;

        public int showPrivate()
        {
            return F;
        }
    }
}
