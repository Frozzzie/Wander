using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderer.Creatures.Stats.BaseStats
{
    public class DexterityStat : Stat
    {
        public DexterityStat(int num)
        {
            _number = num;
        }

        public override string Name
        {
            get
            {
                return "Dexterity";
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override string Description
        {
            get
            {
                return "Nimbleness. How agile a character is. Affects turn speed.";
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
                return Description;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }

}
