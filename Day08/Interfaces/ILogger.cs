using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08.Interfaces
{
    public interface ILogger
    {
        void Log(string message)
        {
            Console.WriteLine($"Default Log: {message}");
        }
    }
}
