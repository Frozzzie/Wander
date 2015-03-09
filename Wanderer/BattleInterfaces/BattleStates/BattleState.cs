using SdlDotNet.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.GameComponents;
using Wanderer.GameComponents.BattleComponents;

namespace Wanderer.BattleInterfaces.BattleStates
{
    abstract class BattleState
    {
        protected Battle battle_;

        public abstract void Update(SdlDotNet.Core.TickEventArgs e);
        public abstract void HandleInput(object sender, KeyboardEventArgs e);
        public abstract void Enter(Battle battle);
        public abstract void Exit(Battle battle);
    }
}
