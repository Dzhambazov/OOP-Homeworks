using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Person
{
    class Person
    {
        private string name;
        private byte? age;

        public Person(string name, byte? age = null)
        {
            this.name = name;
            this.age = age;
        }

        public string Name
        {

            get { return this.name; }
        }

        public byte? Age
        {
            get { return this.age; }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Name: " + this.Name);
            if (this.Age != null)
            {
                result.AppendLine("Age: " + this.Age);
            }
            else
            {
                result.AppendLine("Age is not specified !");
            }
            return result.ToString();
        }

        public static void Main()
        {
            Person person = new Person("Pesho", 20);
            Console.WriteLine(person);

            Person person2 = new Person("Gosho");
            Console.WriteLine(person2);
        }
    }
}
