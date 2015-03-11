using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.Creatures.Stats.StatusResistances;

namespace Wanderer.Creatures.Stats.StatusStats
{
    public interface IStatus
    {
        void AccumulateStatus(Creature c);
        void ApplyStatus(Creature c);
        void ApplyEffect(Creature c);

        void Decay(Creature c);

    }
}
