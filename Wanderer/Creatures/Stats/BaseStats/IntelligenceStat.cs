using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderer.Creatures.Stats.BaseStats
{
    public class IntelligenceStat : Stat
    {
        public IntelligenceStat(int num)
        {
            _number = num;
        }

        public override string Name
        {
            get { return "Intelligence"; }
            set { throw new NotImplementedException(); }
        }

        public override string Description
        {
            get
            {
                return "Brains. Knowledge and understanding. Influences mana pool and magic damage";
            }
            set
            {
                throw new NotImplementedException();
            }
        }

    }
}
