using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceWars
{
    public class LeftBlaster : PlayerWeapons
    {
        public LeftBlaster(MatrixCoords topLeft, int directionVertical, int directionHorizontal)
            : base(topLeft, new[,] { { '\\' } }, directionVertical, directionHorizontal)
        {
        }
    }
}
