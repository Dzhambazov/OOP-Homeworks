using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWars
{
    public abstract  class SpaceShip: MovingObject, IShootable
    {
        protected bool bulletFired = false;
        protected bool superRocketFired = false;
        protected uint superRocketCount = 1;
        protected bool rocketFired = false;
        protected bool leftBlasterFired = false;
        protected bool rightBlasterFired = false;
        protected int life;
        protected int startingLife;
        public new const string CollisionGroupString = "SpaceShip";

        public SpaceShip(MatrixCoords topLeft, char [,] body,MatrixCoords speed, int life)
            : base(topLeft, body, speed)
        {
            this.life = life;
            this.startingLife = life;
        }

        public int StartingLife
        {
            get { return this.startingLife; }
        }

        public override string GetCollisionGroupString()
        {
            return SpaceShip.CollisionGroupString;
        }


        public virtual char[,] GetSpaceShipBody()
        {
            char[,] sth = new char[,] {
                {'l'},
                {'j'}
            };
            return sth;
        }



        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == PlayerShip.CollisionGroupString;
        }

        public void Shoot()
        {
            this.bulletFired = true;
        }

        public void ShootRocket()
        {
            this.rocketFired = true;
        }

        public void ShootSuperRocket()
        {
            this.superRocketFired = true;
        }

        public void ShootLeftBlaster()
        {
            this.leftBlasterFired = true;
        }

        public void ShootRightBlaster()
        {
            this.rightBlasterFired = true;
        }


        public override void RespondToCollision(CollisionData collisionData)
        {
            this.life--;
            if (life <= 0)
            {
                IsDestroyed = true;
            }
        }
    }
}