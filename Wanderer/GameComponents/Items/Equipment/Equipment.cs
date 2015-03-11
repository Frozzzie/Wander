using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.Creatures.Stats;

namespace Wanderer.GameComponents.Items.Equipment
{
    class Equipment : Item
    {
        public List<Stat> Affects { get; set; }

        private int _durability;
        public int Durability
        {
            get
            {
                return _durability;
            }
            set
            {
                _durability = Math.Min(value, MaxDurability);
                _durability = Math.Max(_durability, 0);
            }
        }
        public int MaxDurability { get; set; }

        public bool IsBroken { get { return _durability <= 0; } }

    }
}
