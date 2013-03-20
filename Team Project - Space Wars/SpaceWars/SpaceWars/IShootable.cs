using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWars
{
    public interface IShootable
    {
        void Shoot();
        void ShootRocket();
        void ShootLeftBlaster();
        void ShootRightBlaster();
    }
}
