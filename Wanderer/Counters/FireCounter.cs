using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderer.Counters
{
    public class FireCounter : Counter
    {
        public FireCounter(Creatures.Creature parent)
            : base(parent)
        { }

        public override void ApplyEffect()
        {
            //if (Amount > creatureAppliedTo.FireResistance)
            //    creatureAppliedTo.ApplyDamage(1);
        }
    }
}
