using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderer.Creatures.Stats.BaseStats
{
    public class ConstitutionStat : Stat
    {

        public ConstitutionStat(int num)
        {
            _number = num;
        }

        public override string Description
        {
            get
            {
                return "Phsyical hardiness. The ability to take hits and come back fighting. Influences defense.";
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
                return "Constitution";
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
