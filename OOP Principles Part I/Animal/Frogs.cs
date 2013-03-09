using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal
{
    class Frogs : Animal
    {
        public Frogs(string name, int age, Sex sex)
            : base(name,age,sex)
        {

        }

        public override string ProduceSound()
        {
            return "Kva-Kva";
        }

    }
}
