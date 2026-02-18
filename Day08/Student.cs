using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Grade { get; set; }

        public Student() { }

        public Student(Student other)
        {
            if (other != null)
            {
                this.Id = other.Id;
                this.Name = other.Name; 
                this.Grade = other.Grade;
            }
        }
    }
}
