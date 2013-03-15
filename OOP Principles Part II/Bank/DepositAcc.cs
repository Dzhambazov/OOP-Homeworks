using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class DepositAcc : Account, IDepositable, IWithdrawable
    {
        public DepositAcc(Customer customer, decimal balance, decimal interestRate)
            : base(customer,balance,interestRate)
        {

        }

        public void DepositMoney(decimal sum)
        {
            this.Balance += sum;
        }

        public void WithdrawMoney(decimal sum)
        {
            if (this.Balance >= sum)
            {
                this.Balance -= sum;
            }
            else
            {
                Console.WriteLine("Not enough funds !");
            }
        }

        public override decimal InterestAmount(int months)
        {
            if (this.Balance >= 1000)
            {
                return base.InterestAmount(months);
            }
            return 0;
        }
    }
}
