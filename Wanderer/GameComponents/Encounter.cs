using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderer.GameComponents
{
    public abstract class Encounter
    {
        // a bunch of creatures and other things that make up an enounter. They are worth experience and give rewards
        // I'd like to make this as general as possible. Talking to someone and convincing them should be just as
        // applicable here as fighting a bunch of goons.


        /// <summary>
        /// The amount of experience, if any, given for completing the encounter.
        /// </summary>
        public int Experience { get; private set; }

        /// <summary>
        /// The rewards from the enounter. Make an IItem interface or something for this.
        /// </summary>
        public List<object> Loot { get; private set; }

    }
}
