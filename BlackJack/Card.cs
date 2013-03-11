using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Card
    {

        public CardName Name { get; set; }
        public CardSuit Suit { get; set; }
        private int value = 0;

        public int Value // each card has value in BJ, Ace could be 1 and 11
        {
            get
            {
                switch (this.Name.ToString())
                {
                    case "Deuce":
                        return 2;
                    case "Three":
                        return 3;
                    case "Four":
                        return 4;
                    case "Five":
                        return 5;
                    case "Six":
                        return 6;
                    case "Seven":
                        return 7;
                    case "Eight":
                        return 8;
                    case "Nine":
                        return 9;
                    case "Ten":
                        return 10;
                    case "Jack":
                        return 10;
                    case "Queen":
                        return 10;
                    case "King":
                        return 10;
                    case "Ace":
                        return 11;
                }
                return 0;
            }
        }

        public Card(CardName name, CardSuit suit)
        {
            this.Name = name;
            this.Suit = suit;
        }
        public override string ToString()
        {
            return this.Name.ToString() + " of " + this.Suit.ToString();
        }
    }
}
