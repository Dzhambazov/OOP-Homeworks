using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Giant : Character, IGatherer, IFighter
    {
        private int attackPoints;
        private bool isIncreased = false;
        public Giant(string name, Point point)
            : base(name, point, 0)
        {
            this.HitPoints = 200;
            this.AttackPoints = 150;
        }

        public int AttackPoints
        {
            get { return this.attackPoints; }
            private set
            {
                    this.attackPoints = value;
            }
        }

        public int DefensePoints
        {
            get { return 80; }
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                if (!this.isIncreased)
                {
                    this.AttackPoints += 100;
                    this.isIncreased = true;
                }
                return true;
       
            }

            return false;
        }


        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
