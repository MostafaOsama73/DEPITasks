using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06
{
    public struct Employee
    {
        private int _empId;
        private string _name;
        private decimal _salary;

        public Employee(int id, string name, decimal salary)
        {
            _empId = id;
            _name = name;
            _salary = salary;
        }
       
        public string GetName() { return _name; }
        public void SetName(string name)
        {
            _name = name;
        }

        public void Display()
        {
            Console.WriteLine($"ID: {_empId}, Name: {_name}, Salary: {_salary:C}");
        }
    }
}
