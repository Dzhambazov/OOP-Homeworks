using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceWars
{
    public class Engine
    {
        IRenderer renderer;
        IUserInterface userInterface;
        List<GameObject> allObjects;
        List<MovingObject> movingObjects;
        List<GameObject> staticObjects;
        PlayerShip playerShip;
        private static int destroyedUnits;
        private static int bossCount = 0;

        public static int BossCount
        {
            get { return bossCount; }
            set { bossCount = value; }
        }

        public static int DestroyedUnits
        {
            get { return Engine.destroyedUnits; }
            private set { Engine.destroyedUnits = value; }
        }

        private int startingLife;
        public Engine(IRenderer renderer, IUserInterface userInterface)
        {
            this.renderer = renderer;
            this.userInterface = userInterface;
            this.allObjects = new List<GameObject>();
            this.movingObjects = new List<MovingObject>();
            this.staticObjects = new List<GameObject>();
        }

        private void AddStaticObject(GameObject obj)
        {
            this.staticObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        private void AddMovingObject(MovingObject obj)
        {
            this.movingObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        public virtual void AddObject(GameObject obj)
        {
            if (obj is MovingObject)
            {
                if (obj is SpaceShip)
                {
                    AddSpaceShip(obj);
                }
                else
	            {
                    this.AddMovingObject(obj as MovingObject);
	            }
            }
            else
            {
                this.AddStaticObject(obj);
            }
        }

        private void AddSpaceShip(GameObject obj)
        {
            if (obj is PlayerShip) 
            {
                this.playerShip = obj as PlayerShip;
            }
            this.AddStaticObject(obj);
        }

        public virtual void MovePlayerSpaceShipLeft()
        {
            this.playerShip.MoveLeft();
        }

        public virtual void MovePlayerRacketRight()
        {
            this.playerShip.MoveRight();
        }

        public virtual void SpaceShipShoot()
        {
            this.playerShip.Shoot();
        }

        public virtual void SpaceShipShootRocket()
        {
            this.playerShip.ShootRocket();
        }

        public virtual void SpaceShipShootSuperRocket()
        {
            this.playerShip.ShootSuperRocket();
        }

        public virtual void SpaceShipShootLeftBlaster()
        {
            this.playerShip.ShootLeftBlaster();
        }

        public virtual void SpaceShipShootRightBlaster()
        {
            this.playerShip.ShootRightBlaster();
        }
        public virtual void Run()
        {
            while (true)
            {
                this.renderer.RenderAll();

                System.Threading.Thread.Sleep(50);

                this.userInterface.ProcessInput();

                this.renderer.ClearQueue();

                foreach (var obj in this.allObjects)
                {
                    obj.Update();
                    this.renderer.EnqueueForRendering(obj);
                }

                CollisionDispatcher.HandleCollisions(this.movingObjects, this.staticObjects);

                List<GameObject> producedObjects = new List<GameObject>();

                foreach (var obj in this.allObjects)
                {
                    producedObjects.AddRange(obj.ProduceObjects());
                }

                var enemies =
                    from enemy in this.allObjects
                    where enemy.IsDestroyed && enemy is SpaceShip
                    select enemy;
                Engine.destroyedUnits += enemies.Count();

                this.allObjects.RemoveAll(obj => obj.IsDestroyed);
                this.movingObjects.RemoveAll(obj => obj.IsDestroyed);
                this.staticObjects.RemoveAll(obj => obj.IsDestroyed);

                foreach (var obj in producedObjects)
                {
                    this.AddObject(obj);
                }
                Console.WriteLine();

                // Player Ship start life
                this.startingLife = playerShip.StartingLife;


                // prints lifes
                for (int i = 0; i < playerShip.GetLife; i++) // Fixed
                {
                    Console.Write('\u2665');
                }

                // prints blank spaces
                for (int i = 0; i < SpaceWarsMain.WorldCols-20; i++)
                {
                    Console.Write(' ');
                }
                Console.WriteLine();
                Console.WriteLine("Score {0}", destroyedUnits * 10);
                // prints game over
                if (playerShip.GetLife <= 0)
                {
                    Console.WriteLine("Game Over");
                }
                


                // On Game Over remove all objects no matter destroyed or not !
                if (playerShip.IsDestroyed)
                {
                    allObjects.RemoveAll(obj => obj.IsDestroyed == false);
                }

                var enemiess =
                    from enemy in this.allObjects
                    where enemy is SpaceShip
                    select enemy;

                if (enemiess.Count() == 1)
                {
                    Console.WriteLine("You Won " + " ");
                }
                Console.WriteLine();
                 
            }
        }
    }
}