using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderer.Creatures.Stats.BaseStats
{
    public class PerceptionStat : Stat
    {
        public PerceptionStat(int num)
        {
            _number = num;
        }

        public override string Name 
        { 
            get { return "Perception"; } 
            set { throw new NotImplementedException(); } 
        }
        public override string Description
        {
            get
            {
                return "Awareness. How wary a character is of their surroundings. Influences accuracy and initiative";
            }
            set
            {
                throw new NotImplementedException();
            }
        }

    }
}
