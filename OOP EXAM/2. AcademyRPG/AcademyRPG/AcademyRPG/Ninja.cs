using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Ninja : Character, IFighter, IGatherer
    {
        private int attackPoints;

        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = 1;
            this.AttackPoints = 0;
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
            get { return 999999999; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            int maxHP = 0;
            int highestHpIndex = 0;
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0 && availableTargets[i].HitPoints > maxHP)
                {
                    maxHP = availableTargets[i].HitPoints;
                    highestHpIndex = i;
                }
            }

            if (highestHpIndex != 0)
            {
                return highestHpIndex;
            }
            else
            {
                return -1;
            }

        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber || resource.Type == ResourceType.Stone)
            {
                if (resource.Type == ResourceType.Lumber)
                {
                    this.AttackPoints += resource.Quantity;
                }
                else
                {
                    this.AttackPoints += resource.Quantity * 2;
                }
                return true;
            }

            return false;
        }
    }
}
