using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.Creatures.Stats.BaseStats;

namespace Wanderer.Creatures.Stats.DerivedStats
{
    public class MaxHealth : DerivedStat
    {
        public MaxHealth(ModifierStat<ConstitutionStat> stat)
            : base(stat)
        {
        }

        protected override void Recalculate()
        {
            _number = 5 + GetFirstStat<ModifierStat<ConstitutionStat>>().Value;
        }

        public override string Description
        {
            get
            {
                return "The maximum amount of damage a character can take before dying. Modified by " + GetFirstStat<ModifierStat<ConstitutionStat>>().Name;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override string Name
        {
            get
            {
                return "Max Health";
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
