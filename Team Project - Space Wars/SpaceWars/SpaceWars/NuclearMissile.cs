using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWars
{
    public class NuclearMissile : PlayerRocket
    {
        public NuclearMissile(MatrixCoords topLeft, char[,] body, int directionVertical, int directionHorizontal)
            : base(topLeft, new char[,] {{}}, directionVertical, directionHorizontal)
        {
            this.body = new[,] 
            {
                { '^', '^' },
                { '|', '|' },
                { '/', '\\' }
            };
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<Debris> debris = new List<Debris>();
            if (this.IsDestroyed)
            {
                for (int i = 1; i <= 3; i++)
                {
                    debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 1, this.topLeft.Col), 10));
                    debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 1, this.topLeft.Col - i), 10));
                    debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 1, this.topLeft.Col + i), 10));
                    debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 2, this.topLeft.Col - i), 10));
                    debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 2, this.topLeft.Col + i), 10));
                    debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 3, this.topLeft.Col), 10));
                    debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 3, this.topLeft.Col - i), 10));
                    debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 3, this.topLeft.Col + i), 10));
                    debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 4, this.topLeft.Col), 10));
                    debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 4, this.topLeft.Col - i), 10));
                    debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 4, this.topLeft.Col + i), 10));
                    debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 5, this.topLeft.Col - i), 10));
                    debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 5, this.topLeft.Col + i), 10));
                    debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 6, this.topLeft.Col), 10));
                    debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 6, this.topLeft.Col - i), 10));
                    debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 6, this.topLeft.Col + i), 10));
                    debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 7, this.topLeft.Col), 10));
                    debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 7, this.topLeft.Col - i), 10));
                    debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 7, this.topLeft.Col + i), 10));
                    debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 8, this.topLeft.Col), 10));
                    debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 8, this.topLeft.Col - i), 10));
                    debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 8, this.topLeft.Col + i), 10));
                }
                return debris;
            }
            return debris;
        }
    }
}
