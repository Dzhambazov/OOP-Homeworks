using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human
{
    class Student : Human
    {
        public byte Grade { get; set; }
        public Student(string firstName, string lastName, byte grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public override string ToString()
        {
            string result = this.FirstName + " " + this.LastName + " " + this.Grade;
            return result;
        }
    }
}
