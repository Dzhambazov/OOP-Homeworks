using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Bank
    {
        public List<Account> Accounts = new List<Account>();


        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }

        public void RemoveAccount(Account account)
        {
            Accounts.Remove(account);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (var account in Accounts)
            {
                result.AppendLine(account.ToString());
            }
            return result.ToString();
        }
    }
}
