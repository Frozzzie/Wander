using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.Creatures.Stats.BaseStats;
using Wanderer.Creatures.Stats.StatusStats;

namespace Wanderer.Creatures.Powers
{
    class SnakeBite : Power
    {
        public SnakeBite()
        {
            NumTargets = 1;
        }

        public SnakeBite(Creature c) : base(c)
        {
            NumTargets = 1;
        }

        public override void Activate(List<TargetingInformation> targets)
        {
            foreach (TargetingInformation t in targets)
            {
                t.Target.ApplyDamage<ConstitutionStat>(parent_.Strength);
                t.Target.ApplyStatus<Poison>(new Poison(parent_.Strength));
            }
        }
    }
}
