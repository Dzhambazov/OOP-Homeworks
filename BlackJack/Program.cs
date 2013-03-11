using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{

    class Program
    {

        static void Main(string[] args)
        {
            Console.Write("Player Name: ");
            string name = Console.ReadLine();
            Console.Write("Money: ");
            int money = int.Parse(Console.ReadLine());
            Player player = new Player(name, money);
            BlackJack jack = new BlackJack();
            jack.Game(player);
             
        }
    }
}
