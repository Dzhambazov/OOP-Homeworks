using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class MortgageAcc : Account, IDepositable
    {
        public MortgageAcc(Customer customer, decimal balance, decimal interestRate)
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
                return base.InterestAmount(months - 6);
            }

            if (this.Customer is CompanyCustomer)
            {
                if (months <= 12)
                {
                    return (this.Balance * (this.InterestRate / 100) * months) / 2;
                }
                else
                {
                    decimal firstTwelve = (this.Balance * (this.InterestRate / 100) * months) / 2;
                    decimal otherMonths = this.Balance * (this.InterestRate / 100) * months; ;
                    return firstTwelve + otherMonths;
                }
            }
            return 0;
        }
    }
}