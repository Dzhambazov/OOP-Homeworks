using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal
{
    abstract class Cat:Animal
    {
         public Cat(string name, int age, Sex sex)
            : base(name,age,sex)
        {

        }
    }
}
