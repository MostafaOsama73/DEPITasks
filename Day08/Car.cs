using Day08.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08
{
    internal class Car : IVehicle
    {
        public void StartEngine()
        {
            Console.WriteLine("Starting Car");
        }

        public void StopEngine()
        {
            Console.WriteLine("Stoping Car");
        }
    }
}
