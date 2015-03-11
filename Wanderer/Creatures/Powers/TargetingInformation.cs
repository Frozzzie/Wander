using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderer.Creatures.Powers
{
    public class TargetingInformation
    {
        private Creature targetCreature_;
        private bool isFriendly_;

        public Creature Target { get { return targetCreature_; } }
        public bool IsFriendly { get { return isFriendly_; } }

        /// <summary>
        /// A class for storing information of what we are targetting. It also contains information on how hit multiple enemies, were it to do so.
        /// </summary>
        /// <param name="targ">The creature being targeted</param>
        /// <param name="friendly">Is the target a friendly target. Set to true for healing targets, buffing targets etc.</param>
        public TargetingInformation(Creature targ, bool friendly)
        {
            targetCreature_ = targ;
            isFriendly_ = friendly;
        }
    }
}
