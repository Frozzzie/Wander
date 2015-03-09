using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderer.EntityEngine
{
    public interface IDataHolder
    {
        IDictionary<int, IDataHolder> Children { get; }
        object Data { get; }
    }
}
