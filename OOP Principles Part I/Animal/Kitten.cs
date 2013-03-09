using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal
{
    class Kitten : Cat
    {
        public Kitten(string name, int age)
            : base(name,age, Sex.female)
        {

        }
        public override string ProduceSound()
        {
            return "Miaaaau";
        }

    }
}
