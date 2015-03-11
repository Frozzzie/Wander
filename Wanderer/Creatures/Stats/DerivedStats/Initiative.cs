using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.Creatures.Stats.BaseStats;

namespace Wanderer.Creatures.Stats.DerivedStats
{
    public class Initiative : DerivedStat
    {
        public Initiative(WisdomStat wis, PerceptionStat per)
            : base(wis, per)
        {
        }

        protected override void Recalculate()
        {
            _number = GetFirstStat<WisdomStat>().Value * 2 + GetFirstStat<PerceptionStat>().Value;
        }

        public override string Description
        {
            get
            {
                return "How quickly a character acts at the start of a battle. Determined by Wisdom and Perception";
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
                return "Initiative";
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
