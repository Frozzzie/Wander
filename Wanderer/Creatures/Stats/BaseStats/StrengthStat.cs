using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderer.Creatures.Stats.BaseStats
{
    public class StrengthStat : Stat
    {

        public StrengthStat(int num)
        {
            _number = num;
        }

        public override string Description
        {
            get { return "Brawn over brain. Represents raw muscle power. Influences melee damage."; } 
            set { throw new NotImplementedException(); }
        }

        public override string Name
        {
            get { return "Strength"; } set { throw new NotImplementedException(); }
        }

        public override string LongDescription
        {
            get { return Description; } set { throw new NotImplementedException(); }
        }
    }
}
