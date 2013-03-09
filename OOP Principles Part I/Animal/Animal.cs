using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal
{
    public enum Sex
    {
        male, female
    }
    abstract class Animal : ISound
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Sex sex { get; set; }

        public Animal(string name, int age, Sex sex)
        {
            this.Name = name;
            this.Age = age;
            this.sex = sex;
        }

        public abstract string ProduceSound();
        
    }
}
