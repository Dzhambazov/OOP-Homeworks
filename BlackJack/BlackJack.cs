using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class BlackJack
    {
        public List<Card> playerCards = new List<Card>(); //player cards
        public List<Card> dealerCards = new List<Card>(); // dealer cards
        public Card[] deck; // my deck
        public List<int> usedCards = new List<int>(); // all used cards
        private int playerCount = 0; // player count
        private int dealerCount = 0; // dealer count
        public Deck newDeck = new Deck(); 

        //Constructor
        public BlackJack()
        {
            this.deck = newDeck.StandartDeck;
        }

        //returns player's count
        public int PlayerCount
        {
            get
            {
                int count = 0;
                int acesCount = 0; // aces in player
                foreach (var card in playerCards)
                {
                    if (card.Value == 11)
                    {
                        acesCount++;
                        continue;
                    }
                    count += card.Value;
                }
                for (int i = 0; i < acesCount; i++) // calc aces in the end cause ot their multiple value
                {
                    if (count < 11)
                    {
                        count += 11; // here the ace has value of 11
                    }
                    else
                    {
                        count += 1; // here the ace has value of 1
                    }
                }
               return this.playerCount = count;
            }
        }

        //returns dealer's count
        public int DealerCount       ////////////////////////////////// Problem here calc aces too, will be fixed
        {
            get
            {
                int count = 0;
                foreach (var card in dealerCards)
                {
                    count += card.Value;
                }
                return count;
            }
        }

        // Place bet
        public int PlaceBet(Player player)
        {
            int bet = 0;
            do
            {
                Console.Write("Place your bet please: ");
                bet = int.Parse(Console.ReadLine());
                if (bet > player.Money) // is the bet possible
                {
                    Console.WriteLine("Not enough funds !");
                }
                else
                {
                    player.Money = player.Money - bet; // player's balance - bet
                    return bet;
                }
            }
            while (bet > player.Money);
            return 0;
        }

        //playing as many games as the player wants to play, while "exit" is typed it stops
        public void Game(Player player)
        {
            do
            {
                StartGame(player);
                Console.WriteLine("Type any button to continue playing");
                Console.WriteLine("Type exit to quit");
                string play = Console.ReadLine();
                playerCards.Clear();
                dealerCards.Clear();
                if (play == "exit")
                {
                    break;
                }
            }
            while(true);
        }
        
        //one game cycle - could be played N number of times, player's balance is saved!
        public void StartGame(Player player)
        {
            int bet = PlaceBet(player);
            Console.WriteLine(player.Alias + " " + player.Money);
            Console.WriteLine("Bet: " + bet);
            FirstDeal();
            Console.WriteLine("Player Cards");
            PrintCards(playerCards);
            Console.WriteLine("{0}: {1}",player.Alias,PlayerCount);
            Console.WriteLine("Dealer Cards");
            Console.WriteLine("-------------");
            Console.WriteLine("Faced down card  | " + dealerCards[0]);
            Console.WriteLine("Dealer: {0}",dealerCards[0].Value);
            if (playerCount == 21)
            {
                PlayerWins(player,bet,2.5);
            }
            else
            {
                Console.WriteLine("Plase select  hit / double / stand");
                string action = Console.ReadLine();
                if (action == "double")
                {
                    if (player.Money >= bet)
                    {
                        player.Money -= bet;
                        DoubleAction(player);
                    }
                    else
                    {
                        NormalAction(player, "hit");
                    }
                    
                }
                else
                {
                    NormalAction(player,action);
                }


                PrintCards(dealerCards);
                Console.WriteLine("Dealer: {0}",DealerCount);
                if (playerCount < 21)
                {
                    while (DealerCount < 17)
                    {
                        DealDealerCard();
                        PrintCards(dealerCards);
                        Console.WriteLine("Dealer: {0}", DealerCount);
                    }
                    if (DealerCount > 21)
                    {
                        PlayerWins(player, bet, 2);
                    }
                    else if (PlayerCount > DealerCount)
                    {
                        PlayerWins(player, bet, 2);

                    }
                    else if (PlayerCount == DealerCount)
                    {
                        Console.WriteLine("Split! You received back: {0}", bet);
                        player.Money += bet;
                    }
                    else
                    {
                        Console.WriteLine("You lost!");
                    }
                }
                else if(playerCount == 21 && dealerCount == 21)
                {
                    Console.WriteLine("Split !");
                    PlayerWins(player, bet, 2);
                }
                else if (playerCount == 21 && dealerCount != 21)
                {
                    PlayerWins(player, bet, 2);
                }
            }
                playerCards.Clear(); //clear player cards
                dealerCards.Clear(); //clear dealer cards
                
        }

        // "Double" action  -  possible just one time after first two cards !
        public void DoubleAction(Player player)
        {
            if (playerCount < 21)
            {
                DealPlayerCard();
                PrintCards(playerCards);
                Console.WriteLine("{0}: {1}", player.Alias, PlayerCount);
            }
        }

        //Normal game (no double, no split)
        public void NormalAction(Player player, string act)
        {
            int counter = 0;
            do
            {
                if (playerCount < 21)
                {
                    string action = "";
                    if (counter == 0)
                    {
                        action = act;
                    }
                    else
                    {
                        Console.WriteLine("Select your action hit / stand");
                        action = Console.ReadLine();
                    }
                    if (action == "hit")
                    {
                        DealPlayerCard();
                        PrintCards(playerCards);
                        Console.WriteLine("{0}: {1}", player.Alias, PlayerCount);
                    }
                    if (action == "stand")
                    {
                        break;
                    }
                }
                else if (playerCount == 21)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Busted !  You lost !");
                    break;
                }
                counter++;
            }
            while (true);
        }

        //player win
        public void PlayerWins(Player player,int bet, double multiplier)
        {
            Console.WriteLine("You've just won: {0}", bet*multiplier);
            player.Money += (bet * multiplier);
        }

        //first deal - four cards two for player and two for dealer
        public void FirstDeal()
        {
            playerCards.Add(DealCard());
            dealerCards.Add(DealCard());
            playerCards.Add(DealCard());
            dealerCards.Add(DealCard());
        }

        

        //test print all cards
        public void PrintCards(List<Card> cards)
        {
            Console.WriteLine("-------------");
            foreach (var card in cards)
            {
                Console.WriteLine(card);
            }
        }

        //Deal cards to dealer
        public  void DealDealerCard()
        {
            dealerCards.Add(DealCard());
        }


        //deal cards to player
        public void DealPlayerCard()
        {
            playerCards.Add(DealCard());
        }

        //deal random card from the deck
        public Card DealCard()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            int randomCard = random.Next(1, 52); // generate a random card
            //skip used card
            while (usedCards.Contains(randomCard))
            {
                randomCard = random.Next(1, 52);
            }
            usedCards.Add(randomCard); // add the card to used cards
            return deck[randomCard];
        }
    }
}