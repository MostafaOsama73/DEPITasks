using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    internal interface IMovable
    {
        void Move();
    }

    public class Vehicle : IMovable
    {
        public string Model { get; set; }

        public Vehicle(string model)
        {
            Model = model;
        }
        public void Move()
        {
            Console.WriteLine("The vehicle is moving");
        }
    }
    
    public class Person : IMovable
    {
        public void Move()
        {
            Console.WriteLine("The person is walking");
        }
    }
}
