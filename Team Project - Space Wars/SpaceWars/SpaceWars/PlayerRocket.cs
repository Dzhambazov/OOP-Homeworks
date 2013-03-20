using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWars
{
    public class PlayerRocket: PlayerWeapons
    {
        public PlayerRocket(MatrixCoords topLeft, char[,] body, int directionVertical, int directionHorizontal)
            : base(topLeft, new[,] { { '|' } }, directionVertical, directionHorizontal)
        {
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<Debris> debris = new List<Debris>();
            if (this.IsDestroyed)
            {
                debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 1, this.topLeft.Col), 5));
                debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 1, this.topLeft.Col - 1), 5));
                debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 1, this.topLeft.Col + 1), 5));
                debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 2, this.topLeft.Col - 1), 5));
                debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 2, this.topLeft.Col + 1), 5));
                debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 3, this.topLeft.Col), 5));
                debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 3, this.topLeft.Col - 1), 5));
                debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 3, this.topLeft.Col + 1), 5));
                return debris;
            }
            return debris;
        }
    }
}
