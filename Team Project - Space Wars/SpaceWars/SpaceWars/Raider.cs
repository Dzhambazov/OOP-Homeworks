using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWars
{
    class Raider : EnemyFighters
    {

        public Raider(MatrixCoords topLeft, int aggression)
            : base(topLeft, new char[,] { { 'g' }, { 'd' } }, aggression, 10)
        {
            this.body = this.GetSpaceShipBody();
        }

        public override char[,] GetSpaceShipBody()
        {
            {
                char[,] body = new char[,]
                {
                    {' ','_','_','_',' '},
                    {'/',' ','o',' ','\\'},
                    {'|','\\','|','/','|' },
                    {' ',' ','v',' ', ' '}
                };
                return body;
            }
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed)
            {
                return base.ProduceObjects();
            }
            List<EnemyWeapons> shells = new List<EnemyWeapons>();
            if (rocketFired)
            {
                shells.Add(new EnemyRocket(new MatrixCoords(this.topLeft.Row + 2, this.topLeft.Col + 2), 1));
                this.rocketFired = false;
                return shells;
            }

            if (bulletFired)
            {
                shells.Add(new EnemyBullet(new MatrixCoords(this.topLeft.Row + 2, this.topLeft.Col), 1));
                shells.Add(new EnemyBullet(new MatrixCoords(this.topLeft.Row + 2, this.topLeft.Col + 4), 1));
                this.bulletFired = false;
                return shells;
            }

            
                return shells;
            
             
        }
    }
}
