using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWars
{
    public class EnemyBullet : EnemyWeapons
    {
        public EnemyBullet(MatrixCoords topLeft, int direction)
            : base(topLeft, new [,] {{'.'}}, direction)
        {
        }
    }
}
