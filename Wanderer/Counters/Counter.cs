using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.Creatures;

namespace Wanderer.Counters
{
    public abstract class Counter
    {
        protected Creature creatureAppliedTo;
        public int Amount { get; set; }

        public Counter(Creature parent)
        {
            creatureAppliedTo = parent;
        }

        public abstract void ApplyEffect();

        public int Increment()
        {
            return Amount++;
        }

        public void Apply(int num)
        {
            Amount += num;
        }
    }
}
