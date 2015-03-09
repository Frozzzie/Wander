using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderer.Creatures.Stats
{
    public abstract class Buff<T> : IComparable<Buff<T>>
    {
        protected double _value;

        public Buff(double effect, string name)
        {
            _value = effect;
            Name = name;
        }

        public string Name { get; set; }

        public abstract int Evaluate(int value);

        protected abstract int CompareTo(Buff<T> o);

        public static Buff<T> HalveBuff(string name)
        {
            return new MultBuff<T>(0.5, name);
        }

        public static Buff<T> DoubleBuff(string name)
        {
            return new MultBuff<T>(2, name);
        }

        public static Buff<T> AddOne(string name)
        {
            return new AddBuff<T>(1, name);
        }

        public static Buff<T> MinusOne(string name)
        {
            return new AddBuff<T>(-1, name);
        }

        int IComparable<Buff<T>>.CompareTo(Buff<T> other)
        {
            return CompareTo(other);
        }
    }

    public class AddBuff<T> : Buff<T>
    {

        public AddBuff(double effect, string name)
            : base(effect, name)
        { }

        public override int Evaluate(int value)
        {
            return value + (int)_value;
        }

        protected override int CompareTo(Buff<T> o)
        {
            if (o is MultBuff<T>)
                return 1;
            return 0;
        }
    }

    public class MultBuff<T> : Buff<T>
    {
        public MultBuff(double effect, string name)
            : base(effect, name)
        { }

        public override int Evaluate(int value)
        {
            return (int)(value * _value);
        }

        protected override int CompareTo(Buff<T> o)
        {
            if (o is AddBuff<T>)
                return -1;
            return 0;
        }
    }
}
