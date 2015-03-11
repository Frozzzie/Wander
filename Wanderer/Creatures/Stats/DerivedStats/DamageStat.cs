using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wanderer.Creatures.Stats.DerivedStats
{
    public class DamageStat : Stat
    {
        public override string Description
        {
            get
            {
                return "The amount of damage a character has received";
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
                return "Damage";
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
