using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWars
{
    class EnemyRocket : EnemyWeapons
    {
        public EnemyRocket(MatrixCoords topLeft, int direction)
            : base(topLeft, new [,] {{'v'}}, direction)
        {
        }
    }
}
