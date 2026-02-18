using Day08.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08
{
    internal class Bike : IVehicle
    {
        public void StartEngine()
        {
            Console.WriteLine("Starting Bike");
        }

        public void StopEngine()
        {
            Console.WriteLine("Stoping Bike");
        }
    }
}
