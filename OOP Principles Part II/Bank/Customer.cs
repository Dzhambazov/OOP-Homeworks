using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    abstract class Customer
    {
        public string Name { get; set; }
 

        public Customer(string firstName)
        {
            this.Name = firstName;
        }

        public override string ToString()
        {
            return "Owner: " + this.Name;
        }
    }
}
