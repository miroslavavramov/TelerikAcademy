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
            this.attackPoints = 0;
            this.HitPoints = 1;
        }

        public int AttackPoints 
        {
            get
            {
                return this.attackPoints;
            }
        }

        public int DefensePoints
        {
            get 
            { 
                return int.MaxValue; 
            }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            int targetIndex = -1;
            int maxHitPoints = -1;

            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    if (availableTargets[i].HitPoints > maxHitPoints)
                    {
                        maxHitPoints = availableTargets[i].HitPoints;
                        targetIndex = i;
                    }
                }
            }

            return targetIndex;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                this.attackPoints += resource.Quantity * 2;
                return true;
            }
            if (resource.Type == ResourceType.Lumber)
            {
                this.attackPoints += resource.Quantity;
                return true;
            }

            return false;
        }
    }
}
