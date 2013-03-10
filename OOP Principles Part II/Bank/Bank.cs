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
        public string Name { get; set; }
        public string CentralOfficeAddress { get; set; }
        public string CloneAddress { get; set; }

        public Bank(string name, string centralOfficeAddress, string cloneAddress)
        {
            this.Name = name;
            this.CentralOfficeAddress = centralOfficeAddress;
            this.CloneAddress = cloneAddress;
        }



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
            result.AppendLine("Bank name: " + this.Name);
            result.AppendLine("Central office: " + this.CentralOfficeAddress);
            result.AppendLine("Clone address: " + this.CloneAddress);
            result.AppendLine();
            result.AppendLine("All Accounts");
            result.AppendLine();

            foreach (var account in Accounts)
            {
                result.AppendLine(account.ToString());
            }
            return result.ToString();
        }
    }
}
