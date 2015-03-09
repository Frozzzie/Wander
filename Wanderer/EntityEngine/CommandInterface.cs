using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderer.EntityEngine
{
    interface ICommandInterface
    {
        void Initialise(EntityEngine engine);
    }

    class ConsoleInterface : ICommandInterface
    {
        private EntityEngine _engine;

        public ConsoleInterface()
        {
        }

        public void Initialise(EntityEngine engine)
        {
            _engine = engine;

            // test.
            var battle = new GameComponents.BattleComponents.Battle();
            _engine.GameEntities.Add(battle);
            var hero = Test.TestCreatures.HardCodeHero();
        }
    }
}
