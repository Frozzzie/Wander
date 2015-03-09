using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderer.GameComponents.Items
{
    class ItemStack
    {
        public int Amount { get; set; }
        public Item Contents { get; set; }
    }
}
