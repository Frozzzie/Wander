using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderer.GameComponents.Items
{
    class Bag : Item // ooooh dangerous
    {
        public List<ItemStack> Contents { get; set; }


        public override int Weight { get { return Contents.Sum(x => x.Contents.Weight); } set { } }
    }
}
