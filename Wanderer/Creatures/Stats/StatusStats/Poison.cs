using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.Creatures.Stats.BaseStats;
using Wanderer.Creatures.Stats.StatusResistances;

namespace Wanderer.Creatures.Stats.StatusStats
{
    class Poison : Stat, IStatus
    {
        private IResistance<Poison> _resist;

        public Poison()
        {
 
        }

        public Poison(int value)
        {
            _number = value;
        }

        public override string Description
        {
            get
            {
                return "Deals damage equal to the applied amount. Decays slowly";
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override string LongDescription
        {
            get
            {
                return "Poison deals damage to a creature equal to the number of poison counters it has applied to it " +
                    "(minus Poison Resistance). Poison is resisted by strong bodies and a little bit of common sense. " +
                    "It tends to decay slowly. It is best at stacking damage on a single target consistently.";
            }
            set
            {
                base.LongDescription = value;
            }
        }

        public override string Name
        {
            get
            {
                return "Poison";
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void AccumulateStatus(Creature c)
        {
            c.AccumulateStatus<Poison>(this);
        }

        public void ApplyStatus(Creature c)
        {
            c.ApplyStatus<Poison>(this);
        }


        public void ApplyEffect(Creature c)
        {
            c.ApplyDamage(Value - c.GetStat<PoisonResistance>().Value);
        }

        public void Decay(Creature c)
        {
            Value -= c.ConMod;
        }


    }
}
