using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWars
{
    public abstract class PlayerWeapons: MovingObject
    {
        public new const string CollisionGroupString = "playerWeapon";

        public PlayerWeapons(MatrixCoords topLeft, char[,] body, int directionVertical,int directionHorizontal)
            : base(topLeft, body,new MatrixCoords(directionVertical, directionHorizontal))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == EnemyFighters.CollisionGroupString;
                    
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
    }
}
