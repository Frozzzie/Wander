using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.Creatures.Stats.BaseStats;

namespace Wanderer.Creatures.Stats
{
    public abstract class Stat
    {
        public class StatChangedArgs
        {
            public int NewStat { get; set; }
            public int OldStat { get; set; }
            public StatChangedArgs(int oldstat, int newstat)
            {
                OldStat = oldstat;
                NewStat = newstat;
            }
        }

        public delegate void StatChangedHandler(object sender, StatChangedArgs e);
        public event StatChangedHandler Changed;

        private List<Buff<Stat>> _buffs = new List<Buff<Stat>>();

        protected int _number;

        public Stat()
        {
        }

        public Stat(int value)
        { _number = value; }

        public Stat(Stat t)
        {
            _number = t.Value;
        }

        public virtual int GetStat()
        {
            return _number;
        }

        private int ApplyBuffEffects(int number)
        {
            _buffs.Sort();
            foreach (Buff<Stat> b in _buffs)
            {
                number = b.Evaluate(number);
            }
            return number;
        }

        public virtual int Value
        {
            get 
            {
                if (_buffs == null || _buffs.Count == 0)
                    return _number;
                else
                    return ApplyBuffEffects(_number);
            }
            set
            {
                if (Changed != null)
                    Changed.Invoke(this, new StatChangedArgs(_number, value));
                _number = value;
            }
        }

        public abstract string Description { get; set; }
        public virtual string LongDescription { get { return Description; } set { throw new NotImplementedException(); } }
        public abstract string Name { get; set; }

        public Buff<Stat> GetBuff(string name)
        {
            return _buffs.First(x => x.Name == name);
        }

        public void AddBuff(Buff<Stat> buff)
        {
            _buffs.Add(buff);
        }

        public override string ToString()
        {
            return String.Format("{0}: {1}", Name, Value);
        }

        public static implicit operator int(Stat stat)
        {
            return stat.Value;
        }

    }
}
