using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day09.Inhertance
{
    internal class Child : Parent
    {
        public int Z { get; set; }

        public Child(int _X, int _Y, int _Z) : base(_X, _Y)
        {
            //X= _X;
            //Y= _Y;
            Z = _Z;
        }




        // PM : 
        // 1- new (Parent hiding)
        // - Parent hiding > new version
        public new int Product()
        {
            return X * Y * Z;
        }


        // 2- override
        // child : Parent : object
        // // in Parent : public   virtual
        public override string ToString()
        {
            return $"({X},{Y},{Z})";
        }

        public override int Sum()
        {
            return X + Y + Z;
        }
    }
}
