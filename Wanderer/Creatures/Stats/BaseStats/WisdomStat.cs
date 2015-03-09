using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderer.Creatures.Stats.BaseStats
{
    public class WisdomStat : Stat
    {
        public WisdomStat(int num)
        {
            _number = num;
        }

        public override string Name
        { 
            get { return "Wisdom"; }
            set { throw new NotImplementedException(); }
        }

        public override string Description
        {
            get
            {
                return "Worldly knowledge. Common sense and seeing through deception. Influences divine pools and magic defenses.";
            }
            set
            {
                throw new NotImplementedException();
            }
        }

    }

}
