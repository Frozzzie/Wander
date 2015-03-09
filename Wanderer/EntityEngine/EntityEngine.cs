using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderer.EntityEngine
{
    class EntityEngine
    {
        public List<IGameEntity> GameEntities { get; private set; }

        public EntityEngine(ICommandInterface inter)
        {
            GameEntities = new List<IGameEntity>();
            inter.Initialise(this);
        }
    }
}
