using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWars
{
    class RightBlaster : PlayerWeapons
    {
        public RightBlaster(MatrixCoords topLeft, int directionVertical, int directionHorizontal)
            : base(topLeft, new[,] { { '/' } }, directionVertical, directionHorizontal)
        {
        }
    }
}
