using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderer.GameComponents
{
    public class Gold
    {
        public int Amount { get; set; }

        public Gold(int amount) { Amount = amount; }

        public static bool operator >(Gold left, Gold right)
        {
            return left.Amount > right.Amount;
        }

        public static bool operator ==(Gold left, Gold right)
        {
            return left.Amount == right.Amount;
        }

        public static bool operator !=(Gold left, Gold right) { return !(left == right); }

        public static bool operator <(Gold left, Gold right) { return left.Amount < right.Amount; }

        public static bool operator >=(Gold left, Gold right) { return left > right || left == right; }
        public static bool operator <=(Gold left, Gold right) { return left < right || left == right; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
