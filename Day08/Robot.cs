using Day08.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08
{
    public class Robot : IWalkable
    {
        public void Run() => Console.WriteLine("Robot is running (Class Method).");

        void IWalkable.Walk()
        {
            Console.WriteLine("Robot is walking (Explicit Interface Method).");
        }
    }
}
