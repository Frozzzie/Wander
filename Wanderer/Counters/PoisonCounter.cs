using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderer.Counters
{
    public class PoisonCounter : Counter
    {
        public PoisonCounter(Creatures.Creature parent)
            : base(parent)
        {

        }

        public override void ApplyEffect()
        {
            //if (Amount > creatureAppliedTo.PoisonResistance)
            //    creatureAppliedTo.ApplyDamage(Amount - creatureAppliedTo.PoisonResistance);
                //creatureAppliedTo.SetCurrentHealth(creatureAppliedTo.CurrentHealth - (Amount - creatureAppliedTo.PoisonResistance));
        }
    }
}
