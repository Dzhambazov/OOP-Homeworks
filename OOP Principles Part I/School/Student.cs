using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Student : Person
    {
        public string ClassNumber { get; set; }

        public Student(string firstName, string middleName, string lastName, string classNumber)
            : base(firstName, middleName, lastName)
        {
            this.ClassNumber = classNumber;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(this.FirstName + " " + this.MiddleName + " " + this.LastName + " " +  this.ClassNumber);
            return result.ToString();
        }
    }
}
