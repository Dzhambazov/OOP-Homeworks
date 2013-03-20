using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceWars
{
    public class Battlecruiser : EnemyFighters
    {
        public Battlecruiser(MatrixCoords topLeft, int life)
            : base(topLeft, new char[,] { { 'b' }, { 'c' } }, life, 5)
        {
            this.body = this.GetSpaceShipBody();
        }

        public override char[,] GetSpaceShipBody()
        {
            char[,] body = new char[,]
            {
                {'_','_','_','(',')','(',')','_','_','_','_','_','_','_','_','_','_','(',')','(',')','_','_','_',},
                {'\\','\\','*','*','*','*','*','|','\\','/','|','\\','/','|','\\','/','|','*','*','*','*','*','/','/'},
                {' ',' ','W','W','_',' ',' ','\\','|','|','\\','/','\\','/','|','|','/',' ',' ','_','W','W',' ',' '},
                {' ',' ','\\','/', ' ','\\',' ',' ','\\','|','|','\\','/','|','|','/',' ',' ','/',' ','\\','/',' ',' '},
                {' ',' ',' ',' ',' ','|','*','*','*','\\','|','|','|','|','/','*','*','*','|',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ','|',' ',' ',' ',' ','\\','\\','/','/',' ',' ',' ',' ','|',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ','|','\\',' ',' ',' ',' ','\\','/',' ',' ',' ',' ','/','|',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ','\\','_','\\','_','_','_','_','_','_','_','_','/','_','|',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ','\\',' ','\\','_','_','_','_','_','_','/',' ','/',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' ','|','|',' ','\\','|','|','/',' ','|','|',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','†','†',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '}
            };
            return body;
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
                shells.Add(new EnemyRocket(new MatrixCoords(this.topLeft.Row + 5, this.topLeft.Col + 12), 2));
                shells.Add(new EnemyRocket(new MatrixCoords(this.topLeft.Row + 2, this.topLeft.Col + 2), 2));
                shells.Add(new EnemyRocket(new MatrixCoords(this.topLeft.Row + 2, this.topLeft.Col + 21), 2));
                this.rocketFired = false;
                return shells;
            }

            if (bulletFired)
            { 
                shells.Add(new EnemyBullet(new MatrixCoords(this.topLeft.Row + 8, this.topLeft.Col + 7 ), 1));
                shells.Add(new EnemyBullet(new MatrixCoords(this.topLeft.Row + 8, this.topLeft.Col + 16), 1));
                this.bulletFired = false;
                return shells;
            }
            return shells;           
        }
    }
}
