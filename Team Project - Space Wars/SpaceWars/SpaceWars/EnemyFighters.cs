using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWars
{
    public abstract class EnemyFighters: SpaceShip
    {
        private int aggression;
        private int count = 0;
        private int shootingMoment = 0;
        public new const string CollisionGroupString = "EnemyFighters";
        private MatrixCoords direction = new MatrixCoords(0, -1);

        public EnemyFighters(MatrixCoords topLeft, char[,] body,int life, int aggression)
            : base(topLeft, body, new MatrixCoords(0, 0), life)
        {
            this.aggression = aggression;
            this.count = aggression;
        }

        private bool BossAdded
        {
            get
            {
                if (Engine.DestroyedUnits >= 3)
                {
                     return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public override string GetCollisionGroupString()
        {
            return EnemyFighters.CollisionGroupString;
        }

        public override void Update()
        {
            this.UpdatePosition();
        }

        protected override void UpdatePosition()
        {
                this.count--;
                if (count == 0)
                {
                    this.shootingMoment++;
                    this.count = aggression;
                    if (this.shootingMoment % 5 == 0)
                    {
                        this.Shoot();
                        
                    }
                    if (this.shootingMoment % 12 == 0)
                    {
                        this.ShootRocket();
                    }
                    
                    this.Speed = this.direction;

                    if (this.topLeft.Col >= SpaceWarsMain.WorldCols - 5)
                    {
                            this.direction = new MatrixCoords(RandomDirection(), -1);
                    }
                    else if (this.topLeft.Col <= 3)
                    {
                            this.direction = new MatrixCoords(RandomDirection(), 1);
                    }
                    else if(this.topLeft.Row >= SpaceWarsMain.WorldRows - 12)
                    {
                            this.direction = new MatrixCoords(-1, RandomDirection());
                    }
                    else if (this.topLeft.Row <= 2)
                    {
                            this.direction = new MatrixCoords(1, RandomDirection());
                    }

                    base.UpdatePosition();
                }
        }

        public int RandomDirection()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            int number = random.Next(-1, 2);
            return number;
        }

        public int RandomFighter()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            int number = random.Next(0, 2);
            return number;
        }

        public int RandomRow()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            int number = random.Next(1,5);
            return number;
        }

        public int RandomCol()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            int number = random.Next(3, 58);
            return number;
        }


        public int RandomAgression()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            int number = random.Next(10,15);
            return number;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<MovingObject> enemies = new List<MovingObject>();

            if (Engine.DestroyedUnits % 4 == 0 && Engine.DestroyedUnits != 0)
            {
                enemies.Add(new Gift(this.topLeft));
            }
            
            if (Engine.DestroyedUnits <= 20)
            {
                
                if (RandomFighter() == 0)
                {
                    enemies.Add(new Scout(new MatrixCoords(RandomRow(), RandomCol()), RandomAgression()));
                }
                else
                {
                    enemies.Add(new Raider(new MatrixCoords(RandomRow(), RandomCol()), RandomAgression()));
                }
                return enemies;
            }
            else
            {
                if (this.BossAdded == true && Engine.BossCount < 1)
                {
                    Engine.BossCount++;
                    enemies.Add(new Battlecruiser(new MatrixCoords(3, 20), 1500));
                    //return enemies;
                }
                return enemies;
            }
        }
    }
}
