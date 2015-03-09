using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.Creatures;
using Wanderer.EntityEngine;

namespace Wanderer.GameComponents.BattleComponents
{
    class Player : IGameEntity
    {
        public List<Creature> Creatures { get; private set; }


        public IDictionary<int, IDataHolder> Children
        {
            get {
                var results = new Dictionary<int, IDataHolder>();
                Creatures.ForEach(x => results.Add(x.ID, x));
                return results;
            }
        }

        public object Data
        {
            get { throw new NotImplementedException(); }
        }

        public int ID
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
        }
    }
}
