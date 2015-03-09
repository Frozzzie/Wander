using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.Creatures;

namespace Wanderer.GameComponents.BattleComponents
{
    class TurnOrderManager
    {
        private List<SpeedContainer> _turnEntities;

        public int TurnCount { get; private set; }

        public TurnOrderManager(IEnumerable<Creature> creatures)
        {
            TurnCount = 0;
            _turnEntities = new List<SpeedContainer>();
            foreach (var c in creatures)
                _turnEntities.Add(new SpeedContainer() { Creature = c, Speed = c.Initiative.Value });
        }



    }

    class SpeedContainer : IComparable<SpeedContainer>
    {
        public int Speed { get; set; }
        public Creature Creature { get; set; }

        public void IncrementSpeed()
        {
            Speed += Creature.Speed.Value;
        }

        public int CompareTo(SpeedContainer other)
        {
            return other.Speed - Speed;
        }
    }
}
