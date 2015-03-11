using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderer.Creatures.Stats.DerivedStats
{
    public class HealthStat : DerivedStat
    {

        public HealthStat(MaxHealth stat, DamageStat damage)
            : base(stat, damage)
        {

        }

        protected override void Recalculate()
        {
            _number = GetFirstStat<MaxHealth>().Value - GetFirstStat<DamageStat>().Value;
        }

        public override string Description
        {
            get
            {
                return "The amount of health points remaining on the character";
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
                return "Health";
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
