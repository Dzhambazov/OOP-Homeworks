using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWars
{
    public class PlayerBullet: PlayerWeapons
    {
        public PlayerBullet(MatrixCoords topLeft, int directionVertical, int directionHorizontal)
            : base(topLeft, new [,] {{'.'}}, directionVertical, directionHorizontal)
        {
        }
    }
}
