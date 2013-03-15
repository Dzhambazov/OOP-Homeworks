using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class LoanAcc : Account, IDepositable
    {
         public LoanAcc(Customer customer, decimal balance, decimal interestRate)
            : base(customer,balance,interestRate)
        {

        }

         public void DepositMoney(decimal sum)
         {
             this.Balance += sum;
         }

         public override decimal InterestAmount(int months)
         {
             if (this.Customer is IndividualCustomer)
             {
                 return base.InterestAmount(months - 3);
             }

             else if(this.Customer is CompanyCustomer)
             {
                 return base.InterestAmount(months - 2);
             }
             return 0;
         }
    }
}
