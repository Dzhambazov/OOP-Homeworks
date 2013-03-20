using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWars
{
    public class SpaceWarsMain
    {
        public const int WorldRows = 40;
        public const int WorldCols = 60;
        //static int timer = 10;

        static void Initialize(Engine engine)
        {
            Console.SetWindowSize(75, 50);
            //int startRow = 1;
            //int startCol = 1;
            //int endCol = WorldCols - 1;

            Scout scout = new Scout(new MatrixCoords(3, 6), 1);
            engine.AddObject(scout);
            Scout scout2 = new Scout(new MatrixCoords(3, 37), 1);
            engine.AddObject(scout2);
            Raider enemy = new Raider(new MatrixCoords(1, 16), 5);
            engine.AddObject(enemy);
            Raider enemy2 = new Raider(new MatrixCoords(2, 25), 4);
            engine.AddObject(enemy2);
            Raider enemy3 = new Raider(new MatrixCoords(6, 1), 3);
            engine.AddObject(enemy3);
            Raider enemy4 = new Raider(new MatrixCoords(7, 56), 1);
            engine.AddObject(enemy4);
            //Battlecruiser battle = new Battlecruiser(new MatrixCoords(15, 30),10);
            //engine.AddObject(battle);
            PlayerShip spaceShip = new PlayerShip(new MatrixCoords(WorldRows - 4, WorldCols / 2));
            engine.AddObject(spaceShip);
        }

        

        static int RandomShip()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            int number = random.Next(-1, 2);
            return number;
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerSpaceShipLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.SpaceShipShoot();
            };

            keyboard.OnEnterPressed += (sender, eventInfo) =>
            {
                gameEngine.SpaceShipShootRocket();
            };

            keyboard.OnRPressed += (sender, eventInfo) =>
            {
                gameEngine.SpaceShipShootSuperRocket();
            };

            keyboard.OnZPressed += (sender, eventInfo) =>
            {
                gameEngine.SpaceShipShootLeftBlaster();
            };

            keyboard.OnXPressed += (sender, eventInfo) =>
            {
                gameEngine.SpaceShipShootRightBlaster();
            };

             
            

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
