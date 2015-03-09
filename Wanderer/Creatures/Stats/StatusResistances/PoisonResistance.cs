using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.Creatures.Stats.BaseStats;
using Wanderer.Creatures.Stats.StatusStats;

namespace Wanderer.Creatures.Stats.StatusResistances
{
    class PoisonResistance : DerivedStat, IResistance<Poison>
    {

        public PoisonResistance(ModifierStat<ConstitutionStat> con, ModifierStat<WisdomStat> wis)
            : base(con, wis)
        { }

        protected override void Recalculate()
        {
            _number = GetModifier<ConstitutionStat>() * 2 + GetModifier<WisdomStat>();
        }

        public override string Description
        {
            get
            {
                return "Resists poison status. Calculated as 2xCON + WIS. Currently: " + Value;
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
                return "Poison Resistance";
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
