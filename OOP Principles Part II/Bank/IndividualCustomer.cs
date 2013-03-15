using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class IndividualCustomer : Customer
    {
        private int age;
        public IndividualCustomer(string name, int age)
            : base(name)
        {
            this.age = age;
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 18 && value > 110)
                {
                    throw new ArgumentException("Wrong age Customer's age should be btw 18 and 110");
                }
                this.age = value;
            }
        }

        
    }
}
