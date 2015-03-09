using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderer.Creatures.Powers
{
    class Strike : Power
    {
        public Strike()
        {
            NumTargets = 1;
            PowerName = "Strike";
            Description = "Swing with your favoured arm for damage. STR v DEX";
        }

        public Strike(Creature c)
            : base(c)
        {
            NumTargets = 1;
            PowerName = "Strike";
            Description = "Swing with your favoured arm for damage. STR v DEX";
        }

        public override void Activate(List<TargetingInformation> targets)
        {
            foreach (TargetingInformation t in targets)
            {
                t.Target.ApplyDamage(parent_.GetModifierByName("Strength") - t.Target.GetModifierByName("Dexterity"));
            }
        }
    }
}
