using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderer.EntityEngine
{
    interface IGameEntity : IDataHolder
    {
        int ID { get; }
        string Name { get; }
    }
}
