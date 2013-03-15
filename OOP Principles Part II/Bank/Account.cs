using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    abstract class Account
    {
        public Customer Customer { get; set; }
        public decimal Balance { get; set; }
        public decimal InterestRate { get; set; }

        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

         
 
       
        public virtual decimal InterestAmount(int months)
        {
            if (months > 0)
            {
                return this.Balance * (this.InterestRate / 100) * months;
            }
            return 0;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(this.Customer.ToString());
            result.AppendLine("Balance: " + this.Balance + " lv.");
            result.AppendLine("Interest rate: " + this.InterestRate + " % / Month");
            return result.ToString();
        }
        
    }
}
