using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region problem 1
            Console.WriteLine(Weekdays.Monday);
            Console.WriteLine(Weekdays.Tuesday);
            Console.WriteLine(Weekdays.Wednesday);
            Console.WriteLine(Weekdays.Thursday);
            Console.WriteLine(Weekdays.Friday);

            //Question: Why is it recommended to explicitly assign values to enum members in some cases? 
            //Answer: Explicitly assigning values to enum members can improve code readability and maintainability. It allows developers to easily understand the intended values of each member, especially when the enum is used in a context where specific values are important (e.g., flags, bitwise operations). Additionally, it can prevent unintended consequences if the order of members changes or if new members are added in the future.

            #endregion

            #region problem 2
        }

    }
}
