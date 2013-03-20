using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWars
{
    public abstract class EnemyWeapons : MovingObject
    {
        public new const string CollisionGroupString = "EnemyWepons";

        public EnemyWeapons(MatrixCoords topLeft, char[,] body, int direction)
            : base(topLeft, body,new MatrixCoords(direction,0))
        {
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
