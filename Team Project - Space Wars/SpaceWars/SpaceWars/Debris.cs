using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWars
{
    public class Debris: MovingObject
    {
        private int lifeTime;
        public Debris(MatrixCoords topLeft, int lifeTime)
            : base(topLeft, new [,] {{'*'}}, new MatrixCoords(0,0))
        {
            if (lifeTime < 0)
            {
                throw new IndexOutOfRangeException("Debris life time can not be negative");
            }
            this.lifeTime = lifeTime;
        }

        public override void Update()
        {
            if (lifeTime == 1)
            {
                this.IsDestroyed = true;
            }
            this.lifeTime--;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == Raider.CollisionGroupString ||
                   otherCollisionGroupString == Scout.CollisionGroupString;
        }
    }
}
