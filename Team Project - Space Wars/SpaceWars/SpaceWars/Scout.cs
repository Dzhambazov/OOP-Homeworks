using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWars
{
    public class Scout : EnemyFighters
    {
        public Scout(MatrixCoords topLeft, int aggression)
            : base(topLeft, new char[,] { { 'g' }, { 'd' } }, aggression, 3)
        {
            this.body = this.GetSpaceShipBody();
        }

        public override char[,] GetSpaceShipBody()
        {
            char[,] body = new char[,]
            {
                {'\\',' ','/'},
                {' ','W',' '}
            };
            return body;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<EnemyWeapons> shells = new List<EnemyWeapons>();
            if (bulletFired)
            {
                shells.Add(new EnemyBullet(new MatrixCoords(this.topLeft.Row + 1, this.topLeft.Col+1), 1));
                this.bulletFired = false;
                return shells;
            }

            if (this.IsDestroyed)
            {
                return base.ProduceObjects();
            }
            else
            {
                return shells;
            }
        }
    }
}
