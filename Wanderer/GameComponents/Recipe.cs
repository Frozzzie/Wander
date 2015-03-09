using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.GameComponents.Items;

namespace Wanderer.GameComponents
{
    class Recipe
    {
        // A holder of information. Holds how much of what kind of item is needed in order to make another item.

        // Three bags of flour, two cups of water
        public List<ItemStack> Ingredients { get; set; }

        public List<Item> ToolsNeeded { get; set; }

        public Item Result { get; set; }

    }
}
