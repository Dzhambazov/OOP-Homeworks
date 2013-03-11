using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Player
    {
        private string alias;
        private double money;


        public Player(string alias, double money)
        {
            this.alias = alias;
            this.money = money;
        }


        public string Alias
        {
            get { return alias; }
            set
            {
                if (value.Length > 4)
                {
                    this.alias = value;
                }
                else
                {
                    throw new ArgumentException("Name should be at least 5 symbols !");
                }
            }
        }

        public double Money
        {
            get { return money; }
            set
            {
                this.money = value;
            }
        }
    }
}
