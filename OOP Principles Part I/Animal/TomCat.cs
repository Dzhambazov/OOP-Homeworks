using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal
{
    class TomCat : Cat
    {
        public TomCat(string name, int age)
            : base(name,age,Sex.male)
        {

        }
        public override string ProduceSound()
        {
            return "MQYyyyyyyyyyyyyYyyyyyy";
        }

    }
}
