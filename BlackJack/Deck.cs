using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Deck
    {
        //string[] suits = { "c", "d", "h", "s" };
        //string[] cards = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        //string[] standartDeck = new string[52];

        private Card[] deck = new Card[52];

        public Deck()
        {
            
        }

        public Card[] StandartDeck
        {
            get
            {

                int index = 0;
                foreach (var suit in Enum.GetValues(typeof(CardSuit)))
                {
                    foreach (var card in Enum.GetValues(typeof(CardName)))
                    {
                        this.deck[index] = new Card((CardName)card, (CardSuit)suit);
                        index++;
                    }
                }
                return this.deck;
            }
        }


        //public Array ShuffledDeck
        //{
        //    get
        //    {
        //        int index = 0;
        //        foreach (var suit in suits)
        //        {
        //            foreach (var card in cards)
        //            {
        //                this.standartDeck[index] = card + suit;
        //                index++;
        //            }
        //        }
        //        return Shuffle(standartDeck);
        //    }
        //}


        //public static string[] Shuffle(string[] array)
        //{
        //    var random = new Random();
        //    for (int i = array.Length; i > 1; i--)
        //    {
        //        int j = random.Next(i);
        //        string tmp = array[j];
        //        array[j] = array[i - 1];
        //        array[i - 1] = tmp;
        //    }
        //    return array;
        //}
    }
}