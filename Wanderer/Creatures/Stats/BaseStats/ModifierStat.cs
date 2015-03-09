using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderer.Creatures.Stats.BaseStats
{
    public class ModifierStat<T> : DerivedStat
    {

        public ModifierStat(Stat t)
            : base(t)
        {

        }

        public override string Description
        {
            get
            {
                return GetFirstStat<T>().Description;
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
                return GetFirstStat<T>().Name + " Modifier";
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        protected override void Recalculate()
        {
            _number = (GetFirstStat<T>().Value - 10) / 2;
        }

        public override string LongDescription
        {
            get
            {
                return GetFirstStat<T>().LongDescription;
            }
            set
            {
                base.LongDescription = value;
            }
        }

        public override string ToString()
        {
            return String.Format("{0}: {1}", Name, Value > 0 ? String.Format("+{0}", Value) : Value.ToString());
        }

        public override int Value
        {
            get
            {
                return base.Value;
            }
            set
            {
                throw new Exception("Unable to modify modifier values");
            }
        }
    }
}
