using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Test
    {
        public static void Main()
        {
            IndividualCustomer customer = new IndividualCustomer("Pesho Peshev",26);
            CompanyCustomer companyCustomer = new CompanyCustomer("Arkada 2012");

            DepositAcc Arkada2012Deposit = new DepositAcc(companyCustomer,19000,1.2M);
            LoanAcc Arkada2012Loan = new LoanAcc(companyCustomer,100000,1.5M); 
            LoanAcc loanAcc = new LoanAcc(customer, 400, 0.8M);

            Bank DjambazovBank = new Bank("DjambazovBank", "Sofia, bul. Vitosha 20", "Sofia, bul. Evtimii 59");
            DjambazovBank.AddAccount(Arkada2012Deposit);
            DjambazovBank.AddAccount(Arkada2012Loan);
            DjambazovBank.AddAccount(loanAcc);


            Arkada2012Deposit.DepositMoney(18900);
            Arkada2012Deposit.WithdrawMoney(1499);
            loanAcc.DepositMoney(259);

            Console.WriteLine("Calc Interest Amount for 2 years");
            Console.WriteLine(Arkada2012Deposit.InterestAmount(24));
            Console.WriteLine();
            Console.WriteLine("Print bank info");
            Console.WriteLine();
            Console.WriteLine(DjambazovBank);


            // out ot funds
            Arkada2012Deposit.WithdrawMoney(9999999);
  

        }
    }
}
