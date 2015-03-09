using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.GameComponents;
using Wanderer.GameComponents.BattleComponents;

namespace Wanderer.BattleInterfaces
{
    abstract class BattleInterface
    {

        protected Battle battle_;

        public abstract void Begin(Battle battle);
    }
}
