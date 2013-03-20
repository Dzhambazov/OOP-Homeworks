using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWars
{
   public  class Gift : MovingObject
    {
       public new const string CollisionGroupString = "Gift";
        public Gift(MatrixCoords topLeft)
            : base(topLeft, new [,] {{'G'}}, new MatrixCoords(1, 0))
        {
            this.body = this.GetGiftBody();
        }

        public char[,] GetGiftBody()
        {
            char[,] body = new char[,]
            {
                {'\u2665'}
            };
            return body;
        }

        public override string GetCollisionGroupString()
        {
            return Gift.CollisionGroupString;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == PlayerShip.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
            
        }
    }
}
