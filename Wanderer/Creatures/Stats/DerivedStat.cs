using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.Creatures.Stats.BaseStats;

namespace Wanderer.Creatures.Stats
{
    public abstract class DerivedStat : Stat
    {

        protected IEnumerable<Stat> _deriveFrom;

        public DerivedStat(params Stat[] deriveFroms)
        {
            _deriveFrom = new List<Stat>(deriveFroms);
            foreach (Stat s in _deriveFrom)
                s.Changed += stat_Changed;

            Recalculate();
        }

        protected virtual void stat_Changed(object sender, StatChangedArgs e)
        {
            Recalculate();
        }

        protected abstract void Recalculate();

        protected Stat GetFirstStat()
        {
            return _deriveFrom.First();
        }

        protected Stat GetFirstStat<T>()
        {
            return _deriveFrom.First(x => x is T);
        }

        protected int GetStatValue<T>()
        {
            return GetFirstStat<T>().Value;
        }

        protected int GetModifier<T>()
        {
            return GetStatValue<ModifierStat<T>>();
        }

        public override int Value
        {
            get { return base.Value; }
            set
            {
                base.Value = value;
            }
        }

        
    }
}
