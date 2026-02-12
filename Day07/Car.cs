using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    internal class Car
    {
        public int id { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }


        public Car()
        {
        }

        public Car(int id)
        {
            this.id = id;
        }

        public Car(int id, string brand)
        {
            this.id = id;
            this.Brand = brand;
        }

        public Car(int id, string brand, decimal price)
        {
            this.id = id;
            this.Brand = brand;
            this.Price = price;
        }
    }
}
