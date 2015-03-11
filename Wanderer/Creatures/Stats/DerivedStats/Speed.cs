using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.Creatures.Stats.BaseStats;

namespace Wanderer.Creatures.Stats.DerivedStats
{
    public class Speed : DerivedStat
    {

        public Speed(DexterityStat stat) : base (stat)
        { }

        protected override void Recalculate()
        {
            _number = GetStatValue<DexterityStat>();
        }

        public override string Description
        {
            get
            {
                return "How soon this character can act after taking a turn. Higher is better";
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
                return "Speed";
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
