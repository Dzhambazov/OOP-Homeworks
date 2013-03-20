using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceWars
{
    public class PlayerShip : SpaceShip
    {
        public new const string CollisionGroupString = "PlayerShip";
        
        public PlayerShip(MatrixCoords topLeft) 
            : base(topLeft, new char[,]{{'='}},new MatrixCoords(0,0), 15)
        {
            this.body = GetSpaceShipBody();
        }

        public override char[,] GetSpaceShipBody()
        {
            char[,] body = new char[,]
            {
                {' ',' ','/','|','\\',' ',' '},
                {' ','/','(',' ',')','\\',' '},
                {'/',' ',' ','_',' ',' ','\\'},
                {' ',' ','/',' ','\\',' ',' '}
            };
            return body;
        }

        public override string GetCollisionGroupString()
        {
            return PlayerShip.CollisionGroupString;
        }

        public void MoveLeft()
        {
            this.topLeft.Col--;
            if (this.topLeft.Col <= -3)
            {
                this.topLeft.Col = SpaceWarsMain.WorldCols - 3;
            }
        }

        public void MoveRight()
        {
            this.topLeft.Col++;
            if (this.topLeft.Col >= SpaceWarsMain.WorldCols-3)
            {
                this.topLeft.Col = -3;
            }
        }

        public override void Update()
        {
        }

        public int GetLife
        {
            get
            {
                return this.life;
            }
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<PlayerWeapons> shells = new List<PlayerWeapons>();
            if (base.bulletFired)
            {
                shells.Add(new PlayerBullet(new MatrixCoords(this.topLeft.Row, this.topLeft.Col + 3), -1, 0));
                this.bulletFired = false;
                return shells;
            }
            if (base.rocketFired)
            {
                shells.Add(new PlayerRocket(new MatrixCoords(this.topLeft.Row + 1, this.topLeft.Col + 7), new char[,] { { '|' } }, -2, 0));
                shells.Add(new PlayerRocket(new MatrixCoords(this.topLeft.Row + 1, this.topLeft.Col - 1), new char[,] { { '|' } }, -2, 0));
                this.rocketFired = false;
                return shells;
            }
            if (base.leftBlasterFired)
            {
                shells.Add(new LeftBlaster(new MatrixCoords(this.topLeft.Row, this.topLeft.Col + 3), -1, -1));
                this.leftBlasterFired = false;
                return shells;
            }

            if (base.rightBlasterFired)
            {
                shells.Add(new RightBlaster(new MatrixCoords(this.topLeft.Row, this.topLeft.Col + 3), -1, 1));
                this.rightBlasterFired = false;
                return shells;
            }
            if (base.superRocketCount > 0 && base.superRocketFired)
            {
                shells.Add(new NuclearMissile(new MatrixCoords(this.topLeft.Row - 3, this.topLeft.Col + 3), new char[,] { { } }, -2, 0));
                this.superRocketCount--;
                this.superRocketFired = false;
                return shells;
            }
            return shells;
        }
             public override void RespondToCollision(CollisionData collisionData)
        {

            if (collisionData.hitObjectsCollisionGroupStrings.Contains(Gift.CollisionGroupString))
            {
                this.life++;
            }
            else
            {
                base.RespondToCollision(collisionData);
            }
        }
    }
}
